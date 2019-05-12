using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Views.Data;
using UI.Presenters.Data;
using UI.Events;

namespace UI.Views.User
{
    public partial class AdminView : UserView
    {
        private Control customersDataView;
        private Control carsDataView;
        private Control offersDataView;
        private Control reservationsDataView;
        private Control statisticsView;

        protected AdminView()
        {
            InitializeComponent();
            btnCustomers.Click += BtnCustomers_Click;
            btnCars.Click += BtnCars_Click;
            btnOffers.Click += BtnOffers_Click;
            btnReservations.Click += BtnReservations_Click;
            btnStatistics.Click += BtnStatistics_Click;
        }



        public AdminView(
            Control customersDataView, 
            Control carsDataView, 
            Control offersDataView, 
            Control reservationsDataview,
            Control statisticsView): this()
        {
            this.customersDataView = customersDataView;
            this.customersDataView.Dock = DockStyle.Fill;
            this.carsDataView = carsDataView;
            this.carsDataView.Dock = DockStyle.Fill;
            this.offersDataView = offersDataView;
            this.offersDataView.Dock = DockStyle.Fill;
            this.reservationsDataView = reservationsDataview;
            this.reservationsDataView.Dock = DockStyle.Fill;
            this.statisticsView = statisticsView;
            this.statisticsView.Dock = DockStyle.Fill;
            //ShowCustomersDataView();
            //ShowCarsDataView();
            //ShowOffersDataView();
            //ShowReservationsDataView();
            ShowStatisticsView();
        }

        public void ShowCustomersDataView()
        {
            ShowControl(customersDataView);
        }

        public void ShowCarsDataView()
        {
            ShowControl(carsDataView);
        }

        public void ShowOffersDataView()
        {
            ShowControl(offersDataView);
        }

        public void ShowReservationsDataView()
        {
            ShowControl(reservationsDataView);
        }

        public void ShowStatisticsView()
        {
            ShowControl(statisticsView);
        }

        // Event handlers
        private void BtnStatistics_Click(object sender, EventArgs e)
        {
            ShowStatisticsView();
        }

        private void BtnReservations_Click(object sender, EventArgs e)
        {
            ShowReservationsDataView();
        }

        private void BtnOffers_Click(object sender, EventArgs e)
        {
            ShowOffersDataView();
        }

        private void BtnCars_Click(object sender, EventArgs e)
        {
            ShowCarsDataView();
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            ShowCustomersDataView();
        }
    }
}
