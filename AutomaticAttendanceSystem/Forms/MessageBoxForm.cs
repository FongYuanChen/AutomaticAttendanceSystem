using System.Windows.Forms;

namespace AutomaticAttendanceSystem.Forms
{
    public partial class MessageBoxForm : Form
    {
        private MessageBoxForm()
        {
            InitializeComponent();
        }

        private void ConfigureButtons(MessageBoxButtons buttons)
        {
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    button1.Text = "確定";
                    button1.DialogResult = DialogResult.OK;
                    AcceptButton = button1;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    break;
                case MessageBoxButtons.OKCancel:
                    button1.Text = "取消";
                    button1.DialogResult = DialogResult.Cancel;
                    CancelButton = button1;
                    button2.Text = "確定";
                    button2.DialogResult = DialogResult.OK;
                    AcceptButton = button2;
                    button3.Visible = false;
                    button4.Visible = false;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    button1.Text = "忽略(I)";
                    button1.DialogResult = DialogResult.Ignore;
                    button2.Text = "重試(R)";
                    button2.DialogResult = DialogResult.Retry;
                    AcceptButton = button2;
                    button3.Text = "中止(A)";
                    button3.DialogResult = DialogResult.Abort;
                    CancelButton = button3;
                    button4.Visible = false;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    button1.Text = "取消";
                    button1.DialogResult = DialogResult.Cancel;
                    CancelButton = button1;
                    button2.Text = "否(N)";
                    button2.DialogResult = DialogResult.No;
                    button3.Text = "是(Y)";
                    button3.DialogResult = DialogResult.Yes;
                    AcceptButton = button3;
                    button4.Visible = false;
                    break;
                case MessageBoxButtons.YesNo:
                    button1.Text = "否(N)";
                    button1.DialogResult = DialogResult.No;
                    CancelButton = button1;
                    button2.Text = "是(Y)";
                    button2.DialogResult = DialogResult.Yes;
                    AcceptButton = button2;
                    button3.Visible = false;
                    button4.Visible = false;
                    break;
                case MessageBoxButtons.RetryCancel:
                    button1.Text = "取消";
                    button1.DialogResult = DialogResult.Cancel;
                    CancelButton = button1;
                    button2.Text = "重試(R)";
                    button2.DialogResult = DialogResult.Retry;
                    AcceptButton = button2;
                    button3.Visible = false;
                    button4.Visible = false;
                    break;
                case MessageBoxButtons.CancelTryContinue:
                    button1.Text = "繼續(C)";
                    button1.DialogResult = DialogResult.Continue;
                    AcceptButton = button1;
                    button2.Text = "重試(T)";
                    button2.DialogResult = DialogResult.TryAgain;
                    button3.Text = "取消";
                    button3.DialogResult = DialogResult.Cancel;
                    CancelButton = button3;
                    button4.Visible = false;
                    break;
                default:
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    break;
            }
        }

        private void ConfigureIconImage(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Question:
                    questionPictureBox.Visible = true;
                    errorPictureBox.Visible = false;
                    warningPictureBox.Visible = false;
                    informationPictureBox.Visible = false;
                    break;
                case MessageBoxIcon.Error:
                    questionPictureBox.Visible = false;
                    errorPictureBox.Visible = true;
                    warningPictureBox.Visible = false;
                    informationPictureBox.Visible = false;
                    break;
                case MessageBoxIcon.Warning:
                    questionPictureBox.Visible = false;
                    errorPictureBox.Visible = false;
                    warningPictureBox.Visible = true;
                    informationPictureBox.Visible = false;
                    break;
                case MessageBoxIcon.Information:
                    questionPictureBox.Visible = false;
                    errorPictureBox.Visible = false;
                    warningPictureBox.Visible = false;
                    informationPictureBox.Visible = true;
                    break;
                default:
                    questionPictureBox.Visible = false;
                    errorPictureBox.Visible = false;
                    warningPictureBox.Visible = false;
                    informationPictureBox.Visible = false;
                    break;
            }
        }

        public static DialogResult Show(string text, string caption = "", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            using (var messageBox = new MessageBoxForm())
            {
                messageBox.messageLabel.Text = text;
                messageBox.Text = caption;
                messageBox.ConfigureButtons(buttons);
                messageBox.ConfigureIconImage(icon);
                return messageBox.ShowDialog();
            }
        }
    }
}
