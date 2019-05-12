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
    public partial class OffersDataView : UserControl, IOffersDataView
    {
        private Control table;

        protected OffersDataView()
        {
            InitializeComponent();

            NameControls();

            carControl.ComboBox.SelectedIndexChanged += CarSelectedHandler;
            // Set control event handlers
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
            if (Parent != null)
                LoadedTrigger?.Invoke(this, e);
        }

        public OffersDataView(Control table): this()
        {
            this.table = table;
            this.table.Dock = DockStyle.Fill;
            splitContainer.Panel1.Controls.Add(this.table);
        }

        private Dictionary<string, Control> controls = new Dictionary<string, Control>();

        public string CarInfo { get => lblCarInfo.Text; set => lblCarInfo.Text = value; }

        public object CarIDsDataSource { get => carControl.ComboBox.DataSource; set => carControl.ComboBox.DataSource = value; }
        public string CarIDsDisplayMember { get => carControl.ComboBox.DisplayMember; set => carControl.ComboBox.DisplayMember = value; }
        public string CarIDsValueMemeber { get => carControl.ComboBox.ValueMember; set => carControl.ComboBox.ValueMember = value; }

        public bool NewOfferTriggerEnabled { get => btnNew.Enabled; set => btnNew.Enabled = value; }
        public bool SaveOfferTriggerEnabled { get => btnSave.Enabled; set => btnSave.Enabled = value; }
        public bool UpdateOfferTriggerEnabled { get => btnUpdate.Enabled; set => btnUpdate.Enabled = value; }
        public bool DeleteOfferTriggerEnabled { get => btnDelete.Enabled; set => btnDelete.Enabled = value; }
        public bool AllInputsEnabled
        {
            get => true;
            set
            {
                tlpCar.Enabled = value;
                tlpForm.Enabled = value;
            }
        }

        public object Car { get => carControl.SelectedItem; set => carControl.SelectedItem = value; }
        public DateTime From { get => dateFromControl.Date; set => dateFromControl.Date = value; }
        public DateTime To { get => dateToControl.Date; set => dateToControl.Date = value; }
        public double PricePerDay { get => double.Parse(pricePerDayControl.InputText); set => pricePerDayControl.InputText = value.ToString(); }
        public object Presenter { private get; set; }

        public event EventHandler NewOfferTrigger;
        public event EventHandler SaveOfferTrigger;
        public event EventHandler UpdateOfferTrigger;
        public event EventHandler DeleteOfferTrigger;
        public event EventHandler CancleTrigger;
        public event EventHandler CarSelectedTrigger;
        public event EventHandler LoadedTrigger;

        private void NameControls()
        {
            controls.Add("CarID", carControl.ComboBox);
            carControl.ComboBox.Tag = "Automobil";
            controls.Add("DateFrom", dateFromControl.DateTimePicker);
            dateFromControl.DateTimePicker.Tag = "Datum od";
            controls.Add("DateTo", dateToControl.DateTimePicker);
            dateToControl.DateTimePicker.Tag = "Datum do";
            controls.Add("PricePerDay", pricePerDayControl.TextBox);
            pricePerDayControl.TextBox.Tag = "Cena po danu";
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
            }
            carControl.ComboBox.Focus();
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

        public void ShowAlertMessage(AlertMessage alertMessage)
        {
            alert.Display(alertMessage);
        }

        private void ShowFormFillError()
        {
            AlertMessage message = new AlertMessage(AlertMessage.MessageType.Error, Messages.ERROR_FORM_FILL);
            alert.Display(message);
        }

        private bool Valid()
        {
            bool valid = true;
            if (pricePerDayControl.InputText.Trim() == "")
            {
                errorProvider.SetError(
                    pricePerDayControl.TextBox, 
                    Messages.ErrorRequiredField(pricePerDayControl.TextBox.Tag as string));
                valid = false;
            }

            if (carControl.ComboBox.SelectedIndex == -1)
            {
                errorProvider.SetError(
                    carControl.ComboBox, 
                    Messages.ErrorRequiredField(carControl.ComboBox.Tag as string));
                valid = false;
            }

            // TODO add date validations
            // From must be before TO and they cant be in the same date not counting hours
            // From and To must not be in the past
            foreach(string key in controls.Keys)
            {
                Control control = controls[key];
                if (errorProvider.ControlHasError(control))
                {
                    if(control is TextBox)
                    {
                        (control as TextBox).SelectedFocus();
                        break;
                    }
                    control.Focus();
                    break;
                }
            }
            return valid;
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
            NewOfferTrigger?.Invoke(this, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Valid())
            {
                return;
            }
            SaveOfferTrigger?.Invoke(this, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Valid())
            {
                return;
            }
            UpdateOfferTrigger?.Invoke(this, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteOfferTrigger?.Invoke(this, e);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            CancleTrigger?.Invoke(this, e);
        }

        private void CarSelectedHandler(object sender, EventArgs e)
        {
            CarSelectedTrigger?.Invoke(this, e);
        }
    }
}
