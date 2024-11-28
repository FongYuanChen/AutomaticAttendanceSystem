using AutomaticAttendanceSystem.Interfaces;
using AutomaticAttendanceSystem.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutomaticAttendanceSystem.Forms
{
    public partial class EmployeeInformationForm : Form
    {
        private readonly ICameraService _cameraService;
        private readonly IFaceDetectorService _faceDetectorService;
        private readonly Employee _employee = Employee.Instance;

        public EmployeeInformationForm(ICameraService cameraService, IFaceDetectorService faceDetectorService)
        {
            _cameraService = cameraService;
            _faceDetectorService = faceDetectorService;

            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            if (_employee.InfoCompleteness)
            {
                ShowSubmitForm();
            }
            else
            {
                ShowModifyForm();
            }
        }

        private void TakeEmployeePhotoTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                employeePhotoPictureBox.Image?.Dispose();
                employeePhotoPictureBox.Image = _cameraService.TakePhoto();
                employeePhotoPictureBox.Refresh();
                employeePhotoPictureBox.Visible = true;
                cameraErrorPictureBox.Visible = false;
            }
            catch (Exception)
            {
                employeePhotoPictureBox.Visible = false;
                cameraErrorPictureBox.Visible = true;
            }
        }

        private void TakeEmployeePhotoButton_Click(object sender, EventArgs e)
        {
            takeEmployeePhotoTimer.Enabled = false;
            takeEmployeePhotoButton.Visible = false;
            retakeEmployeePhotoButton.Visible = true;
        }

        private void RetakeEmployeePhotoButton_Click(object sender, EventArgs e)
        {
            takeEmployeePhotoTimer.Enabled = true;
            takeEmployeePhotoButton.Visible = true;
            retakeEmployeePhotoButton.Visible = false;
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxForm.Show("確定要修改員工訊息?\n確定後會刪除當前打卡紀錄!", string.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                _employee.UpdateInfo(null, null, null, TimeSpan.Zero);
                ShowModifyForm();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var employeeName = employeeNameTextBox.Text;
            if (string.IsNullOrEmpty(employeeName))
            {
                MessageBoxForm.Show("請輸入員工姓名!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var employeeNumber = employeeNumberTextBox.Text;
            if (string.IsNullOrEmpty(employeeNumber))
            {
                MessageBoxForm.Show("請輸入員工編號!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var checkEmployeePhoto = !takeEmployeePhotoTimer.Enabled;
            if (!checkEmployeePhoto)
            {
                MessageBoxForm.Show("請拍攝員工相片!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var employeePhoto = (Bitmap)employeePhotoPictureBox.Image;
            if (!CheckPhoto(employeePhoto))
            {
                MessageBoxForm.Show("請重新拍攝員工相片!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!double.TryParse(employeeWorkHoursTextBox.Text, out var employeeWorkHours))
            {
                MessageBoxForm.Show("請輸入每日工時!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _employee.UpdateInfo(employeeName, employeeNumber, employeePhoto, TimeSpan.FromHours(employeeWorkHours));
            ShowSubmitForm();
        }

        private bool CheckPhoto(Bitmap photo)
        {
            try
            {
                return _faceDetectorService.DetectFaces(photo).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ShowModifyForm()
        {
            employeeNameTextBox.ReadOnly = false;
            employeeNameTextBox.Enabled = true;
            employeeNumberTextBox.ReadOnly = false;
            employeeNumberTextBox.Enabled = true;
            employeeWorkHoursTextBox.ReadOnly = false;
            employeeWorkHoursTextBox.Enabled = true;
            takeEmployeePhotoTimer.Enabled = employeePhotoPictureBox.Image == null;
            takeEmployeePhotoButton.Visible = employeePhotoPictureBox.Image == null;
            retakeEmployeePhotoButton.Visible = employeePhotoPictureBox.Image != null;
            submitButton.Visible = true;
            modifyButton.Visible = false;
        }

        private void ShowSubmitForm()
        {
            employeeNameTextBox.Text = _employee.Name;
            employeeNameTextBox.ReadOnly = true;
            employeeNameTextBox.Enabled = false;
            employeeNumberTextBox.Text = _employee.Number;
            employeeNumberTextBox.ReadOnly = true;
            employeeNumberTextBox.Enabled = false;
            employeeWorkHoursTextBox.Text = _employee.DailyWorkHours.TotalHours.ToString();
            employeeWorkHoursTextBox.ReadOnly = true;
            employeeWorkHoursTextBox.Enabled = false;
            employeePhotoPictureBox.Image = _employee.Photo;
            takeEmployeePhotoTimer.Enabled = false;
            takeEmployeePhotoButton.Visible = false;
            retakeEmployeePhotoButton.Visible = false;
            submitButton.Visible = false;
            modifyButton.Visible = true;
        }
    }
}
