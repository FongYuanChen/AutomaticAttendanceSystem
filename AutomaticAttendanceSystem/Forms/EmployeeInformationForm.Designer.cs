using System.Drawing;
using System.Windows.Forms;

namespace AutomaticAttendanceSystem.Forms
{
    partial class EmployeeInformationForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeInformationForm));
            panel = new Panel();
            employeeNameLabel = new Label();
            employeeNameTextBox = new TextBox();
            employeeNumberlabel = new Label();
            employeeNumberTextBox = new TextBox();
            employeeWorkHoursLabel = new Label();
            employeeWorkHoursTextBox = new TextBox();
            employeePhotoPictureBox = new PictureBox();
            cameraErrorPictureBox = new PictureBox();
            takeEmployeePhotoButton = new Button();
            retakeEmployeePhotoButton = new Button();
            takeEmployeePhotoTimer = new Timer(components);
            submitButton = new Button();
            modifyButton = new Button();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)employeePhotoPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cameraErrorPictureBox).BeginInit();
            SuspendLayout();
            // 
            // panel
            // 
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(retakeEmployeePhotoButton);
            panel.Controls.Add(takeEmployeePhotoButton);
            panel.Controls.Add(cameraErrorPictureBox);
            panel.Controls.Add(employeePhotoPictureBox);
            panel.Controls.Add(employeeWorkHoursTextBox);
            panel.Controls.Add(employeeWorkHoursLabel);
            panel.Controls.Add(employeeNumberTextBox);
            panel.Controls.Add(employeeNumberlabel);
            panel.Controls.Add(employeeNameTextBox);
            panel.Controls.Add(employeeNameLabel);
            panel.Location = new Point(30, 30);
            panel.Name = "panel";
            panel.Size = new Size(740, 310);
            panel.TabIndex = 0;
            // 
            // employeeNameLabel
            // 
            employeeNameLabel.AutoSize = true;
            employeeNameLabel.ForeColor = Color.FromArgb(241, 241, 241);
            employeeNameLabel.Location = new Point(390, 63);
            employeeNameLabel.Name = "employeeNameLabel";
            employeeNameLabel.Size = new Size(69, 20);
            employeeNameLabel.TabIndex = 1;
            employeeNameLabel.Text = "員工姓名";
            // 
            // employeeNameTextBox
            // 
            employeeNameTextBox.BackColor = Color.FromArgb(51, 51, 55);
            employeeNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            employeeNameTextBox.ForeColor = Color.FromArgb(241, 241, 241);
            employeeNameTextBox.Location = new Point(495, 61);
            employeeNameTextBox.Name = "employeeNameTextBox";
            employeeNameTextBox.Size = new Size(210, 27);
            employeeNameTextBox.TabIndex = 2;
            employeeNameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // employeeNumberlabel
            // 
            employeeNumberlabel.AutoSize = true;
            employeeNumberlabel.ForeColor = Color.FromArgb(241, 241, 241);
            employeeNumberlabel.Location = new Point(390, 145);
            employeeNumberlabel.Name = "employeeNumberlabel";
            employeeNumberlabel.Size = new Size(69, 20);
            employeeNumberlabel.TabIndex = 3;
            employeeNumberlabel.Text = "員工編號";
            // 
            // employeeNumberTextBox
            // 
            employeeNumberTextBox.BackColor = Color.FromArgb(51, 51, 55);
            employeeNumberTextBox.BorderStyle = BorderStyle.FixedSingle;
            employeeNumberTextBox.ForeColor = Color.FromArgb(241, 241, 241);
            employeeNumberTextBox.Location = new Point(495, 143);
            employeeNumberTextBox.Name = "employeeNumberTextBox";
            employeeNumberTextBox.Size = new Size(210, 27);
            employeeNumberTextBox.TabIndex = 4;
            employeeNumberTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // employeeWorkHoursLabel
            // 
            employeeWorkHoursLabel.AutoSize = true;
            employeeWorkHoursLabel.ForeColor = Color.FromArgb(241, 241, 241);
            employeeWorkHoursLabel.Location = new Point(390, 228);
            employeeWorkHoursLabel.Name = "employeeWorkHoursLabel";
            employeeWorkHoursLabel.Size = new Size(69, 20);
            employeeWorkHoursLabel.TabIndex = 5;
            employeeWorkHoursLabel.Text = "每日工時";
            // 
            // employeeWorkHoursTextBox
            // 
            employeeWorkHoursTextBox.BackColor = Color.FromArgb(51, 51, 55);
            employeeWorkHoursTextBox.BorderStyle = BorderStyle.FixedSingle;
            employeeWorkHoursTextBox.ForeColor = Color.FromArgb(241, 241, 241);
            employeeWorkHoursTextBox.Location = new Point(495, 226);
            employeeWorkHoursTextBox.Name = "employeeWorkHoursTextBox";
            employeeWorkHoursTextBox.Size = new Size(210, 27);
            employeeWorkHoursTextBox.TabIndex = 6;
            employeeWorkHoursTextBox.Text = "8";
            employeeWorkHoursTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // employeePhotoPictureBox
            // 
            employeePhotoPictureBox.BorderStyle = BorderStyle.FixedSingle;
            employeePhotoPictureBox.ErrorImage = null;
            employeePhotoPictureBox.Location = new Point(35, 35);
            employeePhotoPictureBox.Name = "employeePhotoPictureBox";
            employeePhotoPictureBox.Size = new Size(320, 240);
            employeePhotoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            employeePhotoPictureBox.TabIndex = 7;
            employeePhotoPictureBox.TabStop = false;
            // 
            // cameraErrorPictureBox
            // 
            cameraErrorPictureBox.BorderStyle = BorderStyle.FixedSingle;
            cameraErrorPictureBox.ErrorImage = null;
            cameraErrorPictureBox.Image = (Image)resources.GetObject("cameraErrorPictureBox.Image");
            cameraErrorPictureBox.Location = new Point(35, 35);
            cameraErrorPictureBox.Name = "cameraErrorPictureBox";
            cameraErrorPictureBox.Size = new Size(320, 240);
            cameraErrorPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            cameraErrorPictureBox.TabIndex = 8;
            cameraErrorPictureBox.TabStop = false;
            // 
            // takeEmployeePhotoButton
            // 
            takeEmployeePhotoButton.BackColor = Color.FromArgb(63, 63, 70);
            takeEmployeePhotoButton.FlatAppearance.BorderColor = Color.FromArgb(85, 85, 85);
            takeEmployeePhotoButton.FlatStyle = FlatStyle.Flat;
            takeEmployeePhotoButton.ForeColor = Color.FromArgb(241, 241, 241);
            takeEmployeePhotoButton.Location = new Point(35, 246);
            takeEmployeePhotoButton.Name = "takeEmployeePhotoButton";
            takeEmployeePhotoButton.Size = new Size(320, 29);
            takeEmployeePhotoButton.TabIndex = 9;
            takeEmployeePhotoButton.Text = "拍照";
            takeEmployeePhotoButton.UseVisualStyleBackColor = false;
            takeEmployeePhotoButton.Click += TakeEmployeePhotoButton_Click;
            // 
            // retakeEmployeePhotoButton
            // 
            retakeEmployeePhotoButton.BackColor = Color.FromArgb(63, 63, 70);
            retakeEmployeePhotoButton.FlatAppearance.BorderColor = Color.FromArgb(85, 85, 85);
            retakeEmployeePhotoButton.FlatStyle = FlatStyle.Flat;
            retakeEmployeePhotoButton.ForeColor = Color.FromArgb(241, 241, 241);
            retakeEmployeePhotoButton.Location = new Point(35, 246);
            retakeEmployeePhotoButton.Name = "retakeEmployeePhotoButton";
            retakeEmployeePhotoButton.Size = new Size(320, 29);
            retakeEmployeePhotoButton.TabIndex = 10;
            retakeEmployeePhotoButton.Text = "重新拍照";
            retakeEmployeePhotoButton.UseVisualStyleBackColor = false;
            retakeEmployeePhotoButton.Visible = false;
            retakeEmployeePhotoButton.Click += RetakeEmployeePhotoButton_Click;
            // 
            // takeEmployeePhotoTimer
            // 
            takeEmployeePhotoTimer.Interval = 10;
            takeEmployeePhotoTimer.Tick += TakeEmployeePhotoTimer_Tick;
            // 
            // submitButton
            // 
            submitButton.BackColor = Color.FromArgb(63, 63, 70);
            submitButton.FlatAppearance.BorderColor = Color.FromArgb(85, 85, 85);
            submitButton.FlatStyle = FlatStyle.Flat;
            submitButton.ForeColor = Color.FromArgb(241, 241, 241);
            submitButton.Location = new Point(30, 340);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(740, 29);
            submitButton.TabIndex = 11;
            submitButton.Text = "提交";
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Click += SubmitButton_Click;
            // 
            // modifyButton
            // 
            modifyButton.BackColor = Color.FromArgb(63, 63, 70);
            modifyButton.FlatAppearance.BorderColor = Color.FromArgb(85, 85, 85);
            modifyButton.FlatStyle = FlatStyle.Flat;
            modifyButton.ForeColor = Color.FromArgb(241, 241, 241);
            modifyButton.Location = new Point(30, 340);
            modifyButton.Name = "modifyButton";
            modifyButton.Size = new Size(740, 29);
            modifyButton.TabIndex = 12;
            modifyButton.Text = "修改";
            modifyButton.UseVisualStyleBackColor = false;
            modifyButton.Visible = false;
            modifyButton.Click += ModifyButton_Click;
            // 
            // EmployeeInformationForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 27, 28);
            ClientSize = new Size(800, 400);
            Controls.Add(modifyButton);
            Controls.Add(submitButton);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmployeeInformationForm";
            Text = "員工訊息";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)employeePhotoPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)cameraErrorPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Label employeeNameLabel;
        private TextBox employeeNameTextBox;
        private Label employeeNumberlabel;
        private TextBox employeeNumberTextBox;
        private Label employeeWorkHoursLabel;
        private TextBox employeeWorkHoursTextBox;
        private PictureBox employeePhotoPictureBox;
        private PictureBox cameraErrorPictureBox;
        private System.Windows.Forms.Timer takeEmployeePhotoTimer;
        private Button takeEmployeePhotoButton;
        private Button retakeEmployeePhotoButton;
        private Button submitButton;
        private Button modifyButton;
    }
}
