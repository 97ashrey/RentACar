using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Data;
using UI.Events;
using UI.Events.Messages;
using RentACarLibrary.Models;
using System.Windows.Forms;

namespace UI.Presenters.Data
{
    public class ReservationsDataPresenter
    {
        IReservationsDataView view;
        IEventAggregator eventAggregator;

        List<CarModel> carsDataSource;
        List<CustomerModel> customersDataSource;

        private SelectedRecordMessage<ReservationModel> selectedReservation;

        public ReservationsDataPresenter(IReservationsDataView view, IEventAggregator eventAggregator)
        {
            this.view = view;
            this.eventAggregator = eventAggregator;
            SubsribeToEvents();
        }

        private void SubsribeToEvents()
        {
            eventAggregator.Subscribe<AlertMessage>(view.ShowAlertMessage);
            eventAggregator.Subscribe<CrudOperationMessage>(CrudOperationMessageHandler);
            view.LoadedTrigger += LoadHandler;
            view.NewReservationTrigger += NewTriggerHandler;
            view.SaveReservationTrigger += SaveTriggerHandler;
            view.UpdateReservationTrigger += UpdateTriggerHandler;
            view.DeleteReservationTrigger += DeleteTriggerHandler;
            view.CancleTrigger += CancelTriggerHandler;
            view.CarSelectedTrigger += CarSelectedHandler;
            view.CustomerSelectedTrigger += CustomerSelectedHandler;
        }

        private void SetCarSource()
        {
            carsDataSource = new List<CarModel>();
            carsDataSource = RentACarLibrary.GlobalConfig.CarModelConection.GetAll().ToList();
            view.CarDisplayMember = "CarName";
            view.CarDataSource = carsDataSource;
        }

        private void SetCustomerSource()
        {
            UserModel[] users = RentACarLibrary.GlobalConfig.UserModelConnection.Filter(
                    model => model is CustomerModel
                );
            customersDataSource = new List<CustomerModel>();
            foreach(UserModel user in users)
            {
                customersDataSource.Add(user as CustomerModel);
            }
            view.CustomerDisplayMember = "FullName";
            view.CustomerDataSource = customersDataSource;
        }

        private void PopulateView(ReservationModel reservation)
        {
            CustomerModel customer = customersDataSource.Find(model => model.ID == reservation.UserID);
            CarModel car = carsDataSource.Find(model => model.ID == reservation.CarID);
            view.Car = car;
            view.User = customer;
            view.From = reservation.From;
            view.To = reservation.To;
            view.Price = reservation.Price;
        }

        private void PopulateReservation(ReservationModel reservation)
        {
            reservation.CarID = (view.Car as CarModel).ID;
            reservation.UserID = (view.User as CustomerModel).ID;
            reservation.From = view.From;
            reservation.To = view.To;
            reservation.Price = view.Price;
        }

        private void SetStateDefault()
        {
            eventAggregator.Publish(new ToDefaultStateMessage());
            selectedReservation = null;
            view.ClearAllControls();
            view.AllInputsEnabled = false;
            view.NewReservationTriggerEnabled = true;
            view.SaveReservationTriggerEnabled = false;
            view.UpdateReservationTriggerEnabled = false;
            view.DeleteReservationTriggerEnabled = true;
            eventAggregator.Subscribe<ToUpdateStateMessage>(ToUpdateStateMessageHandler);
            eventAggregator.Unsubscribe<SelectedRecordMessage<ReservationModel>>(RecordSelectedHandler);
        }

        private void SetStateUpdate()
        {
            view.AllInputsEnabled = true;
            view.NewReservationTriggerEnabled = false;
            view.SaveReservationTriggerEnabled = false;
            view.UpdateReservationTriggerEnabled = true;
            view.DeleteReservationTriggerEnabled = false;
            eventAggregator.Unsubscribe<ToUpdateStateMessage>(ToUpdateStateMessageHandler);
            eventAggregator.Subscribe<SelectedRecordMessage<ReservationModel>>(RecordSelectedHandler);
        }

        private void SetStateNew()
        {
            eventAggregator.Publish(new ToNewStateMessage());
            selectedReservation = null;
            view.ClearAllControls();
            view.AllInputsEnabled = true;
            view.NewReservationTriggerEnabled = false;
            view.SaveReservationTriggerEnabled = true;
            view.UpdateReservationTriggerEnabled = false;
            view.DeleteReservationTriggerEnabled = false;
        }

        private void UpdateResult(CrudOperationMessage.CrudResult result)
        {
            AlertMessage message;
            switch (result)
            {
                case CrudOperationMessage.CrudResult.Error:
                    message = new AlertMessage(
                        AlertMessage.MessageType.Error,
                        Messages.ERROR_RESERVATION_UPDATE
                        );
                    break;
                default:
                    message = new AlertMessage(
                     AlertMessage.MessageType.Success,
                     Messages.MESSAGE_RESERVATION_UPDATE
                     );
                    break;
            }
            view.ShowAlertMessage(message);
        }

        private void CreateResult(CrudOperationMessage.CrudResult result)
        {
            AlertMessage message;
            switch (result)
            {
                case CrudOperationMessage.CrudResult.Error:
                    message = new AlertMessage(
                        AlertMessage.MessageType.Error,
                        Messages.ERROR_RESERVATION_CREATE
                        );
                    break;
                default:
                    message = new AlertMessage(
                     AlertMessage.MessageType.Success,
                     Messages.MESSAGE_RESERVATION_CREATE
                     );
                    view.ClearAllControls();
                    break;
            }
            view.ShowAlertMessage(message);
        }

        // Event Handlers
        private void LoadHandler(object sender, EventArgs e)
        {
            SetCarSource();
            SetCustomerSource();
            SetStateDefault();
        }

        private void RecordSelectedHandler(SelectedRecordMessage<ReservationModel> message)
        {
            selectedReservation = message;
            PopulateView(message.Record);
        }

        private void ToUpdateStateMessageHandler(ToUpdateStateMessage message)
        {
            SetStateUpdate();
        }

        private void NewTriggerHandler(object sender, EventArgs e)
        {
            SetStateNew();
        }

        private void SaveTriggerHandler(object sender, EventArgs e)
        {
            // Create a new Reservation object and send it to be created
            ReservationModel Reservation = new ReservationModel();
            PopulateReservation(Reservation);
            AddRecordMessage<ReservationModel> message = new AddRecordMessage<ReservationModel>(Reservation);
            eventAggregator.Publish(message);
        }

        private void UpdateTriggerHandler(object sender, EventArgs e)
        {
            ReservationModel Reservation = selectedReservation.Record;
            PopulateReservation(Reservation);

            UpdateRecordMessage<ReservationModel> updateMessage =
                new UpdateRecordMessage<ReservationModel>(Reservation, selectedReservation.Index);
            eventAggregator.Publish(updateMessage);
        }

        private void DeleteTriggerHandler(object sender, EventArgs e)
        {
            eventAggregator.Publish(new DeleteSelectedRecordsMessage());
        }

        private void CancelTriggerHandler(object sender, EventArgs e)
        {
            SetStateDefault();
        }

        private void CrudOperationMessageHandler(CrudOperationMessage message)
        {
            // This presenter only Reservationes about the update operation
            switch (message.Operation)
            {
                case CrudOperationMessage.CrudOperation.Update:
                    UpdateResult(message.Result);
                    break;
                case CrudOperationMessage.CrudOperation.Create:
                    CreateResult(message.Result);
                    break;
                default:
                    break;
            }
        }

        private void CarSelectedHandler(object sender, EventArgs e)
        {
            if (view.Car == null)
            {
                view.CarInfo = "";
                return;
            }
            CarModel car = view.Car as CarModel;
            view.CarInfo = car.CarInfo();
        }

        private void CustomerSelectedHandler(object sender, EventArgs e)
        {
            if (view.User == null)
            {
                view.UserInfo = "";
                return;
            }
            CustomerModel customer = view.User as CustomerModel;
            view.UserInfo = customer.FullName;
        }
    }
}
