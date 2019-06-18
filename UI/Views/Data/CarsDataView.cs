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
    public partial class CarsDataView : UserControl, ICarsDataView
    {
        private Control table;

        protected CarsDataView()
        {
            InitializeComponent();

            NameControls();

            createdYearControl.TextBox.Numbers = true;

            cubicCapacityControl.TextBox.Numbers = true;
            cubicCapacityControl.TextBox.Decimals = true;
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
                LoadedTrigger?.Invoke(this, e);
        }

        public CarsDataView(Control table): this()
        {
            this.table = table;
            this.table.Dock = DockStyle.Fill;
            this.splitContainer.Panel1.Controls.Add(this.table);
        }

        private Dictionary<string, Control> controls = new Dictionary<string, Control>();

        public bool NewCarTriggerEnabled { get => btnNew.Enabled; set => btnNew.Enabled = value; }
        public bool SaveCarTriggerEnabled { get => btnSave.Enabled; set => btnSave.Enabled = value; }
        public bool UpdateCarTriggerEnabled { get => btnUpdate.Enabled; set => btnUpdate.Enabled = value; }
        public bool DeleteCarTriggerEnabled { get => btnDelete.Enabled; set => btnDelete.Enabled = value; }
        public bool AllInputsEnabled { get => tlpForm.Enabled; set => tlpForm.Enabled = value; }

        public object CarBodyDataSource { get => carBodyControl.ComboBox.DataSource; set => carBodyControl.ComboBox.DataSource = value; }
        public object ShiftTypeDataSource { get => shiftTypeControl.ComboBox.DataSource; set => shiftTypeControl.ComboBox.DataSource = value; }
        public object FuelTypeDataSource { get => fuelTypeControl.ComboBox.DataSource; set => fuelTypeControl.ComboBox.DataSource = value; }
        public object DriveTypeDataSource { get => driveTypeControl.ComboBox.DataSource; set => driveTypeControl.ComboBox.DataSource = value; }
        public object DorCountDataSource { get => dorCountControl.ComboBox.DataSource; set => dorCountControl.ComboBox.DataSource = value; }

        public string Brand { get => brandControl.InputText.Trim(); set => brandControl.InputText = value; }
        public string Model { get => modelControl.InputText.Trim(); set => modelControl.InputText = value; }
        public int CreatedYear { get => int.Parse(createdYearControl.InputText.Trim()); set => createdYearControl.InputText = value.ToString(); }
        public double CubicCapacity { get => int.Parse(cubicCapacityControl.InputText.Trim()); set => cubicCapacityControl.InputText = value.ToString(); }
        public string DriveType { get => driveTypeControl.SelectedItem as string; set => driveTypeControl.SelectedItem = value; }
        public string ShiftType { get => shiftTypeControl.SelectedItem as string; set => shiftTypeControl.SelectedItem = value; }
        public string CarBody { get => carBodyControl.SelectedItem as string; set => carBodyControl.SelectedItem = value;}
        public string FuelType { get => fuelTypeControl.SelectedItem as string; set => fuelTypeControl.SelectedItem = value; }
        public string DorCount { get => dorCountControl.SelectedItem as string; set => dorCountControl.SelectedItem = value; }

        public object Presenter { get; set; }

        public event EventHandler NewCarTrigger;
        public event EventHandler SaveCarTrigger;
        public event EventHandler UpdateCarTrigger;
        public event EventHandler DeleteCarTrigger;
        public event EventHandler CancleTrigger;
        public event EventHandler LoadedTrigger;

        private void NameControls()
        {
            controls.Add("Brand", brandControl.TextBox);
            brandControl.TextBox.Tag = "Marka";
            controls.Add("Model", modelControl.TextBox);
            modelControl.TextBox.Tag = "Model";
            controls.Add("CreatedYear", createdYearControl.TextBox);
            createdYearControl.TextBox.Tag = "Godište";
            controls.Add("CubicCapacity", cubicCapacityControl.TextBox);
            cubicCapacityControl.TextBox.Tag = "Kubikaža";
            controls.Add("CarBody", carBodyControl.ComboBox);
            carBodyControl.ComboBox.Tag = "Karoserija";
            controls.Add("DorCount", dorCountControl.ComboBox);
            dorCountControl.ComboBox.Tag = "Broj vrata";
            controls.Add("FuelType", fuelTypeControl.ComboBox);
            fuelTypeControl.ComboBox.Tag = "Gorivo";
            controls.Add("DriveType", driveTypeControl.ComboBox);
            driveTypeControl.ComboBox.Tag = "Pogon";
            controls.Add("ShiftType", shiftTypeControl.ComboBox);
            shiftTypeControl.ComboBox.Tag = "Menjač";
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
            brandControl.TextBox.Focus();
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

        private bool Valid()
        {
            bool valid = true;
            // Check for empty values
            foreach (string key in controls.Keys)
            {
                Control control = controls[key];
                if (control is TextBox)
                {
                    TextBox tb = control as TextBox;
                    bool isEmpty = tb.Text.Trim() == "";
                    if (isEmpty)
                    {
                        errorProvider.SetError(tb, Messages.ErrorRequiredField(tb.Tag as string));
                        valid = false;
                    }
                }
                else if (control is ComboBox)
                {
                    ComboBox cb = control as ComboBox;
                    if (cb.SelectedIndex == -1)
                    {
                        errorProvider.SetError(cb, Messages.ErrorRequiredField(cb.Tag as string));
                        valid = false;
                    }
                }
            }

            // Check created year as valid integer
            //int cYear;
            //if (!int.TryParse(createdYearControl.InputText.Trim(), out cYear))
            //{
            //    errorProvider.SetError(createdYearControl.TextBox, "Godiste mora da bude ceo broj");
            //    valid = false;
            //}

            //// Check cubic capacity
            //double cubicCapacity;
            //if (!double.TryParse(cubicCapacityControl.InputText.Trim(), out cubicCapacity))
            //{
            //    errorProvider.SetError(cubicCapacityControl.TextBox, "Kubikaza mora da bude realan broj");
            //    valid = false;
            //}

            FocusOnTopError();

            return valid;
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
            NewCarTrigger?.Invoke(this, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Valid())
            {
                ShowFormFillError();
                return;
            }
            SaveCarTrigger?.Invoke(this, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Valid())
            {
                ShowFormFillError();
                return;
            }
            UpdateCarTrigger?.Invoke(this, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCarTrigger?.Invoke(this, e);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            CancleTrigger?.Invoke(this, e);
        }
    }
}
