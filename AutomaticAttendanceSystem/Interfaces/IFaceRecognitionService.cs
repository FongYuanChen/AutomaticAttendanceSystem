using AutomaticAttendanceSystem.Models;
using System.Collections.Generic;
using System.Drawing;

namespace AutomaticAttendanceSystem.Interfaces
{
    /// <summary>
    /// 提供臉部辨識相關功能的服務介面。
    /// </summary>
    public interface IFaceRecognitionService
    {
        /// <summary>
        /// 檢測圖片中的特定員工人臉區域。
        /// </summary>
        /// <param name="photo">待檢測的圖片。</param>
        /// <param name="employee">目標員工訊息。</param>
        /// <returns>匹配的人臉區域列表，每個人臉區域以 <see cref="Rectangle"/> 表示。</returns>
        public List<Rectangle> RecognizeEmployeeFaces(Bitmap photo, Employee employee);
    }
}
