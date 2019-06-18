using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Views.User
{
    public partial class CustomerView : UserView
    {
        private Control customerReservationsView;
        private Control makeNewReservationView;

        protected CustomerView()
        {
            InitializeComponent();

            btnReservations.Click += BtnReservationsClickHandler;
            btnMakeReservation.Click += BtnMakeNewClickHandler;
        }

        public CustomerView(Control customerReservationsView, Control makeNewReservationView) : this()
        {
            this.customerReservationsView = customerReservationsView;
            this.customerReservationsView.Dock = DockStyle.Fill;
            this.makeNewReservationView = makeNewReservationView;
            this.makeNewReservationView.Dock = DockStyle.Fill;
            ShowCustomerReservationsView();
        }

        private void ShowCustomerReservationsView()
        {
            ShowControl(customerReservationsView);
            btnReservations.Select();
        }

        private void ShowMakeNewReservationView()
        {
            ShowControl(makeNewReservationView);
            btnMakeReservation.Select();
        }

        private void BtnReservationsClickHandler(object sender, EventArgs e)
        {
            ShowCustomerReservationsView();
        }

        private void BtnMakeNewClickHandler(object sender, EventArgs e)
        {
            ShowMakeNewReservationView();
        }
    }
}
