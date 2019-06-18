using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Presenters.Login;
using UI.Presenters.Data;
using UI.Presenters.Statistics;
using UI.Presenters.Reservation;
using UI.Views.Login;
using UI.Views.User;
using UI.Views.Data;
using UI.Views.Reservation;
using UI.Views.Statistics;
using UI.Events;
using RentACarLibrary.Models;

namespace UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RentACarLibrary.GlobalConfig.GenerateStorageDirectories();
            RentACarLibrary.GlobalConfig.InitializeDataConection();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartApplication();

            //Application.Run(CreateAdminView());
            //Application.Run(CreateCustomerView());
            //Application.Run(new UI.Views.TestForm());
        }

        private static void StartApplication()
        {
            

            LoginView loginView = new LoginView();
            LoginPresenter loginPresenter = new LoginPresenter(loginView);
            loginView.Presenter = loginPresenter;

            while (true)
            {
                DialogResult result = loginView.ShowDialog();
                if (result != DialogResult.OK)
                {
                    break;
                }

                UserView userView;
                if (RentACarLibrary.SessionData.IsAdmin())
                {
                    userView = CreateAdminView();
                }
                else
                {
                    userView = CreateCustomerView();
                }
                Application.Run(userView);
            }
        }

        private static AdminView CreateAdminView()
        {
            // Customer view
            CustomersDataView customersDataView = CreateCustomersDataView();
            CarsDataView carsDataView = CreateCarsDataView();
            OffersDataView offersDataView = CreateOffersDataView();
            ReservationsDataView reservationsDataView = CreateReservationsDataView();
            StatisticsView statisticsView = CreateStatisticsView();
            AdminView adminView = new AdminView(
                customersDataView, 
                carsDataView, 
                offersDataView, 
                reservationsDataView,
                statisticsView);

            return adminView;
        }

        private static CustomersDataView CreateCustomersDataView()
        {
            EventAggregator customerViewEventAggregator = new EventAggregator();
            TableView customerTableView = new TableView();
            customerTableView.Presenter = new CustomersTablePresenter(customerTableView, customerViewEventAggregator);
            CustomersDataView customersDataView = new CustomersDataView(customerTableView);
            customersDataView.Presenter = new CustomersDataPresenter(customersDataView, customerViewEventAggregator);

            return customersDataView;
        }

        private static CarsDataView CreateCarsDataView()
        {
            EventAggregator carsViewEventAggregator = new EventAggregator();
            TableView carsTableView = new TableView();
            carsTableView.Presenter = new CarsTablePresenter(carsTableView, carsViewEventAggregator);
            CarsDataView carsDataView = new CarsDataView(carsTableView);
            carsDataView.Presenter = new CarsDataPresenter(carsDataView, carsViewEventAggregator);
            return carsDataView;
        }

        private static OffersDataView CreateOffersDataView()
        {
            EventAggregator offersViewEventAggregator = new EventAggregator();
            TableView offersTableView = new TableView();
            offersTableView.Presenter = new OffersTablePresenter(offersTableView, offersViewEventAggregator);
            OffersDataView offersDataView = new OffersDataView(offersTableView);
            offersDataView.Presenter = new OffersDataPresenter(offersDataView, offersViewEventAggregator);
            return offersDataView;
        }

        private static ReservationsDataView CreateReservationsDataView()
        {
            EventAggregator reservationsViewEventAggregator = new EventAggregator();
            TableView reservationsTableView = new TableView();
            reservationsTableView.Presenter = new ReservationsTablePresenter(reservationsTableView, reservationsViewEventAggregator);
            ReservationsDataView reservationsDataView = new ReservationsDataView(reservationsTableView);
            reservationsDataView.Presenter = new ReservationsDataPresenter(reservationsDataView, reservationsViewEventAggregator);
            return reservationsDataView;
        }

        private static StatisticsView CreateStatisticsView()
        {
            StatisticsView statisticsView = new StatisticsView();
            statisticsView.Presenter = new StatisticsPresenter(statisticsView);
            return statisticsView;
        }

        private static CustomerView CreateCustomerView()
        {
            CustomerReservationsDataView customerReservationsDataView = CreateCustomerReservationsDataView();
            MakeReservationView makeReservationView = CreateMakeReservationView();
            CustomerView customerView = new CustomerView(customerReservationsDataView, makeReservationView);
            return customerView;
        }

        private static CustomerReservationsDataView CreateCustomerReservationsDataView()
        {
            IEventAggregator ea = new EventAggregator();
            TableView reservationsTable = new TableView();
            reservationsTable.Presenter = new CustomerReservationsTablePresenter(
                    reservationsTable,
                    ea
                );
            CustomerReservationsDataView customerReservationsDataView = 
                new CustomerReservationsDataView(reservationsTable);
            customerReservationsDataView.Presenter = new CustomerResevationsDataPresenter(
                    customerReservationsDataView,
                    ea
                );
            return customerReservationsDataView;
        }

        private static MakeReservationView CreateMakeReservationView()
        {
            IEventAggregator eventAggregator = new EventAggregator();
            CarFilterView carFilterView = new CarFilterView();
            carFilterView.Presenter = new CarFilterPresenter(carFilterView, eventAggregator);
            SelectCarView selectCarView = new SelectCarView();
            selectCarView.Presenter = new SelectCarPresenter(selectCarView, eventAggregator);
            CreateReservationView createReservationView = new CreateReservationView();
            createReservationView.Presenter = new CreateReservationPresenter(createReservationView, eventAggregator);

            MakeReservationView makeReservationView = new MakeReservationView(
                carFilterView,
                selectCarView,
                createReservationView
                );
            makeReservationView.Presenter = new MakeReservationPresenter(
                    makeReservationView,
                    eventAggregator);

            return makeReservationView;
        }
    }
}
