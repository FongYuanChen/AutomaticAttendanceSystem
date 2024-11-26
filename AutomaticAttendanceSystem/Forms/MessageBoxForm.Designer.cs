using System.Drawing;
using System.Windows.Forms;

namespace AutomaticAttendanceSystem.Forms
{
    partial class MessageBoxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxForm));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            messageLabel = new Label();
            questionPictureBox = new PictureBox();
            errorPictureBox = new PictureBox();
            warningPictureBox = new PictureBox();
            informationPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)questionPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)warningPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)informationPictureBox).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(63, 63, 70);
            button1.FlatAppearance.BorderColor = Color.FromArgb(85, 85, 85);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(241, 241, 241);
            button1.Location = new Point(366, 154);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(63, 63, 70);
            button2.FlatAppearance.BorderColor = Color.FromArgb(85, 85, 85);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.FromArgb(241, 241, 241);
            button2.Location = new Point(251, 154);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(63, 63, 70);
            button3.FlatAppearance.BorderColor = Color.FromArgb(85, 85, 85);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.FromArgb(241, 241, 241);
            button3.Location = new Point(136, 154);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(63, 63, 70);
            button4.FlatAppearance.BorderColor = Color.FromArgb(85, 85, 85);
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.FromArgb(241, 241, 241);
            button4.Location = new Point(21, 154);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 3;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = false;
            // 
            // messageLabel
            // 
            messageLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            messageLabel.ForeColor = Color.FromArgb(241, 241, 241);
            messageLabel.Location = new Point(136, 0);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(324, 151);
            messageLabel.TabIndex = 4;
            messageLabel.Text = "label1";
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // questionPictureBox
            // 
            questionPictureBox.Image = (Image)resources.GetObject("questionPictureBox.Image");
            questionPictureBox.Location = new Point(36, 45);
            questionPictureBox.Name = "questionPictureBox";
            questionPictureBox.Size = new Size(64, 64);
            questionPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            questionPictureBox.TabIndex = 5;
            questionPictureBox.TabStop = false;
            // 
            // errorPictureBox
            // 
            errorPictureBox.Image = (Image)resources.GetObject("errorPictureBox.Image");
            errorPictureBox.Location = new Point(36, 45);
            errorPictureBox.Name = "errorPictureBox";
            errorPictureBox.Size = new Size(64, 64);
            errorPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            errorPictureBox.TabIndex = 6;
            errorPictureBox.TabStop = false;
            // 
            // warningPictureBox
            // 
            warningPictureBox.Image = (Image)resources.GetObject("warningPictureBox.Image");
            warningPictureBox.Location = new Point(36, 45);
            warningPictureBox.Name = "warningPictureBox";
            warningPictureBox.Size = new Size(64, 64);
            warningPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            warningPictureBox.TabIndex = 7;
            warningPictureBox.TabStop = false;
            // 
            // informationPictureBox
            // 
            informationPictureBox.Image = (Image)resources.GetObject("informationPictureBox.Image");
            informationPictureBox.Location = new Point(36, 45);
            informationPictureBox.Name = "informationPictureBox";
            informationPictureBox.Size = new Size(64, 64);
            informationPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            informationPictureBox.TabIndex = 8;
            informationPictureBox.TabStop = false;
            // 
            // MessageBoxForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 27, 28);
            ClientSize = new Size(482, 203);
            Controls.Add(informationPictureBox);
            Controls.Add(warningPictureBox);
            Controls.Add(errorPictureBox);
            Controls.Add(questionPictureBox);
            Controls.Add(messageLabel);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MessageBoxForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "MessageBox";
            ((System.ComponentModel.ISupportInitialize)questionPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)warningPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)informationPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private Label messageLabel;
        private PictureBox questionPictureBox;
        private PictureBox errorPictureBox;
        private PictureBox warningPictureBox;
        private PictureBox informationPictureBox;
    }
}