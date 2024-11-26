using AutomaticAttendanceSystem.Models;
using System;
using System.Windows.Forms;

namespace AutomaticAttendanceSystem.Forms
{
    public partial class MainForm : Form
    {
        private readonly Form _employeeInformationForm;
        private readonly Form _workHoursManagementForm;
        private readonly Employee _employee = Employee.Instance;

        public MainForm(Form employeeInformationForm, Form workHoursManagementForm)
        {
            _employeeInformationForm = employeeInformationForm;
            _workHoursManagementForm = workHoursManagementForm;

            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            if (_employee.InfoCompleteness)
            {
                ShowFormInPanel(mainPanel, _workHoursManagementForm);
            }
            else
            {
                ShowFormInPanel(mainPanel, _employeeInformationForm);
            }

            _employee.InfoUpdated += () =>
            {
                ShowFormInPanel(mainPanel, _workHoursManagementForm);
            };
        }

        private void EmployeeInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(mainPanel, _employeeInformationForm);
        }

        private void AttendanceSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_employee.InfoCompleteness)
            {
                ShowFormInPanel(mainPanel, _workHoursManagementForm);
            }
            else
            {
                MessageBoxForm.Show("員工訊息未完成，無法切換!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowFormInPanel(Panel panel, Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel.Controls.Clear();
            panel.Controls.Add(form);
            form.BringToFront();
            form.Show();
            Refresh();
        }

        private void ShowTimeTimer_Tick(object sender, EventArgs e)
        {
            timeStripStatusLabel.Text = DateTime.Now.ToString("yyyy/MM/dd (dddd) HH:mm:ss");
        }
    }
}
