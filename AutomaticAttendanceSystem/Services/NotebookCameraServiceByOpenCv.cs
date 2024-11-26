using AutomaticAttendanceSystem.Interfaces;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;

namespace AutomaticAttendanceSystem.Services
{
    public class NotebookCameraServiceByOpenCv : ICameraService
    {
        /// <summary>
        /// 用於多執行緒安全的鎖定對象。
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// Singleton實例，用於確保相機服務只有一個共享實例。
        /// </summary>
        private static NotebookCameraServiceByOpenCv _instance;

        /// <summary>
        /// OpenCV的攝像頭捕獲對象。
        /// </summary>
        private readonly VideoCapture _capture;

        private NotebookCameraServiceByOpenCv()
        {
            _capture = new VideoCapture(0);
        }

        /// <summary>
        /// 獲取相機服務的單例實例。
        /// </summary>
        public static NotebookCameraServiceByOpenCv Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ??= new NotebookCameraServiceByOpenCv();
                }
            }
        }

        /// <summary>
        /// 拍攝一張照片。
        /// </summary>
        /// <returns>拍攝的照片（<see cref="Bitmap"/>格式）。</returns>
        public Bitmap TakePhoto()
        {
            return CapturePhotoAndFlipY();
        }

        /// <summary>
        /// 捕獲照片並對其進行垂直翻轉處理。
        /// </summary>
        /// <returns>處理後的照片（<see cref="Bitmap"/>格式）。</returns>
        private Bitmap CapturePhotoAndFlipY()
        {
            using (var originalPhoto = new Mat())
            {
                using (var flipPhoto = new Mat())
                {
                    _capture.Read(originalPhoto);
                    Cv2.Flip(originalPhoto, flipPhoto, FlipMode.Y);
                    return flipPhoto.ToBitmap();
                }
            }
        }
    }
}
