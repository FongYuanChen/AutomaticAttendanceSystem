using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace AutomaticAttendanceSystem.Models
{
    /// <summary>
    /// 表示員工相關資訊及功能的類別
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// 用於多執行緒安全的鎖定對象。
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// Singleton實例，用於確保 <see cref="Employee"/> 類別只有一個共享實例。
        /// </summary>
        private static Employee _instance;

        private Employee()
        {
            InitializeDataPersistence();
            InitializeWorkTimeTracker();
        }

        /// <summary>
        /// 獲取 <see cref="Employee"/> 類別的單例實例。
        /// </summary>
        public static Employee Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ??= new Employee();
                }
            }
        }

        #region 基本訊息

        /// <summary>
        /// 員工索引。
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// 員工姓名。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 員工編號。
        /// </summary>
        public string Number { get; private set; }

        /// <summary>
        /// 員工照片。
        /// </summary>
        public Bitmap Photo { get; private set; }

        /// <summary>
        /// 每日工作時長。
        /// </summary>
        public TimeSpan DailyWorkHours { get; private set; }

        /// <summary>
        /// 判斷員工基本訊息是否完整。
        /// </summary>
        public bool InfoCompleteness => !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Number) && Photo != null && DailyWorkHours > TimeSpan.Zero;

        /// <summary>
        /// 當員工資訊更新時觸發的事件。
        /// </summary>
        public event Action InfoUpdated;

        /// <summary>
        /// 更新員工基本資訊。
        /// </summary>
        /// <param name="name">姓名。</param>
        /// <param name="number">編號。</param>
        /// <param name="photo">照片。</param>
        /// <param name="dailyWorkHours">每日工作時長。</param>
        public void UpdateInfo(string name, string number, Bitmap photo, TimeSpan dailyWorkHours)
        {
            Name = name;
            Number = number;
            Photo = photo;
            DailyWorkHours = dailyWorkHours;
            Index++;
            InfoUpdated?.Invoke();
        }

        /// <summary>
        /// 當員工資訊清空時觸發的事件。
        /// </summary>
        public event Action InfoCleared;

        /// <summary>
        /// 清空員工的基本訊息。
        /// </summary>
        public void ClearInfo()
        {
            Name = null;
            Number = null;
            Photo = null;
            DailyWorkHours = TimeSpan.Zero;
            InfoCleared?.Invoke();
        }

        #endregion

        #region 工時追蹤

        /// <summary>
        /// 員工的工作時段紀錄。
        /// </summary>
        private readonly List<(DateTime Start, DateTime? End)> _workSessions = new List<(DateTime Start, DateTime? End)>();

        /// <summary>
        /// 用於計算工作時長的計時器。
        /// </summary>
        private readonly Stopwatch _workTimeStopwatch = new Stopwatch();

        /// <summary>
        /// 計時器操作的鎖，確保多線程操作安全。
        /// </summary>
        private readonly object _workTimeTrackerLock = new object();

        /// <summary>
        /// 判斷員工是否正在工作。
        /// </summary>
        public bool IsWorking => _workTimeStopwatch.IsRunning;

        /// <summary>
        /// 判斷員工是否已打下班卡。
        /// </summary>
        public bool IsClockOut { get; private set; }

        /// <summary>
        /// 員工的上班打卡時間。
        /// </summary>
        public DateTime? ClockInTime => (_workSessions.Count > 0) ? _workSessions[0].Start : null;

        /// <summary>
        /// 員工的下班打卡時間。
        /// </summary>
        public DateTime? ClockOutTime => IsClockOut ? _workSessions[^1].End : null;

        /// <summary>
        /// 初始化工時追蹤功能。
        /// </summary>
        private void InitializeWorkTimeTracker()
        {
            InfoUpdated += ResetTracker;
            InfoCleared += ResetTracker;
        }

        /// <summary>
        /// 重置工時追蹤器。
        /// </summary>
        private void ResetTracker()
        {
            lock (_workTimeTrackerLock)
            {
                _workTimeStopwatch.Stop();
                _workTimeStopwatch.Reset();
                _workSessions.Clear();
            }
        }

        /// <summary>
        /// 開始工作。
        /// </summary>
        public void StartWork()
        {
            lock (_workTimeTrackerLock)
            {
                if (!IsWorking)
                {
                    _workSessions.Add((DateTime.Now, null));
                    _workTimeStopwatch.Restart();
                }
            }
        }

        /// <summary>
        /// 暫停工作。
        /// </summary>
        public void PauseWork()
        {
            lock (_workTimeTrackerLock)
            {
                if (IsWorking)
                {
                    _workTimeStopwatch.Stop();
                    var session = _workSessions.Last(session => !session.End.HasValue);
                    var index = _workSessions.IndexOf(session);
                    _workSessions[index] = (session.Start, session.Start + _workTimeStopwatch.Elapsed);
                }
            }
        }

        /// <summary>
        /// 停止工作，表示下班。
        /// </summary>
        public void StopWork()
        {
            lock (_workTimeTrackerLock)
            {
                PauseWork();
                IsClockOut = true;
            }
        }

        /// <summary>
        /// 獲取累計的工作時長。
        /// </summary>
        /// <returns>累計的工作時長（<see cref="TimeSpan"/>格式）。</returns>
        public TimeSpan GetAccumulatedWorkTime()
        {
            lock (_workTimeTrackerLock)
            {
                return _workSessions.Aggregate(IsWorking ? _workTimeStopwatch.Elapsed : TimeSpan.Zero,
                                               (total, session) => total + (session.End.HasValue ? session.End.Value - session.Start : TimeSpan.Zero));
            }
        }

        #endregion

        #region 持久化

        /// <summary>
        /// 員工數據持久化Timer。
        /// </summary>
        private System.Threading.Timer _dataPersistenceTimer;

        /// <summary>
        /// 員工數據存儲的檔案路徑。
        /// </summary>
        private readonly string _filePath = "Employee.json";

        /// <summary>
        /// 文件操作的鎖，確保多線程操作安全。
        /// </summary>
        private readonly object _fileLock = new object();

        /// <summary>
        /// 初始化數據持久化。
        /// </summary>
        public void InitializeDataPersistence()
        {
            LoadData();
            InfoUpdated += SaveData;
            InfoCleared += DeleteData;
            _dataPersistenceTimer = new System.Threading.Timer((state) => { SaveData(); }, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }

        /// <summary>
        /// 將員工數據保存至檔案中。
        /// </summary>
        private void SaveData()
        {
            lock (_fileLock)
            {
                try
                {
                    var jObject = new JObject
                    {
                        { "index", Index },
                        { "name", Name },
                        { "number", Number },
                        { "photo", ConvertToBase64String(Photo) },
                        { "dailyWorkHours", DailyWorkHours },
                        { "isClockOut", IsClockOut },
                        { "workSessions",
                          new JArray(_workSessions.Select(session => new JObject
                                                  {
                                                      { "Start", session.Start },
                                                      { "End", session.End.HasValue ? session.End.Value : DateTime.Now}
                                                  }))
                        }
                    };
                    File.WriteAllText(_filePath, jObject.ToString());
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// 加載員工數據，從檔案中讀取已保存的數據並初始化。
        /// </summary>
        private void LoadData()
        {
            lock (_fileLock)
            {
                try
                {
                    if (File.Exists(_filePath))
                    {
                        var jObject = JObject.Parse(File.ReadAllText(_filePath));

                        Index = (int)jObject["index"];
                        Name = (string)jObject["name"];
                        Number = (string)jObject["number"];
                        Photo = ConvertToBitmap((string)jObject["photo"]);
                        DailyWorkHours = (TimeSpan)jObject["dailyWorkHours"];
                        IsClockOut = (bool)jObject["isClockOut"];

                        var workSessions = jObject["workSessions"].Select(session => (Start: (DateTime)session["Start"], End: (DateTime?)session["End"]))
                                                                  .ToList();
                        if (workSessions.Count > 0 && workSessions[^1].End.Value.Day == DateTime.Now.Day)
                        {
                            _workSessions.Clear();
                            _workSessions.AddRange(workSessions);
                        }
                    }
                }
                catch (Exception)
                {
                    Index = default;
                    Name = default;
                    Number = default;
                    Photo = default;
                    DailyWorkHours = TimeSpan.Zero;
                    IsClockOut = default;
                    _workSessions.Clear();
                }
            }
        }

        /// <summary>
        /// 刪除員工數據檔案，用於清空持久化記錄。
        /// </summary>
        private void DeleteData()
        {
            lock (_fileLock)
            {
                File.Delete(_filePath);
            }
        }

        /// <summary>
        /// 將 Bitmap 圖片轉換為 Base64 字符串。
        /// </summary>
        /// <param name="photo">待轉換的 Bitmap 圖片。</param>
        /// <returns>對應的 Base64 字符串。</returns>
        private static string ConvertToBase64String(Bitmap photo)
        {
            using var memoryStream = new MemoryStream();
            photo.Save(memoryStream, ImageFormat.Png);
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        /// <summary>
        /// 將 Base64 字符串轉換為 Bitmap 圖片。
        /// </summary>
        /// <param name="photoBase64">待轉換的 Base64 字符串。</param>
        /// <returns>對應的 Bitmap 圖片。</returns>
        private static Bitmap ConvertToBitmap(string photoBase64)
        {
            var photoBytes = Convert.FromBase64String(photoBase64);
            using var memoryStream = new MemoryStream(photoBytes);
            return new Bitmap(memoryStream);
        }

        #endregion
    }
}
