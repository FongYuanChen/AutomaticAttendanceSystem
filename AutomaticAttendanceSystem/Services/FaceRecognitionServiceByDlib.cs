using AutomaticAttendanceSystem.Interfaces;
using AutomaticAttendanceSystem.Models;
using DlibDotNet;
using DlibDotNet.Dnn;
using DlibDotNet.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AutomaticAttendanceSystem.Services
{
    public class FaceRecognitionServiceByDlib : IFaceRecognitionService
    {
        /// <summary>
        /// 人臉檢測服務。
        /// </summary>
        private readonly IFaceDetectorService _faceDetectorService;

        /// <summary>
        /// 用於檢測人臉特徵點的預測器。
        /// </summary>
        private readonly ShapePredictor _shapePredictor = ShapePredictor.Deserialize(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "FaceRecognitionModels", "shape_predictor_68_face_landmarks.dat"));

        /// <summary>
        /// 用於生成人臉特徵向量的 ResNet 模型。
        /// </summary>
        private readonly LossMetric _faceRecognizer = LossMetric.Deserialize(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "FaceRecognitionModels", "dlib_face_recognition_resnet_model_v1.dat"));

        /// <summary>
        /// 緩存的員工人臉特徵向量，用於快速匹配。
        /// </summary>
        private readonly ConcurrentDictionary<string, Matrix<float>> _faceDescriptors = new ConcurrentDictionary<string, Matrix<float>>();

        public FaceRecognitionServiceByDlib(IFaceDetectorService faceDetectorService)
        {
            _faceDetectorService = faceDetectorService;
        }

        /// <summary>
        /// 檢測圖片中的特定員工人臉區域。
        /// </summary>
        /// <param name="photo">待檢測的圖片。</param>
        /// <param name="employee">目標員工訊息。</param>
        /// <returns>匹配的人臉區域列表，每個人臉區域以 <see cref="Rectangle"/> 表示。</returns>
        public List<System.Drawing.Rectangle> RecognizeEmployeeFaces(Bitmap photo, Employee employee)
        {
            var targetFaceDescriptor = GetFaceDescriptor(employee);
            var detectedFaceRectangles = _faceDetectorService.DetectFaces(photo);
            var matchedFaceRectangles = detectedFaceRectangles.Where(faceRectangle =>
                                                              {
                                                                  var faceDescriptor = GetFaceDescriptor(photo, faceRectangle);
                                                                  return IsSameFace(targetFaceDescriptor, faceDescriptor);
                                                              })
                                                              .ToList();
            return matchedFaceRectangles;
        }

        /// <summary>
        /// 獲取指定員工的人臉特徵向量，從緩存中獲取或生成。
        /// </summary>
        /// <param name="employee">目標員工信息。</param>
        /// <returns>人臉特徵向量。</returns>
        private Matrix<float> GetFaceDescriptor(Employee employee)
        {
            return _faceDescriptors.GetOrAdd($"{employee.Name}.{employee.Number}",
                                             (key) =>
                                             {
                                                 var photo = employee.Photo;
                                                 var faceRectangle = _faceDetectorService.DetectFaces(photo).First();
                                                 return GetFaceDescriptor(photo, faceRectangle);
                                             });
        }

        /// <summary>
        /// 從指定的人臉區域生成人臉特徵向量。
        /// </summary>
        /// <param name="photo">待處理的圖片。</param>
        /// <param name="faceRectangle">人臉區域。</param>
        /// <returns>人臉特徵向量。</returns>
        private Matrix<float> GetFaceDescriptor(Bitmap photo, System.Drawing.Rectangle faceRectangle)
        {
            using (var rgbPixels = photo.ToMatrix<RgbPixel>())
            {
                var rectangle = new DlibDotNet.Rectangle(faceRectangle.X, faceRectangle.Y, faceRectangle.X + faceRectangle.Width, faceRectangle.Y + faceRectangle.Height);
                var faceShape = _shapePredictor.Detect(rgbPixels, rectangle);
                var faceChipDetail = Dlib.GetFaceChipDetails(faceShape, 150, 0.25);
                var faceChip = Dlib.ExtractImageChip<RgbPixel>(rgbPixels, faceChipDetail);
                var faceDescriptor = _faceRecognizer.Operator(faceChip).First();
                return faceDescriptor;
            }
        }

        /// <summary>
        /// 判斷兩個人臉特徵向量是否屬於同一人。
        /// </summary>
        /// <param name="first">第一個人臉特徵向量。</param>
        /// <param name="second">第二個人臉特徵向量。</param>
        /// <param name="threshold">相似度閾值（默認為 0.6）。</param>
        /// <returns>如果兩者相似則返回 true，否則返回 false。</returns>
        private static bool IsSameFace(Matrix<float> first, Matrix<float> second, double threshold = 0.6)
        {
            var distance = Dlib.Length(first - second);
            return distance < threshold;
        }
    }
}
