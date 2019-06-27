using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Views.User
{
    public partial class UserView : Form
    {
        protected UserView()
        {
            InitializeComponent();
        }

        protected void ShowControl(Control control)
        {
            if (!panelMain.Controls.Contains(control))
            {
                panelMain.Controls.Clear();
                panelMain.Controls.Add(control);
            }
        }

        private void UserView_Load(object sender, EventArgs e)
        {
            string username = RentACarLibrary.SessionData.CurrentUser != null ?
                                RentACarLibrary.SessionData.CurrentUser.Username : "admin";
            lblUsername.Text = username;

        }
    }
}
