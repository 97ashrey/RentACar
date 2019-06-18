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
    public partial class CustomerReservationsDataView : UserControl, ICustomerReservationsDataView
    {
        private Control table;

        public object Presenter { private get; set; }
        public string CarInfo { get => lblCarInfo.Text; set => lblCarInfo.Text = value; }

        public event EventHandler CancleReservationTriggered;

        protected CustomerReservationsDataView()
        {
            InitializeComponent();

            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            CancleReservationTriggered?.Invoke(this, e);
        }

        public void ShowAlertMessage(AlertMessage alertMessage)
        {
            alert.Display(alertMessage);
        }

        public CustomerReservationsDataView(Control table) : this()
        {
            this.table = table;
            this.table.Dock = DockStyle.Fill;
            this.splitContainer.Panel1.Controls.Add(this.table);
        }
    }
}
