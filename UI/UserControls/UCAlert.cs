using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UI.UserControls
{
    public partial class UCAlert : UserControl
    {
        public enum AlertType
        {
            Danger,
            Success,
            Warning
        }

        private Color ERROR_COLOR = Color.FromArgb(255, 53, 53);
        private Color FONT_ERROR_COLOR = Color.White;
        private Color SUCCESS_COLOR = Color.FromArgb(27, 183, 48);
        private Color FONT_SUCCESS_COLOR = Color.Black;
        private Color WARNING_COLOR = Color.FromArgb(244, 226, 66);
        private Color FONT_WARNING_COLOR = Color.Black;

        [
        Category("Alert"),
        Description("Sets if alert should hide itself after 'Interval' time.")
        ]
        public bool HideAutomaticaly { get; set; } = true;

        [
        Category("Alert"),
        Description("Time in miliseconds which displays how long alert is visible after it is displayed.")
        ]
        public int Interval { get => timer.Interval; set => timer.Interval = value; }

        public UCAlert()
        {
            InitializeComponent();
            Visible = false;
            timer.Tick += timer_Tick;
        }

        public void Display(AlertType type, string message)
        {
            if (HideAutomaticaly)
            {
                timer.Start();
            }
            switch (type)
            {
                case AlertType.Danger:
                    BackColor = ERROR_COLOR;
                    lblMessage.ForeColor = FONT_ERROR_COLOR;
                    break;
                case AlertType.Success:
                    BackColor = SUCCESS_COLOR;
                    lblMessage.ForeColor = FONT_SUCCESS_COLOR;
                    break;
                case AlertType.Warning:
                    BackColor = WARNING_COLOR;
                    lblMessage.ForeColor = FONT_WARNING_COLOR;
                    break;
            }
            Visible = true;
            lblMessage.Text = message;
            if (HideAutomaticaly)
            {
                timer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Hide();
            timer.Stop();
        }
    }
}
