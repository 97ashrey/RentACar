using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Events.Messages;

namespace UI.Views.Data
{
    public partial class ReservationsDataView : UserControl, IReservationsDataView
    {
        private Control table;

        protected ReservationsDataView()
        {
            InitializeComponent();

            NameControls();

            priceControl.TextBox.Numbers = true;
            priceControl.TextBox.ReadOnly = true;
            
            // Set control event handlers
            carControl.ComboBox.SelectedIndexChanged += CarSelectedHandler;
            customerControl.ComboBox.SelectedIndexChanged += CustomerSelectedHandler;

            dateFromControl.DateTimePicker.ValueChanged += DatePickedHandler;
            dateToControl.DateTimePicker.ValueChanged += DatePickedHandler;

            foreach (string key in controls.Keys)
            {
                Control control = controls[key];
                if (control is TextBox)
                {
                    (control as TextBox).TextChanged += ClearControlErrorOnValueChangedHandler;
                }
                else if (control is ComboBox)
                {
                    (control as ComboBox).SelectedIndexChanged += ClearControlErrorOnValueChangedHandler;
                }
                else if(control is DateTimePicker)
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
            if(Parent != null)
            {
                LoadedTrigger?.Invoke(this, e);
            }
        }

        public ReservationsDataView(Control table): this()
        {
            this.table = table;
            this.table.Dock = DockStyle.Fill;
            this.splitContainer.Panel1.Controls.Add(this.table);
        }

        private Dictionary<string, Control> controls = new Dictionary<string, Control>();

        public object Presenter { get; set; }
        public string CarInfo { get => lblCarInfo.Text; set => lblCarInfo.Text = value; }
        public string UserInfo { get => lblCustomerInfo.Text; set => lblCustomerInfo.Text = value; }

        public bool NewReservationTriggerEnabled { get => btnNew.Enabled; set => btnNew.Enabled = value; }
        public bool SaveReservationTriggerEnabled { get => btnSave.Enabled; set => btnSave.Enabled = value; }
        public bool UpdateReservationTriggerEnabled { get => btnUpdate.Enabled; set => btnUpdate.Enabled = value; }
        public bool DeleteReservationTriggerEnabled { get => btnDelete.Enabled; set => btnDelete.Enabled = value; }
        public bool CarSelectorEnabled { get => carControl.Enabled; set => carControl.Enabled = value; }

        public bool CustomerSelectorEnabled { get=> customerControl.Enabled; set => customerControl.Enabled = value; }

        public bool DateFromSelectorEnabled { get => dateFromControl.Enabled; set => dateFromControl.Enabled = value; }

        public bool AllInputsEnabled
        {
            get
            {
                return carControl.Enabled && customerControl.Enabled && lbPeriods.Enabled
                        && dateFromControl.Enabled && dateToControl.Enabled && priceControl.Enabled;
            }

            set
            {
                carControl.Enabled = value;
                customerControl.Enabled = value;
                lbPeriods.Enabled = value;
                dateFromControl.Enabled = value;
                dateToControl.Enabled = value;
                priceControl.Enabled = value;
            }
        }

        public object User { get => customerControl.SelectedItem; set => customerControl.SelectedItem = value; }
        public object Car { get => carControl.SelectedItem; set => carControl.SelectedItem = value; }
        public DateTime From { get => dateFromControl.Date; set => dateFromControl.Date = value; }
        public DateTime To { get => dateToControl.Date; set => dateToControl.Date = value; }
        public double Price { get => double.Parse(priceControl.InputText); set => priceControl.InputText = value.ToString(); }

        public object CarDataSource { get => carControl.ComboBox.DataSource; set => carControl.ComboBox.DataSource = value; }
        public string CarDisplayMember { get => carControl.ComboBox.DisplayMember; set => carControl.ComboBox.DisplayMember = value; }
        public object CustomerDataSource { get => customerControl.ComboBox.DataSource; set => customerControl.ComboBox.DataSource = value; }
        public string CustomerDisplayMember { get => customerControl.ComboBox.DisplayMember; set => customerControl.ComboBox.DisplayMember = value; }

        public object PeriodsDataSource { get => lbPeriods.DataSource; set => lbPeriods.DataSource = value; }

        public event EventHandler NewReservationTrigger;
        public event EventHandler SaveReservationTrigger;
        public event EventHandler UpdateReservationTrigger;
        public event EventHandler DeleteReservationTrigger;
        public event EventHandler CancleTrigger;

        public event EventHandler CarSelectedTrigger;
        public event EventHandler CustomerSelectedTrigger;
        public event EventHandler LoadedTrigger;

        public event EventHandler DatePicked;

        private void NameControls()
        {
            controls.Add("Car", carControl.ComboBox);
            carControl.ComboBox.Tag = "Automobil";
            controls.Add("Customer", customerControl.ComboBox);
            customerControl.ComboBox.Tag = "Mušterija";
            controls.Add("DateFrom", dateFromControl.DateTimePicker);
            dateFromControl.DateTimePicker.Tag = "Datum od";
            controls.Add("DateTo", dateToControl.DateTimePicker);
            dateToControl.DateTimePicker.Tag = "Datum do";
            controls.Add("Price", priceControl.TextBox);
            priceControl.TextBox.Tag = "Cena";
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
                else if (control is ComboBox)
                {
                    (control as ComboBox).SelectedIndex = -1;
                }
                else if(control is DateTimePicker)
                {
                    (control as DateTimePicker).Value = DateTime.Today;
                }
                carControl.ComboBox.Focus();
            }

            carControl.ComboBox.Focus();
            lbPeriods.DataSource = null;
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

        public void ClearAllControlErrors()
        {
            foreach (string key in controls.Keys)
            {
                Control control = controls[key];
                errorProvider.ClearError(control);
            }
        }

        public void FocusOnTopError()
        {
            // TODO set focus code
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

        public void ShowAlertMessage(AlertMessage alertMessage)
        {
            alert.Display(alertMessage);
        }
       
        private void ShowFormFillError()
        {
            AlertMessage message = new AlertMessage(AlertMessage.MessageType.Error, Messages.ERROR_FORM_FILL);
            alert.Display(message);
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
            NewReservationTrigger?.Invoke(this, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveReservationTrigger?.Invoke(this, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateReservationTrigger?.Invoke(this, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteReservationTrigger?.Invoke(this, e);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            CancleTrigger?.Invoke(this, e);
        }

        private void CarSelectedHandler(object sender, EventArgs e)
        {
            CarSelectedTrigger?.Invoke(this, e);
        }

        private void CustomerSelectedHandler(object sender, EventArgs e)
        {
            CustomerSelectedTrigger?.Invoke(this, e);
        }

        private void DatePickedHandler(object sender, EventArgs e)
        {
            DatePicked?.Invoke(this, e);
        }
    }
}
