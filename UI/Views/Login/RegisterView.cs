using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Events.Messages;

namespace UI.Views.Login
{
    public partial class RegisterView : Form, IRegisterView
    {
        public RegisterView()
        {
            InitializeComponent();
            NameControls();

            passwordControl.TextBox.PasswordChar = '*';

            umcnControl.TextBox.Numbers = true;
            umcnControl.TextBox.MaxLength = Constants.UMCN_MAX_LENGTH;

            phoneControl.TextBox.Numbers = true;
            phoneControl.TextBox.MaxLength = Constants.PHONE_NUMBER_MAX_LENGTH;
            
            // Set control event handlers
            foreach(string key in controls.Keys)
            {
                Control control = controls[key];
                if(control is TextBox)
                {
                    (control as TextBox).TextChanged += ClearControlErrorOnValueChangedHandler;
                }
                else if(control is DateTimePicker)
                {
                    (control as DateTimePicker).ValueChanged += ClearControlErrorOnValueChangedHandler;
                }
                control.KeyDown += EnterKeyDown;
            }
        }

        private Dictionary<string, Control> controls = new Dictionary<string, Control>();

        private void NameControls()
        {
            controls.Add("Username", usernameControl.TextBox);
            usernameControl.TextBox.Tag = "Korisničko ime";
            controls.Add("Password", passwordControl.TextBox);
            passwordControl.TextBox.Tag = "Lozinka";
            controls.Add("FirstName", firstNameControl.TextBox);
            firstNameControl.TextBox.Tag = "Ime";
            controls.Add("LastName", lastNameControl.TextBox);
            lastNameControl.TextBox.Tag = "Prezime";
            controls.Add("UMCN", umcnControl.TextBox);
            umcnControl.TextBox.Tag = "JMBG";
            controls.Add("Phone", phoneControl.TextBox);
            phoneControl.TextBox.Tag = "Broj telefona";
            controls.Add("DateOfBirth", dateOfBirthControl.DateTimePicker);
            dateOfBirthControl.DateTimePicker.Tag = "Datum rodjenja";
        }

        public object Presenter { private get; set; }

        public string Username { get => usernameControl.InputText.Trim(); set => usernameControl.InputText = value; }
        public string Password { get => passwordControl.InputText.Trim(); set => passwordControl.InputText = value; }
        public string FirstName { get => firstNameControl.InputText.Trim(); set => firstNameControl.InputText = value; }
        public string LastName { get => lastNameControl.InputText.Trim(); set => lastNameControl.InputText = value; }
        public string UMCN { get => umcnControl.InputText.Trim(); set => umcnControl.InputText = value; }
        public string PhoneNumber { get => phoneControl.InputText.Trim(); set => phoneControl.InputText = value; }
        public DateTime DateOfBirth { get => dateOfBirthControl.Date; set => dateOfBirthControl.Date = value; }

        public event EventHandler RegisterTrigger;

        private bool Valid()
        {
            bool valid = true;
            // check if fields are empty
            foreach (string key in controls.Keys)
            {
                TextBox tb = controls[key] as TextBox;
                if(tb == null)
                {
                    continue;
                }
                errorProvider.ClearError(tb);
                bool isEmpty = tb.Text.Trim() == "";
                if (isEmpty)
                {
                    errorProvider.SetError(tb, Messages.ErrorRequiredField(tb.Tag as string));
                    valid = false;
                }
            }

            // check UMCN for correct length
            if (umcnControl.TextBox.Text.Length < Constants.UMCN_MAX_LENGTH)
            {
                errorProvider.SetError(umcnControl.TextBox, Messages.ErrorInvalidUMCNFormat());
                valid = false;
            }

            // check PhoneNumber for correct length
            if (phoneControl.TextBox.Text.Length < Constants.PHONE_NUMBER_MAX_LENGTH)
            {
                // TODO display error message
                errorProvider.SetError(phoneControl.TextBox, Messages.ErrorInvalidPhoneNumberFormat());
                valid = false;
            }

            // Check if the date is not in the future
            if (dateOfBirthControl.DateTimePicker.Value > DateTime.Today)
            {
                errorProvider.SetError(dateOfBirthControl.DateTimePicker, Messages.ERROR_DATE_IN_FUTURE);
                valid = false;
            }

            foreach (string key in controls.Keys)
            {
                Control control = controls[key];
                if (errorProvider.ControlHasError(control))
                {
                    if (control is TextBox)
                    {
                        TextBox tb = control as TextBox;
                        tb.SelectedFocus();
                        break;
                    }
                    control.Focus();
                    break;
                }
            }

            return valid;
        }

        public void SetControlError(string controlName, string message)
        {
            Control control;
            if (controls.TryGetValue(controlName, out control))
            {
                errorProvider.SetError(control, message);
            }
        }

        public void SetControlFocus(string controlName)
        {
            Control control;
            if (controls.TryGetValue(controlName, out control))
            {
                if(control is TextBox)
                {
                    (control as TextBox).SelectedFocus();
                    return;
                }
                control.Focus();
            }
        }

        public void ShowAlertMessage(AlertMessage alertMessage)
        {
            alert.Display(alertMessage);
        }

        public void ClearAllControls()
        {
            foreach(string key in controls.Keys)
            {
                Control control = controls[key];
                if(control is TextBox)
                {
                    (control as TextBox).Clear();
                }
                else if(control is DateTimePicker)
                {
                    (control as DateTimePicker).Value = DateTime.Today;
                }
            }
            usernameControl.TextBox.Focus();
        }

        private void ClearControlErrorOnValueChangedHandler(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (errorProvider.ControlHasError(control))
            {
                errorProvider.ClearError(control);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!Valid())
            {
                alert.Display(UserControls.UCAlert.AlertType.Danger, Messages.ERROR_FORM_FILL);
                return;
            }
            RegisterTrigger?.Invoke(this, e);
        }

        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
            {
                btnRegister.PerformClick();
            }
        }
    }
}
