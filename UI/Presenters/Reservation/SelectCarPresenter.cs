using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Events;
using UI.Events.Messages;
using UI.Views.Reservation;
using RentACarLibrary.Models;

namespace UI.Presenters.Reservation
{
    public class SelectCarPresenter
    {
        private ISelectCarView view;
        private IEventAggregator eventAggregator;

        public SelectCarPresenter(ISelectCarView view, IEventAggregator eventAggregator)
        {
            this.view = view;
            this.eventAggregator = eventAggregator;
            SubscribeToEvents();
            view.CarsDisplayMember = "CarName";
        }

        private void SubscribeToEvents()
        {
            view.CarPickedTriggered += CarPickedHandler;
            eventAggregator.Subscribe<CarsFoundMessage>(CarsFoundHandler);
        }

        private void SetCarsDataSource(CarModel[] cars)
        {
            view.CarsDataSource = cars.ToList();
            if(cars.Length == 0)
            {
                view.CarInfo = "";
            }
        }

        // Event Handler
        private void CarPickedHandler(object sender, EventArgs e)
        {
            CarModel car = view.SelectedCar as CarModel;
            if(car == null)
            {
                view.CarInfo = "";
                return;
            }

            view.CarInfo = car.CarInfo();
        }

        private void CarsFoundHandler(CarsFoundMessage message)
        {
            SetCarsDataSource(message.cars);
        }
    }
}
