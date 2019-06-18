using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Helpers;
using UI.Views.Data;
using UI.Events;
using UI.Events.Messages;
using RentACarLibrary.Models;

namespace UI.Presenters.Data
{
    public class OffersDataPresenter
    {
        IOffersDataView view;
        IEventAggregator eventAggregator;

        private enum ViewState
        {
            Default,
            New,
            Update
        }

        private ViewState state = ViewState.Default;

        List<CarModel> carsDataSource = new List<CarModel>();

        private SelectedRecordMessage<OfferModel> selectedOffer;

        private TimePeriod[] freePeriods;

        private TimePeriod leftRange;
        private TimePeriod rightRange;

        private bool SubscribedToUpdateStateTrigger = false;

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
            offer.From = view.From.Date;
            offer.To = view.To.Date;
            offer.PricePerDay = view.PricePerDay;
        }


        private void SubscribeToUpdateStateTrigger()
        {
            if (!SubscribedToUpdateStateTrigger)
            {
                eventAggregator.Subscribe<ToUpdateStateMessage>(ToUpdateStateMessageHandler);
                SubscribedToUpdateStateTrigger = true;
            }
        }

        private void UnSubscribeToUpdateStateTrigger()
        {
            if (SubscribedToUpdateStateTrigger)
            {
                eventAggregator.Unsubscribe<ToUpdateStateMessage>(ToUpdateStateMessageHandler);
                SubscribedToUpdateStateTrigger = false;
            }
        
        }

        private void SetStateDefault()
        {
            state = ViewState.Default;
            eventAggregator.Publish(new ToDefaultStateMessage());
            selectedOffer = null;
            freePeriods = null;
            leftRange = null;
            rightRange = null;
            view.ClearAllControls();
            view.ClearAllControlErrors();
            view.AllInputsEnabled = false;
            view.NewOfferTriggerEnabled = true;
            view.SaveOfferTriggerEnabled = false;
            view.UpdateOfferTriggerEnabled = false;
            view.DeleteOfferTriggerEnabled = true;
            SubscribeToUpdateStateTrigger();
            eventAggregator.Unsubscribe<SelectedRecordMessage<OfferModel>>(RecordSelectedHandler);

        }

        private void SetStateUpdate()
        {
            state = ViewState.Update;
            //view.AllInputsEnabled = true;
            view.NewOfferTriggerEnabled = false;
            view.SaveOfferTriggerEnabled = false;
            view.UpdateOfferTriggerEnabled = true;
            view.DeleteOfferTriggerEnabled = false;
            UnSubscribeToUpdateStateTrigger();
            eventAggregator.Subscribe<SelectedRecordMessage<OfferModel>>(RecordSelectedHandler);
        }

        private void SetStateNew()
        {
            state = ViewState.New;
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

        private void FindFreePeriods(int carId)
        {
            TimePeriod[] offerPeriods = RentACarLibrary.GlobalConfig.OfferModelConection
                .Filter(model => model.CarID == carId)
                .Select(model => new TimePeriod(model.From, model.To))
                .OrderBy(period => period.Start)
                .ToArray();

            if (offerPeriods.Length == 0)
            {
                freePeriods = new TimePeriod[]
                {
                    new TimePeriod(DateTime.Today, DateTime.MaxValue)
                };
            }
            else { 
                TimePeriod range = new TimePeriod(DateTime.Today, DateTime.MaxValue);
                freePeriods = TimePeriod.GetFreePeriods(range, offerPeriods);
            }

        }

        private void DisplayFreePeriods()
        {
            List<string> output;
            output = freePeriods
                .Select(period => {
                    string from = period.Start.ToShortDateString();
                    string to = period.End == DateTime.MaxValue.Date ? "daljnjeg" : period.End.ToShortDateString();
                    return $"Od {from} do {to}";
                }).ToList();
            view.FreePeriodDisplayDataSource = output;
        }

        private void SetUpdateControlLimits()
        {
            TimePeriod offerPeriod = new TimePeriod(selectedOffer.Record.From, selectedOffer.Record.To);
            
            // Enable apropriate controls
            if (offerPeriod.IsBefore(DateTime.Today))
            {
                view.AllInputsEnabled = false;
                leftRange = null;
                rightRange = null;
                return;
            }
            else
            {
                view.AllInputsEnabled = true;
            }

            // find reservations for this offer period
            TimePeriod[] reservationPeriods = RentACarLibrary.GlobalConfig.ReservationModelConection
                .Filter(model => model.CarID == (view.Car as CarModel).ID)
                .Select(model => new TimePeriod(model.From, model.To))
                .Where(period => offerPeriod.IntersectsWith(period))
                .OrderBy(period => period.Start)
                .ToArray();

            if (reservationPeriods.Length > 0)
            {
                view.CarIDInputEnabled = false;
                view.PricePerDayInputEnabled = false;
            }
        }

        private void FindUpdateLimits()
        {
            TimePeriod offerPeriod = new TimePeriod(selectedOffer.Record.From, selectedOffer.Record.To);

            if (offerPeriod.IsBefore(DateTime.Today))
            {
                leftRange = null;
                rightRange = null;
                return;
            }

            // find reservations for this offer period
            TimePeriod[] reservationPeriods = RentACarLibrary.GlobalConfig.ReservationModelConection
                .Filter(model => model.CarID == (view.Car as CarModel).ID)
                .Select(model => new TimePeriod(model.From, model.To))
                .Where(period => offerPeriod.IntersectsWith(period))
                .OrderBy(period => period.Start)
                .ToArray();

            // find range limits
            TimePeriod[] offerPeriods = RentACarLibrary.GlobalConfig.OfferModelConection
                      .Filter(model => model.CarID == selectedOffer.Record.CarID)
                      .Select(model => new TimePeriod(model.From, model.To))
                      .OrderBy(period => period.Start)
                      .ToArray();

            // Find outer limits
            DateTime leftOuterLimit = (offerPeriod.Start < DateTime.Today) ? offerPeriod.Start : DateTime.Today;
            DateTime rightOuterLimit = DateTime.MaxValue;
            for (int i = 0; i < offerPeriods.Length; i++)
            {
                TimePeriod period = offerPeriods[i];
                if (period.IsExactMatch(offerPeriod))
                {
                    // offer before
                    try
                    {
                        if (!offerPeriods[i - 1].IsBefore(DateTime.Today))
                        {
                            leftOuterLimit = offerPeriods[i - 1].End.AddDays(1);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                    // offer after
                    try
                    {
                        rightOuterLimit = offerPeriods[i + 1].Start.AddDays(-1);
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                    break;
                }
            }

            // Find Inner limits
            // asumption that offer has no active reservations
            DateTime leftInnerLimit = rightOuterLimit;
            DateTime rightInnerLimit = leftOuterLimit;
            // then check against that asumption
            if (reservationPeriods.Length > 0)
            {
                TimePeriod first = reservationPeriods.First();
                TimePeriod last = reservationPeriods.Last();
                leftInnerLimit = first.Start < DateTime.Today ? offerPeriod.Start : first.Start;
                rightInnerLimit = last.End;
                if (offerPeriod.StartsInside(first))
                {
                    leftInnerLimit = offerPeriod.Start;
                }
                if (offerPeriod.EndsInside(last))
                {
                    rightInnerLimit = offerPeriod.End;
                }
            }

            leftRange = new TimePeriod(leftOuterLimit, leftInnerLimit);
            rightRange = new TimePeriod(rightInnerLimit, rightOuterLimit);
        }

        private void DisplayUpdateLimits()
        {
            if(leftRange == null || rightRange == null)
            {
                view.FreePeriodDisplayDataSource = null;
                return;
            }
            string left = $"Granica 'od' može da se menja od {leftRange.Start.ToShortDateString()} do {leftRange.End.ToShortDateString()}";
            string right = $"Granica 'do' može da se menja od {rightRange.Start.ToShortDateString()} do {rightRange.End.ToShortDateString()}";
            List<string> output = new List<string>();
            output.Add(left);
            output.Add(right);
            view.FreePeriodDisplayDataSource = output;
        }

        // validations

        private bool ValidatePriceField()
        {
            bool valid = true;

            if (view.PricePerDay == 0)
            {
                view.SetControlError("PricePerDay", Messages.ErrorRequiredField("Cena"));
                valid = false;
            }

            return valid;
        }

        private bool ValidateCarField()
        {
            bool valid = true;

            if (view.Car == null)
            {
                view.SetControlError("CarID", Messages.ErrorRequiredField("Automobil"));
                valid = false;
            }

            return valid;
        }

        private bool ValidateNewOfferPeriod()
        {
            bool valid = false;
            // check if picked dates are in free periods
            try
            {
                TimePeriod pickedPeriod = new TimePeriod(view.From, view.To);
                foreach (TimePeriod period in freePeriods)
                {
                    if (period.HasInside(pickedPeriod))
                    {
                        valid = true;
                        break;
                    }
                }
            }
            catch (ArgumentException)
            {
                valid = false;
            }
            
            return valid;
        }

        private bool ValidateUpdateOfferDate()
        {
            bool valid = true;
            if (!leftRange.HasInside(view.From.Date))
            {
                valid = false;
            }
            if (!rightRange.HasInside(view.To.Date))
            {
                valid = false;
            }
            return valid;
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
            view.ClearAllControls();
            PopulateView(message.Record);
            SetUpdateControlLimits();
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
            // TODO Date Validations for saving
            bool priceValid = ValidatePriceField();
            bool carValid = ValidateCarField();
            if (!priceValid || !carValid)
            {
                view.ShowAlertMessage(
                    new AlertMessage(AlertMessage.MessageType.Error, Messages.ERROR_FORM_FILL));
                return;
            }
            if (!ValidateNewOfferPeriod())
            {
                view.ShowAlertMessage(
                    new AlertMessage(AlertMessage.MessageType.Error, "Nema tog slobodnog termina"));
                return;
            }
            OfferModel Offer = new OfferModel();
            PopulateOffer(Offer);
            AddRecordMessage<OfferModel> message = new AddRecordMessage<OfferModel>(Offer);
            eventAggregator.Publish(message);
            SetStateDefault();
        }

        private void UpdateTriggerHandler(object sender, EventArgs e)
        {
            bool priceValid = ValidatePriceField();
            bool carValid = ValidateCarField();
            if (!priceValid || !carValid)
            {
                view.ShowAlertMessage(
                    new AlertMessage(AlertMessage.MessageType.Error, Messages.ERROR_FORM_FILL));
                return;
            }
            // Do date validations
            int carId = (view.Car as CarModel).ID;
            // If the car for the offer wasn't changed
            if(carId == selectedOffer.Record.CarID)
            {   
                // Do update offer date validation
                if (!ValidateUpdateOfferDate())
                {
                    view.ShowAlertMessage(
                        new AlertMessage(AlertMessage.MessageType.Error, Messages.ERROR_NO_TIME_PERIOD));
                    return;
                }
            }
            else
            {   
                // Do new offer date validation
                if (!ValidateNewOfferPeriod())
                {
                    view.ShowAlertMessage(
                        new AlertMessage(AlertMessage.MessageType.Error, Messages.ERROR_NO_TIME_PERIOD));
                    return;
                }
            }

            OfferModel Offer = selectedOffer.Record;
            PopulateOffer(Offer);

            UpdateRecordMessage<OfferModel> updateMessage =
                new UpdateRecordMessage<OfferModel>(Offer, selectedOffer.Index);
            eventAggregator.Publish(updateMessage);

            SetStateDefault();
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
            // TODO Find free periods for the new offer
            if(state == ViewState.New)
            {
                FindFreePeriods(car.ID);
                DisplayFreePeriods();
            }
            else if(state == ViewState.Update)
            {
                if(selectedOffer.Record.CarID == car.ID)
                {
                    FindUpdateLimits();
                    DisplayUpdateLimits();
                }
                else
                {
                    FindFreePeriods(car.ID);
                    DisplayFreePeriods();
                }

            }

        }
    }
}
