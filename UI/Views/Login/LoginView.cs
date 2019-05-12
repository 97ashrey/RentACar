using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.UserControls;
using UI.Events.Messages;

namespace UI.Views.Login
{
    public partial class LoginView : Form, ILoginView
    {
        public object Presenter { private get; set; }

        public LoginView()
        {
            InitializeComponent();
            NameControls();

            passwordControl.TextBox.PasswordChar = '*';

            usernameControl.TextBox.TextChanged += ClearControlErrorOnValueChanged;
            passwordControl.TextBox.TextChanged += ClearControlErrorOnValueChanged;

            usernameControl.TextBox.KeyDown += EnterKeyDown;
            passwordControl.TextBox.KeyDown += EnterKeyDown;
        }

        private Dictionary<string, TextBox> controls = new Dictionary<string, TextBox>();

        private void NameControls()
        {
            controls.Add("Username", usernameControl.TextBox);
            controls.Add("Password", passwordControl.TextBox);
        }

        public string Username { get => usernameControl.InputText.Trim(); set => usernameControl.InputText = value; }
        public string Password { get => passwordControl.InputText.Trim(); set => usernameControl.InputText = value; }

        public event EventHandler LoginTrigger;
        public event EventHandler RegisterTrigger;

        public void SetControlError(string controlName, string message)
        {
            TextBox tb;
            if(controls.TryGetValue(controlName, out tb))
            {
                errorProvider.SetError(tb, message);
            }
        }

        public void SetControlFocus(string controlName)
        {
            TextBox tb;
            if (controls.TryGetValue(controlName, out tb))
            {
                tb.SelectedFocus();
            }
        }

        private bool IsInputValid()
        {
            bool valid = true;

            if(Username == "")
            {
                errorProvider.SetError(usernameControl.TextBox, Messages.ErrorRequiredField("Korisničko ime"));
                valid = false;
            }

            if(Password == "")
            {
                errorProvider.SetError(passwordControl.TextBox, Messages.ErrorRequiredField("Lozinka"));
                valid = false;
            }

            foreach(string key in controls.Keys)
            {
                TextBox tb = controls[key];
                if (errorProvider.ControlHasError(tb))
                {
                    tb.SelectedFocus();
                    break;
                }
            }

            return valid;
        }

        private void ClearControlErrorOnValueChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            errorProvider.ClearError(control);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!IsInputValid())
            {
                alert.Display(UCAlert.AlertType.Danger, Messages.ERROR_FORM_FILL);
                return;
            }
            LoginTrigger?.Invoke(this, new EventArgs());
        }

        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnLogin.PerformClick();
            }
        }

        private void linkNoAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterTrigger?.Invoke(this, e);
        }

        public void ShowAlertMessage(AlertMessage alertMessage)
        {
            alert.Display(alertMessage);
        }

        public void LoginSuccess()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public void ClearAllControls()
        {
            foreach(string key in controls.Keys)
            {
                controls[key].Clear();
            }
            usernameControl.TextBox.Focus();
        }

        
    }
}
