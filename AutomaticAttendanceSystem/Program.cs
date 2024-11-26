using AutomaticAttendanceSystem.Forms;
using AutomaticAttendanceSystem.Interfaces;
using AutomaticAttendanceSystem.Services;
using System;
using System.Windows.Forms;

namespace AutomaticAttendanceSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            ICameraService cameraService = NotebookCameraServiceByOpenCv.Instance;
            IFaceDetectorService faceDetectorService = new FaceDetectorServiceByDlib();
            IFaceRecognitionService faceRecognitionService = new FaceRecognitionServiceByDlib(faceDetectorService);
            IUserActivityMonitor userActivityMonitor = new UserActivityMonitor();
            Form employeeInformationForm = new EmployeeInformationForm(cameraService, faceDetectorService);
            Form attendanceSystemForm = new AttendanceSystemForm(cameraService, faceRecognitionService, userActivityMonitor);
            Form mainForm = new MainForm(employeeInformationForm, attendanceSystemForm);

            Application.Run(mainForm);
        }
    }
}