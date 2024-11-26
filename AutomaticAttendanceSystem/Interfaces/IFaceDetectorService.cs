using System.Collections.Generic;
using System.Drawing;

namespace AutomaticAttendanceSystem.Interfaces
{
    /// <summary>
    /// 提供臉部偵測相關功能的服務介面。
    /// </summary>
    public interface IFaceDetectorService
    {
        /// <summary>
        /// 檢測圖片中的人臉區域。
        /// </summary>
        /// <param name="photo">待檢測的圖片。</param>
        /// <returns>檢測到的人臉區域的列表，每個人臉區域以 <see cref="Rectangle"/> 表示。</returns>
        public List<Rectangle> DetectFaces(Bitmap photo);
    }
}
