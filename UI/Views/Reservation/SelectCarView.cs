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
    public partial class SelectCarView : UserControl, ISelectCarView
    {
        public SelectCarView()
        {
            InitializeComponent();
            carControl.ComboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }
       
        public event EventHandler CarPickedTriggered;

        public string CarInfo { get => lblCarInfo.Text; set => lblCarInfo.Text = value; }
        public object SelectedCar { get => carControl.SelectedItem; set => carControl.SelectedItem = value; }
        public object CarsDataSource { get => carControl.ComboBox.DataSource;  set => carControl.ComboBox.DataSource = value; }
        public string CarsDisplayMember { get => carControl.ComboBox.DisplayMember; set => carControl.ComboBox.DisplayMember = value; }

        public object Presenter { private get; set; }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarPickedTriggered?.Invoke(this, e);
        }
    }
}
