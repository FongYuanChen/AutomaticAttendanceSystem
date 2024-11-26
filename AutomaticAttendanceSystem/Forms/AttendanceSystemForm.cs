using AutomaticAttendanceSystem.Interfaces;
using AutomaticAttendanceSystem.Models;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AutomaticAttendanceSystem.Forms
{
    public partial class AttendanceSystemForm : Form
    {
        private readonly ICameraService _cameraService;
        private readonly IFaceRecognitionService _faceRecognitionService;
        private readonly IUserActivityMonitor _userActivityMonitor;
        private readonly Employee _employee = Employee.Instance;
        private readonly Stopwatch _breakTimeStopwatch = new Stopwatch();
        private readonly TimeSpan _breakTimeTolerance = TimeSpan.FromMinutes(1);

        public AttendanceSystemForm(ICameraService cameraService, IFaceRecognitionService faceRecognitionService, IUserActivityMonitor userActivityMonitor)
        {
            _cameraService = cameraService;
            _faceRecognitionService = faceRecognitionService;
            _userActivityMonitor = userActivityMonitor;

            InitializeComponent();
        }

        private void ClockInButton_Click(object sender, EventArgs e)
        {
            if (_employee.InfoCompleteness && !_employee.IsWorking)
            {
                _employee.StartWork();
            }
        }

        private void ClockOutButton_Click(object sender, EventArgs e)
        {
            if (_employee.InfoCompleteness && _employee.IsWorking)
            {
                _employee.StopWork();
            }
        }

        private void ShowStateTimer_Tick(object sender, EventArgs e)
        {
            if (_employee.InfoCompleteness)
            {
                ShowEmployeePresence();
                ShowUserActivityStatus();
            }
        }

        private void ShowEmployeePresence()
        {
            using (var photo = _cameraService.TakePhoto())
            {
                var detectedFaces = _faceRecognitionService.RecognizeEmployeeFaces(photo, _employee);
                employeeCheckBox.Checked = detectedFaces.Count > 0;
            }
        }

        private void ShowUserActivityStatus()
        {
            var userActivityStatus = _userActivityMonitor.GetUserActivityStatus();
            userActivityCheckBox.Checked = userActivityStatus.IsActive;
            activeProcessLabel.Text = userActivityStatus.ActiveProcessName;
        }

        private void ShowWorkProgressTimer_Tick(object sender, EventArgs e)
        {
            if (_employee.InfoCompleteness)
            {
                TrackWorkProgress();
                ShowWorkProgress();
            }
        }

        private void TrackWorkProgress()
        {
            if (employeeCheckBox.Checked && userActivityCheckBox.Checked)
            {
                if (_breakTimeStopwatch.IsRunning)
                {
                    _breakTimeStopwatch.Stop();
                    _breakTimeStopwatch.Reset();
                }

                if (!_employee.IsWorking && !_employee.IsClockOut)
                {
                    _employee.StartWork();
                }
            }
            else
            {
                if (!_breakTimeStopwatch.IsRunning)
                {
                    _breakTimeStopwatch.Start();
                }

                if (_employee.IsWorking && _breakTimeStopwatch.Elapsed > _breakTimeTolerance)
                {
                    _employee.PauseWork();
                }
            }

            if (_employee.IsWorking && _employee.GetAccumulatedWorkTime() >= _employee.DailyWorkHours)
            {
                _employee.StopWork();
                MessageBoxForm.Show("以滿足今日工時，可以下班了!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowWorkProgress()
        {
            var clockInTime = _employee.ClockInTime;
            clockInTextBox.Text = clockInTime.HasValue ? clockInTime.Value.ToString("HH:mm:ss") : string.Empty;
            clockInButton.Enabled = !clockInTime.HasValue;

            var clockOutTime = _employee.ClockOutTime;
            clockOutTextBox.Text = clockOutTime.HasValue ? clockOutTime.Value.ToString("HH:mm:ss") : string.Empty;
            clockOutButton.Enabled = !clockOutTime.HasValue;

            var targetWorkHours = _employee.DailyWorkHours;
            targetTimeTextBox.Text = targetWorkHours.ToString(@"hh\:mm\:ss");

            var accumulatedTime = _employee.GetAccumulatedWorkTime();
            accumulatedTimeTextBox.Text = accumulatedTime.ToString(@"hh\:mm\:ss");

            var remainingTime = targetWorkHours - accumulatedTime;
            remainingTimeTextBox.Text = (remainingTime > TimeSpan.Zero ? remainingTime : TimeSpan.Zero).ToString(@"hh\:mm\:ss");

            workTimePictureBox.Visible = _employee.IsWorking;
            breakTimePictureBox.Visible = !_employee.IsWorking;
        }
    }
}
