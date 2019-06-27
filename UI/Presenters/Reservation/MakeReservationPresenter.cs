using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Reservation;
using UI.Events;
using UI.Events.Messages;

namespace UI.Presenters.Reservation
{
    public class MakeReservationPresenter
    {
        private IMakeReservationView view;
        private IEventAggregator eventAggregator;

        public MakeReservationPresenter(IMakeReservationView view, IEventAggregator eventAggregator)
        {
            this.view = view;
            this.eventAggregator = eventAggregator;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            eventAggregator.Subscribe<AlertMessage>(AlertMessageHandler);
            view.LoadedTrigger += View_LoadedTrigger;
        }

        private void View_LoadedTrigger(object sender, EventArgs e)
        {
            eventAggregator.Publish(new ResetViewMessage());
        }

        private void AlertMessageHandler(AlertMessage message)
        {
            view.ShowAlertMessage(message);
        }
    }
}
