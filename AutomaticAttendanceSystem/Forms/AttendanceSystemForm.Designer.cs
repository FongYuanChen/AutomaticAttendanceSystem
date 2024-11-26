using System.Drawing;
using System.Windows.Forms;

namespace AutomaticAttendanceSystem.Forms
{
    partial class AttendanceSystemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceSystemForm));
            attendanceGroupBox = new GroupBox();
            clockInLabel = new Label();
            clockInTextBox = new TextBox();
            clockInButton = new Button();
            clockOutLabel = new Label();
            clockOutTextBox = new TextBox();
            clockOutButton = new Button();
            workProgressGroupBox = new GroupBox();
            targetTimeLabel = new Label();
            targetTimeTextBox = new TextBox();
            accumulatedTimeLabel = new Label();
            accumulatedTimeTextBox = new TextBox();
            remainingTimeLabel = new Label();
            remainingTimeTextBox = new TextBox();
            breakTimePictureBox = new PictureBox();
            workTimePictureBox = new PictureBox();
            showWorkProgressTimer = new Timer(components);
            instantStateGroupBox = new GroupBox();
            employeeCheckBox = new CheckBox();
            userActivityCheckBox = new CheckBox();
            activeProcessLabel = new Label();
            showStateTimer = new Timer(components);
            attendanceGroupBox.SuspendLayout();
            workProgressGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)breakTimePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)workTimePictureBox).BeginInit();
            instantStateGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // attendanceGroupBox
            // 
            attendanceGroupBox.Controls.Add(clockInLabel);
            attendanceGroupBox.Controls.Add(clockInTextBox);
            attendanceGroupBox.Controls.Add(clockInButton);
            attendanceGroupBox.Controls.Add(clockOutLabel);
            attendanceGroupBox.Controls.Add(clockOutTextBox);
            attendanceGroupBox.Controls.Add(clockOutButton);
            attendanceGroupBox.ForeColor = Color.FromArgb(241, 241, 241);
            attendanceGroupBox.Location = new Point(30, 25);
            attendanceGroupBox.Name = "attendanceGroupBox";
            attendanceGroupBox.Size = new Size(400, 190);
            attendanceGroupBox.TabIndex = 0;
            attendanceGroupBox.TabStop = false;
            attendanceGroupBox.Text = "打卡管理";
            // 
            // clockInLabel
            // 
            clockInLabel.AutoSize = true;
            clockInLabel.ForeColor = Color.FromArgb(241, 241, 241);
            clockInLabel.Location = new Point(25, 60);
            clockInLabel.Name = "clockInLabel";
            clockInLabel.Size = new Size(69, 20);
            clockInLabel.TabIndex = 1;
            clockInLabel.Text = "上班打卡";
            // 
            // clockInTextBox
            // 
            clockInTextBox.BackColor = Color.FromArgb(51, 51, 55);
            clockInTextBox.BorderStyle = BorderStyle.FixedSingle;
            clockInTextBox.ForeColor = Color.FromArgb(0, 122, 204);
            clockInTextBox.Location = new Point(115, 56);
            clockInTextBox.Name = "clockInTextBox";
            clockInTextBox.ReadOnly = true;
            clockInTextBox.Size = new Size(125, 27);
            clockInTextBox.TabIndex = 2;
            clockInTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // clockInButton
            // 
            clockInButton.BackColor = Color.FromArgb(63, 63, 70);
            clockInButton.FlatAppearance.BorderColor = Color.FromArgb(85, 85, 85);
            clockInButton.FlatStyle = FlatStyle.Flat;
            clockInButton.ForeColor = Color.FromArgb(241, 241, 241);
            clockInButton.Location = new Point(275, 55);
            clockInButton.Name = "clockInButton";
            clockInButton.Size = new Size(94, 29);
            clockInButton.TabIndex = 3;
            clockInButton.Text = "上班";
            clockInButton.UseVisualStyleBackColor = false;
            clockInButton.Click += ClockInButton_Click;
            // 
            // clockOutLabel
            // 
            clockOutLabel.AutoSize = true;
            clockOutLabel.ForeColor = Color.FromArgb(241, 241, 241);
            clockOutLabel.Location = new Point(25, 123);
            clockOutLabel.Name = "clockOutLabel";
            clockOutLabel.Size = new Size(69, 20);
            clockOutLabel.TabIndex = 4;
            clockOutLabel.Text = "下班打卡";
            // 
            // clockOutTextBox
            // 
            clockOutTextBox.BackColor = Color.FromArgb(51, 51, 55);
            clockOutTextBox.BorderStyle = BorderStyle.FixedSingle;
            clockOutTextBox.ForeColor = Color.FromArgb(0, 122, 204);
            clockOutTextBox.Location = new Point(115, 119);
            clockOutTextBox.Name = "clockOutTextBox";
            clockOutTextBox.ReadOnly = true;
            clockOutTextBox.Size = new Size(125, 27);
            clockOutTextBox.TabIndex = 5;
            clockOutTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // clockOutButton
            // 
            clockOutButton.BackColor = Color.FromArgb(63, 63, 70);
            clockOutButton.FlatAppearance.BorderColor = Color.FromArgb(85, 85, 85);
            clockOutButton.FlatStyle = FlatStyle.Flat;
            clockOutButton.ForeColor = Color.FromArgb(241, 241, 241);
            clockOutButton.Location = new Point(275, 118);
            clockOutButton.Name = "clockOutButton";
            clockOutButton.Size = new Size(94, 29);
            clockOutButton.TabIndex = 6;
            clockOutButton.Text = "下班";
            clockOutButton.UseVisualStyleBackColor = false;
            clockOutButton.Click += ClockOutButton_Click;
            // 
            // workProgressGroupBox
            // 
            workProgressGroupBox.Controls.Add(targetTimeLabel);
            workProgressGroupBox.Controls.Add(targetTimeTextBox);
            workProgressGroupBox.Controls.Add(accumulatedTimeLabel);
            workProgressGroupBox.Controls.Add(accumulatedTimeTextBox);
            workProgressGroupBox.Controls.Add(remainingTimeLabel);
            workProgressGroupBox.Controls.Add(remainingTimeTextBox);
            workProgressGroupBox.Controls.Add(breakTimePictureBox);
            workProgressGroupBox.Controls.Add(workTimePictureBox);
            workProgressGroupBox.ForeColor = Color.FromArgb(241, 241, 241);
            workProgressGroupBox.Location = new Point(480, 25);
            workProgressGroupBox.Name = "workProgressGroupBox";
            workProgressGroupBox.Size = new Size(290, 345);
            workProgressGroupBox.TabIndex = 7;
            workProgressGroupBox.TabStop = false;
            workProgressGroupBox.Text = "工時進度";
            // 
            // targetTimeLabel
            // 
            targetTimeLabel.AutoSize = true;
            targetTimeLabel.ForeColor = Color.FromArgb(241, 241, 241);
            targetTimeLabel.Location = new Point(32, 46);
            targetTimeLabel.Name = "targetTimeLabel";
            targetTimeLabel.Size = new Size(69, 20);
            targetTimeLabel.TabIndex = 8;
            targetTimeLabel.Text = "目標工時";
            // 
            // targetTimeTextBox
            // 
            targetTimeTextBox.BackColor = Color.FromArgb(51, 51, 55);
            targetTimeTextBox.BorderStyle = BorderStyle.FixedSingle;
            targetTimeTextBox.ForeColor = Color.FromArgb(241, 241, 241);
            targetTimeTextBox.Location = new Point(128, 42);
            targetTimeTextBox.Name = "targetTimeTextBox";
            targetTimeTextBox.Size = new Size(125, 27);
            targetTimeTextBox.TabIndex = 9;
            targetTimeTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // accumulatedTimeLabel
            // 
            accumulatedTimeLabel.AutoSize = true;
            accumulatedTimeLabel.ForeColor = Color.FromArgb(241, 241, 241);
            accumulatedTimeLabel.Location = new Point(32, 94);
            accumulatedTimeLabel.Name = "accumulatedTimeLabel";
            accumulatedTimeLabel.Size = new Size(69, 20);
            accumulatedTimeLabel.TabIndex = 10;
            accumulatedTimeLabel.Text = "累計工時";
            // 
            // accumulatedTimeTextBox
            // 
            accumulatedTimeTextBox.BackColor = Color.FromArgb(51, 51, 55);
            accumulatedTimeTextBox.BorderStyle = BorderStyle.FixedSingle;
            accumulatedTimeTextBox.ForeColor = Color.FromArgb(0, 122, 204);
            accumulatedTimeTextBox.Location = new Point(129, 90);
            accumulatedTimeTextBox.Name = "accumulatedTimeTextBox";
            accumulatedTimeTextBox.Size = new Size(125, 27);
            accumulatedTimeTextBox.TabIndex = 11;
            accumulatedTimeTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // remainingTimeLabel
            // 
            remainingTimeLabel.AutoSize = true;
            remainingTimeLabel.Location = new Point(32, 142);
            remainingTimeLabel.Name = "remainingTimeLabel";
            remainingTimeLabel.Size = new Size(69, 20);
            remainingTimeLabel.TabIndex = 12;
            remainingTimeLabel.Text = "剩餘工時";
            // 
            // remainingTimeTextBox
            // 
            remainingTimeTextBox.BackColor = Color.FromArgb(51, 51, 55);
            remainingTimeTextBox.BorderStyle = BorderStyle.FixedSingle;
            remainingTimeTextBox.ForeColor = Color.FromArgb(0, 122, 204);
            remainingTimeTextBox.Location = new Point(129, 138);
            remainingTimeTextBox.Name = "remainingTimeTextBox";
            remainingTimeTextBox.Size = new Size(125, 27);
            remainingTimeTextBox.TabIndex = 13;
            remainingTimeTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // breakTimePictureBox
            // 
            breakTimePictureBox.Image = (Image)resources.GetObject("breakTimePictureBox.Image");
            breakTimePictureBox.Location = new Point(32, 195);
            breakTimePictureBox.Name = "breakTimePictureBox";
            breakTimePictureBox.Size = new Size(221, 114);
            breakTimePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            breakTimePictureBox.TabIndex = 14;
            breakTimePictureBox.TabStop = false;
            // 
            // workTimePictureBox
            // 
            workTimePictureBox.Image = (Image)resources.GetObject("workTimePictureBox.Image");
            workTimePictureBox.Location = new Point(32, 195);
            workTimePictureBox.Name = "workTimePictureBox";
            workTimePictureBox.Size = new Size(221, 114);
            workTimePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            workTimePictureBox.TabIndex = 15;
            workTimePictureBox.TabStop = false;
            // 
            // showWorkProgressTimer
            // 
            showWorkProgressTimer.Enabled = true;
            showWorkProgressTimer.Tick += ShowWorkProgressTimer_Tick;
            // 
            // instantStateGroupBox
            // 
            instantStateGroupBox.Controls.Add(employeeCheckBox);
            instantStateGroupBox.Controls.Add(userActivityCheckBox);
            instantStateGroupBox.Controls.Add(activeProcessLabel);
            instantStateGroupBox.ForeColor = Color.FromArgb(241, 241, 241);
            instantStateGroupBox.Location = new Point(30, 245);
            instantStateGroupBox.Name = "instantStateGroupBox";
            instantStateGroupBox.Size = new Size(400, 125);
            instantStateGroupBox.TabIndex = 16;
            instantStateGroupBox.TabStop = false;
            instantStateGroupBox.Text = "狀態監控";
            // 
            // employeeCheckBox
            // 
            employeeCheckBox.AutoCheck = false;
            employeeCheckBox.AutoSize = true;
            employeeCheckBox.ForeColor = Color.FromArgb(241, 241, 241);
            employeeCheckBox.Location = new Point(20, 40);
            employeeCheckBox.Name = "employeeCheckBox";
            employeeCheckBox.Size = new Size(61, 24);
            employeeCheckBox.TabIndex = 17;
            employeeCheckBox.Text = "本人";
            employeeCheckBox.UseVisualStyleBackColor = true;
            // 
            // userActivityCheckBox
            // 
            userActivityCheckBox.AutoCheck = false;
            userActivityCheckBox.AutoSize = true;
            userActivityCheckBox.ForeColor = Color.FromArgb(241, 241, 241);
            userActivityCheckBox.Location = new Point(20, 80);
            userActivityCheckBox.Name = "userActivityCheckBox";
            userActivityCheckBox.Size = new Size(136, 24);
            userActivityCheckBox.TabIndex = 18;
            userActivityCheckBox.Text = "使用中，軟體為";
            userActivityCheckBox.UseVisualStyleBackColor = true;
            // 
            // activeProcessLabel
            // 
            activeProcessLabel.AutoSize = true;
            activeProcessLabel.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
            activeProcessLabel.ForeColor = Color.FromArgb(0, 122, 204);
            activeProcessLabel.Location = new Point(156, 81);
            activeProcessLabel.Name = "activeProcessLabel";
            activeProcessLabel.Size = new Size(0, 20);
            activeProcessLabel.TabIndex = 19;
            // 
            // showStateTimer
            // 
            showStateTimer.Enabled = true;
            showStateTimer.Tick += ShowStateTimer_Tick;
            // 
            // AttendanceSystemForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 27, 28);
            ClientSize = new Size(800, 400);
            Controls.Add(attendanceGroupBox);
            Controls.Add(workProgressGroupBox);
            Controls.Add(instantStateGroupBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AttendanceSystemForm";
            Text = "打卡系統";
            attendanceGroupBox.ResumeLayout(false);
            attendanceGroupBox.PerformLayout();
            workProgressGroupBox.ResumeLayout(false);
            workProgressGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)breakTimePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)workTimePictureBox).EndInit();
            instantStateGroupBox.ResumeLayout(false);
            instantStateGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox attendanceGroupBox;
        private Label clockInLabel;
        private TextBox clockInTextBox;
        private Button clockInButton;
        private Label clockOutLabel;
        private TextBox clockOutTextBox;
        private Button clockOutButton;
        private GroupBox workProgressGroupBox;
        private Label targetTimeLabel;
        private TextBox targetTimeTextBox;
        private Label accumulatedTimeLabel;
        private TextBox accumulatedTimeTextBox;
        private Label remainingTimeLabel;
        private TextBox remainingTimeTextBox;
        private PictureBox breakTimePictureBox;
        private PictureBox workTimePictureBox;
        private System.Windows.Forms.Timer showWorkProgressTimer;
        private GroupBox instantStateGroupBox;
        private CheckBox employeeCheckBox;
        private CheckBox userActivityCheckBox;
        private Label activeProcessLabel;
        private System.Windows.Forms.Timer showStateTimer;
    }
}