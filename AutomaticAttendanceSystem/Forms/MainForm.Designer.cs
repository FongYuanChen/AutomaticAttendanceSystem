using System.Drawing;
using System.Windows.Forms;

namespace AutomaticAttendanceSystem.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip = new MenuStrip();
            employeeInformationToolStripMenuItem = new ToolStripMenuItem();
            attendanceSystemToolStripMenuItem = new ToolStripMenuItem();
            mainPanel = new Panel();
            statusStrip = new StatusStrip();
            tempStripStatusLabel = new ToolStripStatusLabel();
            timeStripStatusLabel = new ToolStripStatusLabel();
            showTimeTimer = new Timer(components);
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { employeeInformationToolStripMenuItem, attendanceSystemToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 28);
            menuStrip.TabIndex = 0;
            // 
            // employeeInformationToolStripMenuItem
            // 
            employeeInformationToolStripMenuItem.Name = "employeeInformationToolStripMenuItem";
            employeeInformationToolStripMenuItem.Size = new Size(83, 24);
            employeeInformationToolStripMenuItem.Text = "員工訊息";
            employeeInformationToolStripMenuItem.Click += EmployeeInformationToolStripMenuItem_Click;
            // 
            // attendanceSystemToolStripMenuItem
            // 
            attendanceSystemToolStripMenuItem.Name = "attendanceSystemToolStripMenuItem";
            attendanceSystemToolStripMenuItem.Size = new Size(83, 24);
            attendanceSystemToolStripMenuItem.Text = "工時管理";
            attendanceSystemToolStripMenuItem.Click += AttendanceSystemToolStripMenuItem_Click;
            // 
            // mainPanel
            // 
            mainPanel.Location = new Point(0, 30);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 400);
            mainPanel.TabIndex = 1;
            // 
            // statusStrip
            // 
            statusStrip.AutoSize = false;
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { tempStripStatusLabel, timeStripStatusLabel });
            statusStrip.Location = new Point(0, 426);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 24);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip";
            // 
            // tempStripStatusLabel
            // 
            tempStripStatusLabel.BackColor = SystemColors.MenuBar;
            tempStripStatusLabel.Name = "tempStripStatusLabel";
            tempStripStatusLabel.Size = new Size(785, 18);
            tempStripStatusLabel.Spring = true;
            // 
            // timeStripStatusLabel
            // 
            timeStripStatusLabel.BackColor = SystemColors.MenuBar;
            timeStripStatusLabel.Margin = new Padding(0, 1, 0, 2);
            timeStripStatusLabel.Name = "timeStripStatusLabel";
            timeStripStatusLabel.Size = new Size(0, 21);
            // 
            // showTimeTimer
            // 
            showTimeTimer.Enabled = true;
            showTimeTimer.Interval = 1000;
            showTimeTimer.Tick += ShowTimeTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 27, 28);
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip);
            Controls.Add(mainPanel);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "自動打卡系統";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem employeeInformationToolStripMenuItem;
        private ToolStripMenuItem attendanceSystemToolStripMenuItem;
        private Panel mainPanel;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel tempStripStatusLabel;
        private ToolStripStatusLabel timeStripStatusLabel;
        private System.Windows.Forms.Timer showTimeTimer;
    }
}