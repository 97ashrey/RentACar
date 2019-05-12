using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Views.Reservation
{
    public partial class CarFilterView : UserControl, ICarFilterView
    {
        public CarFilterView()
        {
            InitializeComponent();
            NameControls();
            brandControl.ComboBox.SelectedIndexChanged += brand_SelectedIndexChanged;
        }

        Dictionary<string, Control> controls = new Dictionary<string, Control>();
        private void NameControls()
        {
            controls.Add("Brand", brandControl.ComboBox);
            brandControl.ComboBox.Tag = "Marka";
            controls.Add("Model", modelControl.ComboBox);
            modelControl.ComboBox.Tag = "Model";
            controls.Add("CreatedYearFrom", createdYearFromControl.ComboBox);
            createdYearFromControl.ComboBox.Tag = "Godište od";
            controls.Add("CreatedYearTo", createdYearToControl.ComboBox);
            createdYearToControl.ComboBox.Tag = "Godište do";
            controls.Add("CubicCapacityFrom", cubicCapacityFromControl.ComboBox);
            cubicCapacityFromControl.ComboBox.Tag = "Kubikaža od";
            controls.Add("CubicCapacityTo", cubicCapacityToControl.ComboBox);
            cubicCapacityToControl.ComboBox.Tag = "Kubikaža od";
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

        public event EventHandler BrandPickedTriggered;
        public event EventHandler FindCarsTriggered;
        public event EventHandler LoadedTrigger;

        public string Brand { get => brandControl.SelectedItem as string; set => brandControl.SelectedItem = value; }
        public string Model { get => modelControl.SelectedItem as string; set => modelControl.SelectedItem = value; }
        public string DriveType { get => driveTypeControl.SelectedItem as string; set => driveTypeControl.SelectedItem = value; }
        public string ShiftType { get => shiftTypeControl.SelectedItem as string; set => shiftTypeControl.SelectedItem = value; }
        public string CarBody   { get => carBodyControl.SelectedItem as string; set => carBodyControl.SelectedItem = value; }
        public string FuelType  { get => fuelTypeControl.SelectedItem as string; set => fuelTypeControl.SelectedItem = value; }
        public string DorCount  { get => dorCountControl.SelectedItem as string; set => dorCountControl.SelectedItem = value; }

        public string CreatedYearFrom
        {
            get => createdYearFromControl.SelectedItem as string;
            set => createdYearFromControl.SelectedItem = value;
        }
        public string CreatedYearTo { get => createdYearToControl.SelectedItem as string; set => createdYearToControl.SelectedItem = value; }
        public string CubicCapacityFrom { get => cubicCapacityFromControl.SelectedItem as string; set => cubicCapacityFromControl.SelectedItem = value; }
        public string CubicCapacityTo { get => cubicCapacityToControl.SelectedItem as string; set => cubicCapacityToControl.SelectedItem = value; }
        
        // DataSources
        public object BrandDataSource { get => brandControl.ComboBox.DataSource; set => brandControl.ComboBox.DataSource = value; }
        public object ModelDataSource { get => modelControl.ComboBox.DataSource; set => modelControl.ComboBox.DataSource = value; }
        public object DriveTypeDataSource { get => driveTypeControl.ComboBox.DataSource; set => driveTypeControl.ComboBox.DataSource = value; }
        public object ShiftTypeDataSource { get => shiftTypeControl.ComboBox.DataSource; set => shiftTypeControl.ComboBox.DataSource = value; }
        public object CarBodyDataSource { get => carBodyControl.ComboBox.DataSource; set => carBodyControl.ComboBox.DataSource = value; }
        public object FuelTypeDataSource { get => fuelTypeControl.ComboBox.DataSource; set => fuelTypeControl.ComboBox.DataSource = value; }
        public object DorCountDataSource { get => dorCountControl.ComboBox.DataSource; set => dorCountControl.ComboBox.DataSource = value; }

        public object CreatedYearFromDataSource   { get => createdYearFromControl.ComboBox.DataSource; set => createdYearFromControl.ComboBox.DataSource = value; }
        public object CreatedYearToDataSource     { get => createdYearToControl.ComboBox.DataSource; set => createdYearToControl.ComboBox.DataSource = value; }
        public object CubicCapacityFromDataSource { get => cubicCapacityFromControl.ComboBox.DataSource; set => cubicCapacityFromControl.ComboBox.DataSource = value; }
        public object CubicCapacityToDataSource   { get => cubicCapacityToControl.ComboBox.DataSource; set => cubicCapacityToControl.ComboBox.DataSource = value; }

        public object Presenter { private get; set; }
       

        public void ClearAllControls()
        {
            foreach (string key in controls.Keys)
            {
                (controls[key] as ComboBox).SelectedIndex = -1;
            }
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
                control.Focus();
            }
        }

        // EventHandlers
        private void CarFilterView_Load(object sender, EventArgs e)
        {
            LoadedTrigger?.Invoke(this, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindCarsTriggered?.Invoke(this, e);
        }

        private void brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            BrandPickedTriggered?.Invoke(this, e);
        }
    }
}
