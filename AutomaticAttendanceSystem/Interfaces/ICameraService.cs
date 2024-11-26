using System.Drawing;

namespace AutomaticAttendanceSystem.Interfaces
{
    /// <summary>
    /// 提供相機相關功能的服務介面。
    /// </summary>
    public interface ICameraService
    {
        /// <summary>
        /// 拍攝一張照片。
        /// </summary>
        /// <returns>拍攝的照片（<see cref="Bitmap"/>格式）。</returns>
        public Bitmap TakePhoto();
    }
}
