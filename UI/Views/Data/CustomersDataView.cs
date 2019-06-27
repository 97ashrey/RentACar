using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.UserControls;
using UI.Events;
using UI.Events.Messages;

namespace UI.Views.Data
{
    public partial class CustomersDataView : UserControl, ICustomersDataView
    {
        private Control table;
        //private IEventAggregator eventAggregator;

        protected CustomersDataView()
        {
            InitializeComponent();
            NameControls();

            umcnControl.TextBox.Numbers = true;
            umcnControl.TextBox.MaxLength = Constants.UMCN_MAX_LENGTH;

            phoneControl.TextBox.Numbers = true;
            phoneControl.TextBox.MaxLength = Constants.PHONE_NUMBER_MAX_LENGTH;

            // Set control event handlers
            foreach (string key in controls.Keys)
            {
                Control control = controls[key];
                if (control is TextBox)
                {
                    (control as TextBox).TextChanged += ClearControlErrorOnValueChangedHandler;
                }
                else if (control is DateTimePicker)
                {
                    (control as DateTimePicker).ValueChanged += ClearControlErrorOnValueChangedHandler;
                }
            }
            Load += LoadHandler;
        }

        private void LoadHandler(object sender, EventArgs e)
        {
            LoadedTrigger?.Invoke(this, e);
            ParentChanged += ReloadHandler;
        }

        private void ReloadHandler(object sender, EventArgs e)
        {
            if (Parent != null)
                LoadedTrigger?.Invoke(this, e);
        }

        //public CustomersDataView(Control table, IEventAggregator eventAggregator) : this()
        //{
        //    this.eventAggregator = eventAggregator;
        //    this.table = table;
        //    this.table.Dock = DockStyle.Fill;
        //    this.splitContainer.Panel1.Controls.Add(this.table);
        //}

        public CustomersDataView(Control table) : this()
        {
            this.table = table;
            this.table.Dock = DockStyle.Fill;
            this.splitContainer.Panel1.Controls.Add(this.table);

            passwordControl.TextBox.PasswordChar = '*';
        }

        private Dictionary<string, Control> controls = new Dictionary<string, Control>();

        private void NameControls()
        {
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
            controls.Add("Password", passwordControl.TextBox);
            passwordControl.TextBox.Tag = "Lozinka";
        }

        public object Presenter { private get; set; }

        public bool RegisterNewCustomerTriggerEnabled { get => btnNew.Enabled; set => btnNew.Enabled = value; }
        public bool UpdateCustomerTriggerEnabled { get => btnUpdate.Enabled; set => btnUpdate.Enabled = value; }
        public bool DeleteCustomerTriggerEnabled { get => btnDelete.Enabled; set => btnDelete.Enabled = value; }
        public bool AllInputsEnabled { get => panelForm.Enabled; set => panelForm.Enabled = value; }

        public string FirstName { get => firstNameControl.InputText.Trim(); set => firstNameControl.InputText = value; }
        public string LastName { get => lastNameControl.InputText.Trim(); set => lastNameControl.InputText = value; }
        public string UMCN { get => umcnControl.InputText.Trim(); set => umcnControl.InputText = value; }
        public string PhoneNumber { get => phoneControl.InputText.Trim(); set => phoneControl.InputText = value; }
        public DateTime DateOfBirth { get => dateOfBirthControl.Date; set => dateOfBirthControl.Date = value; }
        public string Password { get => passwordControl.InputText.Trim(); set => passwordControl.InputText = value; }
        public event EventHandler RegisterNewCustomerTrigger;
        public event EventHandler UpdateCustomerTrigger;
        public event EventHandler DeleteCustomerTrigger;
        public event EventHandler CancleTrigger;
        public event EventHandler LoadedTrigger;

        private bool Valid()
        {
            bool valid = true;
            // check if fields are empty
            foreach (string key in controls.Keys)
            {
                if(key == "Password")
                {
                    continue;
                }
                TextBox tb = controls[key] as TextBox;
                if (tb == null)
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
            if (umcnControl.InputText.Length < Constants.UMCN_MAX_LENGTH)
            {
                errorProvider.SetError(umcnControl.TextBox, Messages.ErrorInvalidUMCNFormat());
                valid = false;
            }

            // check PhoneNumber for correct length
            if (phoneControl.InputText.Length < Constants.PHONE_NUMBER_MAX_LENGTH)
            {
                // TODO display error message
                errorProvider.SetError(phoneControl.TextBox, Messages.ErrorInvalidPhoneNumberLength());
                valid = false;
            }

            // check PhoneNumber for correct format
            Regex phoneRegex = new Regex(@"06[0-6]\d{7}");
            if (!phoneRegex.IsMatch(phoneControl.InputText.Trim()))
            {
                errorProvider.SetError(phoneControl.TextBox, Messages.ERROR_WRONG_PHONE_FORMAT);
                valid = false;
            }

            // Check if the date is not in the future
            if (dateOfBirthControl.Date > DateTime.Today)
            {
                errorProvider.SetError(dateOfBirthControl.DateTimePicker, Messages.ERROR_DATE_IN_FUTURE);
                valid = false;
            }

            FocusOnTopError();

            return valid;
        }

        public void ClearAllControls()
        {
            foreach (string key in controls.Keys)
            {
                Control control = controls[key];
                if (control is TextBox)
                {
                    (control as TextBox).Clear();
                }
                else if (control is DateTimePicker)
                {
                    (control as DateTimePicker).Value = DateTime.Today;
                }
            }
            firstNameControl.TextBox.Focus();
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
                if (control is TextBox)
                {
                    (control as TextBox).SelectedFocus();
                    return;
                }
                control.Focus();
            }
        }

        public void FocusOnTopError()
        {
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
        }

        public void ClearAllControlErrors()
        {
            foreach (string key in controls.Keys)
            {
                Control control = controls[key];
                errorProvider.ClearError(control);
            }
        }

        public void ShowAlertMessage(AlertMessage alertMessage)
        {
            alert.Display(alertMessage);
        }

        // Event handlers
        private void ClearControlErrorOnValueChangedHandler(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (errorProvider.ControlHasError(control))
            {
                errorProvider.ClearError(control);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            RegisterNewCustomerTrigger?.Invoke(this, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Valid())
            {
                alert.Display(UCAlert.AlertType.Danger, Messages.ERROR_FORM_FILL);
                return;
            }
            UpdateCustomerTrigger?.Invoke(this, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCustomerTrigger?.Invoke(this, e);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            CancleTrigger?.Invoke(this, e);
        }
    }
}
