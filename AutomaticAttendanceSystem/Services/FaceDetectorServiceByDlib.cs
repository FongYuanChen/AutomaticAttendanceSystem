using AutomaticAttendanceSystem.Interfaces;
using DlibDotNet;
using DlibDotNet.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AutomaticAttendanceSystem.Services
{
    public class FaceDetectorServiceByDlib : IFaceDetectorService
    {
        /// <summary>
        /// 使用 Dlib 提供的正面人臉檢測器。
        /// </summary>
        private readonly FrontalFaceDetector _faceDetector = Dlib.GetFrontalFaceDetector();

        /// <summary>
        /// 檢測圖片中的人臉區域。
        /// </summary>
        /// <param name="photo">待檢測的圖片。</param>
        /// <returns>檢測到的人臉區域的列表，每個人臉區域以 <see cref="System.Drawing.Rectangle"/> 表示。</returns>
        public List<System.Drawing.Rectangle> DetectFaces(Bitmap photo)
        {
            using (var image = photo.ToMatrix<RgbPixel>())
            {
                return _faceDetector.Operator(image)
                                    .Select(faceRectangle => new System.Drawing.Rectangle(faceRectangle.Left,
                                                                                          faceRectangle.Top,
                                                                                          Convert.ToInt32(faceRectangle.Width),
                                                                                          Convert.ToInt32(faceRectangle.Height)))
                                    .ToList();
            }
        }
    }
}
