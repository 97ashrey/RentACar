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
    public class OffersDataPresenter
    {
        IOffersDataView view;
        IEventAggregator eventAggregator;

        List<CarModel> carsDataSource = new List<CarModel>();

        private SelectedRecordMessage<OfferModel> selectedOffer;

        public OffersDataPresenter(IOffersDataView view, IEventAggregator eventAggregator)
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
            view.NewOfferTrigger += NewTriggerHandler;
            view.SaveOfferTrigger += SaveTriggerHandler;
            view.UpdateOfferTrigger += UpdateTriggerHandler;
            view.DeleteOfferTrigger += DeleteTriggerHandler;
            view.CancleTrigger += CancelTriggerHandler;
            view.CarSelectedTrigger += CarSelectedHandler;
          
        }

        private void SetCarsSource()
        {
            carsDataSource = RentACarLibrary.GlobalConfig.CarModelConection.GetAll().ToList();
            view.CarIDsDisplayMember = "CarName";
            view.CarIDsValueMemeber = "ID";
            view.CarIDsDataSource = carsDataSource;
        }

        private void PopulateView(OfferModel offer)
        {
            CarModel car = carsDataSource.Find(model => model.ID == offer.CarID);
            view.Car = car;
            view.From = offer.From;
            view.To = offer.To;
            view.PricePerDay = offer.PricePerDay;
        }

        private void PopulateOffer(OfferModel offer)
        {
            offer.CarID = (view.Car as CarModel).ID;
            offer.From = view.From;
            offer.To = view.To;
            offer.PricePerDay = view.PricePerDay;
        }

        private void SetStateDefault()
        {
            eventAggregator.Publish(new ToDefaultStateMessage());
            selectedOffer = null;
            view.ClearAllControls();
            view.AllInputsEnabled = false;
            view.NewOfferTriggerEnabled = true;
            view.SaveOfferTriggerEnabled = false;
            view.UpdateOfferTriggerEnabled = false;
            view.DeleteOfferTriggerEnabled = true;
            eventAggregator.Subscribe<ToUpdateStateMessage>(ToUpdateStateMessageHandler);
            eventAggregator.Unsubscribe<SelectedRecordMessage<OfferModel>>(RecordSelectedHandler);
        }

        private void SetStateUpdate()
        {
            view.AllInputsEnabled = true;
            view.NewOfferTriggerEnabled = false;
            view.SaveOfferTriggerEnabled = false;
            view.UpdateOfferTriggerEnabled = true;
            view.DeleteOfferTriggerEnabled = false;
            eventAggregator.Unsubscribe<ToUpdateStateMessage>(ToUpdateStateMessageHandler);
            eventAggregator.Subscribe<SelectedRecordMessage<OfferModel>>(RecordSelectedHandler);
        }

        private void SetStateNew()
        {
            eventAggregator.Publish(new ToNewStateMessage());
            selectedOffer = null;
            view.ClearAllControls();
            view.AllInputsEnabled = true;
            view.NewOfferTriggerEnabled = false;
            view.SaveOfferTriggerEnabled = true;
            view.UpdateOfferTriggerEnabled = false;
            view.DeleteOfferTriggerEnabled = false;
        }

        private void UpdateResult(CrudOperationMessage.CrudResult result)
        {
            AlertMessage message;
            switch (result)
            {
                case CrudOperationMessage.CrudResult.Error:
                    message = new AlertMessage(
                        AlertMessage.MessageType.Error,
                        Messages.ERROR_OFFER_UPDATE
                        );
                    break;
                default:
                    message = new AlertMessage(
                     AlertMessage.MessageType.Success,
                     Messages.MESSAGE_OFFER_UPDATE
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
                        Messages.ERROR_OFFER_CREATE
                        );
                    break;
                default:
                    message = new AlertMessage(
                     AlertMessage.MessageType.Success,
                     Messages.MESSAGE_OFFER_CREATE
                     );
                    view.ClearAllControls();
                    break;
            }
            view.ShowAlertMessage(message);
        }

        // Event Handlers
        private void LoadHandler(object sender, EventArgs e)
        {
            SetCarsSource();
            SetStateDefault();
        }

        private void RecordSelectedHandler(SelectedRecordMessage<OfferModel> message)
        {
            selectedOffer = message;
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
            // Create a new Offer object and send it to be created
            OfferModel Offer = new OfferModel();
            PopulateOffer(Offer);
            AddRecordMessage<OfferModel> message = new AddRecordMessage<OfferModel>(Offer);
            eventAggregator.Publish(message);
        }

        private void UpdateTriggerHandler(object sender, EventArgs e)
        {
            OfferModel Offer = selectedOffer.Record;
            PopulateOffer(Offer);

            UpdateRecordMessage<OfferModel> updateMessage =
                new UpdateRecordMessage<OfferModel>(Offer, selectedOffer.Index);
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
            // This presenter only Offeres about the update operation
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
            if(view.Car == null)
            {
                view.CarInfo = "";
                return;
            }
            CarModel car = view.Car as CarModel;
            view.CarInfo = car.CarInfo();
        }
    }
}
