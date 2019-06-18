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
    public partial class CreateReservationView : UserControl, ICreateReservationView
    {
        public CreateReservationView()
        {
            InitializeComponent();

            priceControl.TextBox.Decimals = true;
            priceControl.TextBox.ReadOnly = true;


            dateFromControl.DateTimePicker.ValueChanged += DatePickedHandler;
            dateToControl.DateTimePicker.ValueChanged += DatePickedHandler;

            NameControls();
        }

        private Dictionary<string, Control> controls = new Dictionary<string, Control>();

        private void NameControls()
        {
            dateFromControl.DateTimePicker.Tag = "DateFrom";
            controls.Add("DateFrom", dateFromControl.DateTimePicker);
            dateToControl.DateTimePicker.Tag = "DateTo";
            controls.Add("DateTo", dateToControl.DateTimePicker);
            priceControl.TextBox.Tag = "Price";
            controls.Add("Price", priceControl);
        }

        public DateTime DateFrom { get => dateFromControl.Date; set => dateFromControl.Date = value; }
        public DateTime DateTo { get => dateToControl.Date; set => dateToControl.Date = value; }
        public double Price
        {
            get => double.Parse(priceControl.InputText);
            set => priceControl.InputText = value.ToString();
        }

        public object Presenter { private get; set; }

        public object PeriodsDataSource
        {
            get => lbPeriods.DataSource;
            set => lbPeriods.DataSource = value;
        }

        public event EventHandler DatePickedTriggered;
        public event EventHandler CreateReservationTriggered;

        // Event handlers

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateReservationTriggered?.Invoke(this, e);
        }

        private void DatePickedHandler(object sender, EventArgs e)
        {
            DatePickedTriggered?.Invoke(this, e);
        }

    }
}
