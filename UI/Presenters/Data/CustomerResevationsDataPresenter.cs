using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UI.Events;
using UI.Events.Messages;
using UI.Views.Data;
using RentACarLibrary.Models;

namespace UI.Presenters.Data
{
    public class CustomerResevationsDataPresenter
    {
        private ICustomerReservationsDataView view;
        private IEventAggregator eventAggregator;

        public CustomerResevationsDataPresenter(ICustomerReservationsDataView view, IEventAggregator eventAggregator)
        {
            this.view = view;
            this.eventAggregator = eventAggregator;
            SubscribeToEvents();
            view.CarInfo = "";
        }

        private void SubscribeToEvents()
        {
            view.CancleReservationTriggered += CancleReservationHandler;
            eventAggregator.Subscribe<SelectedRecordMessage<CarModel>>(RecordSelectedHandler);
            eventAggregator.Subscribe<CrudOperationMessage>(CrudOperationMessageHandler);
        }

        private void DeleteOperation(CrudOperationMessage.CrudResult result)
        {
            switch (result)
            {
                case CrudOperationMessage.CrudResult.Success:
                    view.CarInfo = "";
                    break;
                default:
                    break;
            }
        }

        // Event Handlers
        private void CancleReservationHandler(object sender, EventArgs e)
        {
            eventAggregator.Publish(new DeleteSelectedRecordsMessage());
        }

        private void RecordSelectedHandler(SelectedRecordMessage<CarModel> message)
        {
            view.CarInfo = message.Record.CarInfo();
        }

        private void CrudOperationMessageHandler(CrudOperationMessage message)
        {
            switch (message.Operation)
            {
                case CrudOperationMessage.CrudOperation.Delete:
                    DeleteOperation(message.Result);
                    break;
                default:
                    break;
            }
        }
    }
}
