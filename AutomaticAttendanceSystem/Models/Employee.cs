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
            InitializeInfoPersistence();
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

        #region 員工訊息

        /// <summary>
        /// 員工訊息的鎖，確保多線程操作安全。
        /// </summary>
        private static readonly object _infoLock = new object();

        /// <summary>
        /// 員工姓名。
        /// </summary>
        public string Name
        {
            get
            {
                lock (_infoLock)
                {
                    return _name;
                }
            }
        }
        private string _name;

        /// <summary>
        /// 員工編號。
        /// </summary>
        public string Number
        {
            get
            {
                lock (_infoLock)
                {
                    return _number;
                }
            }
        }
        private string _number;

        /// <summary>
        /// 員工照片。
        /// </summary>
        public Bitmap Photo
        {
            get
            {
                lock (_infoLock)
                {
                    return _photo;
                }
            }
        }
        private Bitmap _photo;

        /// <summary>
        /// 每日工作時長。
        /// </summary>
        public TimeSpan DailyWorkHours
        {
            get
            {
                lock (_infoLock)
                {
                    return _dailyWorkHours;
                }
            }
        }
        private TimeSpan _dailyWorkHours;

        /// <summary>
        /// 判斷員工訊息是否完整。
        /// </summary>
        public bool InfoCompleteness
        {
            get
            {
                lock (_infoLock)
                {
                    return !string.IsNullOrEmpty(_name) && !string.IsNullOrEmpty(_number) && _photo != null && _dailyWorkHours > TimeSpan.Zero;
                }
            }
        }

        /// <summary>
        /// 員工工時追蹤的計時器。
        /// </summary>
        private readonly Stopwatch _workTimeStopwatch = new Stopwatch();

        /// <summary>
        /// 員工是否正在工作。
        /// </summary>
        public bool IsWorking
        {
            get
            {
                lock (_infoLock)
                {
                    return _workTimeStopwatch.IsRunning;
                }
            }
        }

        /// <summary>
        /// 員工是否已打下班卡。
        /// </summary>
        public bool IsClockOut
        {
            get
            {
                lock (_infoLock)
                {
                    return _isClockOut;
                }
            }
        }
        private bool _isClockOut;

        /// <summary>
        /// 員工的工作時段紀錄。
        /// </summary>
        public List<(DateTime Start, DateTime? End)> WorkSessions
        {
            get
            {
                lock (_infoLock)
                {
                    return _workSessions;
                }
            }
        }
        private readonly List<(DateTime Start, DateTime? End)> _workSessions = new List<(DateTime Start, DateTime? End)>();

        /// <summary>
        /// 員工的上班打卡時間。
        /// </summary>
        public DateTime? ClockInTime
        {
            get
            {
                lock (_infoLock)
                {
                    return (_workSessions.Count > 0) ? _workSessions[0].Start : null;
                }
            }
        }

        /// <summary>
        /// 員工的下班打卡時間。
        /// </summary>
        public DateTime? ClockOutTime
        {
            get
            {
                lock (_infoLock)
                {
                    return IsClockOut ? _workSessions[^1].End : null;
                }
            }
        }

        /// <summary>
        /// 員工的累計工作時長。
        /// </summary>
        public TimeSpan AccumulatedWorkTime
        {
            get
            {
                lock (_infoLock)
                {
                    return _workSessions.Aggregate(IsWorking ? _workTimeStopwatch.Elapsed : TimeSpan.Zero,
                                                   (total, session) => total + (session.End.HasValue ? session.End.Value - session.Start : TimeSpan.Zero));
                }
            }
        }

        /// <summary>
        /// 當員工資訊更新時觸發的事件。
        /// </summary>
        public event Action InfoUpdated;

        /// <summary>
        /// 更新員工資訊。
        /// </summary>
        /// <param name="name">姓名。</param>
        /// <param name="number">編號。</param>
        /// <param name="photo">照片。</param>
        /// <param name="dailyWorkHours">每日工作時長。</param>
        /// <param name="isClockOut">指示是否已經完成下班打卡的狀態，預設為 <c>false</c>。</param>
        /// <param name="workSessions">用於記錄員工的工作時段。若未提供，默認為空列表。</param>
        public void UpdateInfo(string name, string number, Bitmap photo, TimeSpan dailyWorkHours, bool isClockOut = default, List<(DateTime Start, DateTime? End)> workSessions = default)
        {
            lock (_infoLock)
            {
                _name = name;
                _number = number;
                _photo = photo;
                _dailyWorkHours = dailyWorkHours;
                _isClockOut = isClockOut;
                _workSessions.Clear();
                _workSessions.AddRange(workSessions ?? new List<(DateTime Start, DateTime? End)>());
                _workTimeStopwatch.Stop();
                _workTimeStopwatch.Reset();
            }
            InfoUpdated?.Invoke();
        }

        /// <summary>
        /// 開始工作。
        /// </summary>
        public void StartWork()
        {
            lock (_infoLock)
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
            lock (_infoLock)
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
            lock (_infoLock)
            {
                PauseWork();
                _isClockOut = true;
            }
        }

        #endregion

        #region 員工訊息持久化

        /// <summary>
        /// 員工訊息持久化Timer。
        /// </summary>
        private System.Threading.Timer _infoPersistenceTimer;

        /// <summary>
        /// 員工訊息儲存的檔案路徑。
        /// </summary>
        private readonly string _infoFilePath = "Employee.json";

        /// <summary>
        /// 員工訊息文件操作的鎖，確保多線程操作安全。
        /// </summary>
        private readonly object _infoFileLock = new object();

        /// <summary>
        /// 初始化員工訊息持久化。
        /// </summary>
        public void InitializeInfoPersistence()
        {
            LoadInfoFromFile();
            InfoUpdated += SaveInfoToFile;
            _infoPersistenceTimer = new System.Threading.Timer((state) => { SaveInfoToFile(); }, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }

        /// <summary>
        /// 將員工訊息保存至檔案中。
        /// </summary>
        private void SaveInfoToFile()
        {
            lock (_infoFileLock)
            {
                try
                {
                    var jObject = new JObject
                    {
                        { "name", Name },
                        { "number", Number },
                        { "photo", ConvertToBase64String(Photo) },
                        { "dailyWorkHours", DailyWorkHours },
                        { "isClockOut", IsClockOut },
                        { "workSessions",
                          new JArray(WorkSessions.Select(session => new JObject
                                                 {
                                                     { "Start", session.Start },
                                                     { "End", session.End.HasValue ? session.End.Value : DateTime.Now}
                                                 }))
                        }
                    };
                    File.WriteAllText(_infoFilePath, jObject.ToString());
                }
                catch (Exception)
                {
                    File.Delete(_infoFilePath);
                }
            }
        }

        /// <summary>
        /// 加載員工訊息，從檔案中讀取已保存的數據並初始化。
        /// </summary>
        private void LoadInfoFromFile()
        {
            lock (_infoFileLock)
            {
                try
                {
                    if (File.Exists(_infoFilePath))
                    {
                        var jObject = JObject.Parse(File.ReadAllText(_infoFilePath));
                        var name = (string)jObject["name"];
                        var number = (string)jObject["number"];
                        var photo = ConvertToBitmap((string)jObject["photo"]);
                        var dailyWorkHours = (TimeSpan)jObject["dailyWorkHours"];
                        var isClockOut = (bool)jObject["isClockOut"];
                        var workSessions = jObject["workSessions"].Select(session => (Start: (DateTime)session["Start"], End: (DateTime?)session["End"]))
                                                                  .ToList();
                        if (workSessions.Count > 0 && workSessions[^1].End.Value.Day == DateTime.Now.Day)
                        {
                            UpdateInfo(name, number, photo, dailyWorkHours, isClockOut, workSessions);
                        }
                        else
                        {
                            UpdateInfo(name, number, photo, dailyWorkHours);
                        }
                    }
                }
                catch (Exception)
                {
                    UpdateInfo(null, null, null, TimeSpan.Zero);
                }
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
