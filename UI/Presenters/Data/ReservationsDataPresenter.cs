using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Data;
using UI.Events;
using UI.Events.Messages;
using UI.Helpers;
using RentACarLibrary.Models;
using System.Windows.Forms;

namespace UI.Presenters.Data
{
    public class ReservationsDataPresenter
    {
        IReservationsDataView view;
        IEventAggregator eventAggregator;

        private enum ViewState
        {
            Default,
            New,
            Update
        }

        private ViewState state = ViewState.Default;

        private TimePeriod[] freePeriods;
        private OfferModel[] offers;

        private TimePeriod outerRange;

        List<CarModel> carsDataSource;
        List<CustomerModel> customersDataSource;

        private SelectedRecordMessage<ReservationModel> selectedReservation;

        private bool subscribedToUpdateStateTrigger = false;

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
            view.DatePicked += DatePickedHandler;
        }
       
        private void SubscribeToUpdateStateTrigger()
        {
            if (!subscribedToUpdateStateTrigger)
            {
                eventAggregator.Subscribe<ToUpdateStateMessage>(ToUpdateStateMessageHandler);
                subscribedToUpdateStateTrigger = true;
            }
        }

        private void UnSubscribeFromUpdateStateTrigger()
        {
            if (subscribedToUpdateStateTrigger)
            {
                eventAggregator.Unsubscribe<ToUpdateStateMessage>(ToUpdateStateMessageHandler);
                subscribedToUpdateStateTrigger = false;
            }
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
            reservation.From = view.From.Date;
            reservation.To = view.To.Date;
            reservation.Price = view.Price;
        }

        private void SetStateDefault()
        {
            state = ViewState.Default;
            eventAggregator.Publish(new ToDefaultStateMessage());
            selectedReservation = null;
            freePeriods = null;
            offers = null;
            outerRange = null;
            view.ClearAllControls();
            view.ClearAllControlErrors();
            view.AllInputsEnabled = false;
            view.NewReservationTriggerEnabled = true;
            view.SaveReservationTriggerEnabled = false;
            view.UpdateReservationTriggerEnabled = false;
            view.DeleteReservationTriggerEnabled = true;
            SubscribeToUpdateStateTrigger();
            eventAggregator.Unsubscribe<SelectedRecordMessage<ReservationModel>>(RecordSelectedHandler);
        }

        private void SetStateUpdate()
        {
            state = ViewState.Update;
            //view.AllInputsEnabled = true;
            view.NewReservationTriggerEnabled = false;
            view.SaveReservationTriggerEnabled = false;
            view.UpdateReservationTriggerEnabled = true;
            view.DeleteReservationTriggerEnabled = false;
            UnSubscribeFromUpdateStateTrigger();
            eventAggregator.Subscribe<SelectedRecordMessage<ReservationModel>>(RecordSelectedHandler);
        }

        private void SetStateNew()
        {
            state = ViewState.New;
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

        private void FindFreePeriods(int carId)
        {
            offers = RentACarLibrary.GlobalConfig.OfferModelConection
                        .Filter(model => {
                            TimePeriod period = new TimePeriod(model.From, model.To);
                            return model.CarID == carId && (period.HasInside(DateTime.Today) || period.IsAfter(DateTime.Today));
                        })
                        .OrderBy(model => model.From)
                        .ToArray();

            if (offers.Length == 0)
            {
                freePeriods = null;
                return;
            }

            TimePeriod[] reservationPeriods = RentACarLibrary.GlobalConfig.ReservationModelConection
                .Filter(model => model.CarID == carId)
                .Select(model => new TimePeriod(model.From, model.To))
                .OrderBy(period => period.Start)
                .ToArray();

            TimePeriod firstOffer = new TimePeriod(offers.First().From, offers.First().To);
            TimePeriod lastOffer = new TimePeriod(offers.Last().From, offers.Last().To);

            if (reservationPeriods.Length == 0)
            {
                freePeriods = new TimePeriod[]
                {
                    new TimePeriod(firstOffer.Start, lastOffer.End)
                };
            }
            else
            {
                TimePeriod range = new TimePeriod(DateTime.Today, lastOffer.End);
                freePeriods = TimePeriod.GetFreePeriods(range, reservationPeriods);
            }

        }

        private TimePeriod FitPeriodIntoOffer(OfferModel offer, TimePeriod period)
        {
            TimePeriod offerPeriod = new TimePeriod(offer.From, offer.To);
            TimePeriod printPeriod = new TimePeriod(DateTime.Today, DateTime.Today);

            if (offerPeriod.IsBefore(period) || offerPeriod.IsAfter(period))
            {
                return null;
            }

            if (offerPeriod.HasInside(period))
            {
                printPeriod = period;
            }
            else if (offerPeriod.EndsInside(period))
            {
                printPeriod.Start = period.Start;
                printPeriod.End = offer.To;
            }
            else if (offerPeriod.StartsInside(period))
            {
                printPeriod.Start = offer.From;
                printPeriod.End = period.End;
            }
            else if (offerPeriod.IsInside(period))
            {
                printPeriod.Start = offer.From;
                printPeriod.End = offer.To;
            }

            return printPeriod;
        }

        private List<string> MatchOffersWithPeriods(TimePeriod[] periods)
        {
            List<string> output = new List<string>();

            foreach (OfferModel offer in offers)
            {
                TimePeriod offerPeriod = new TimePeriod(offer.From, offer.To);
                foreach (TimePeriod period in periods)
                {
                    TimePeriod printPeriod = FitPeriodIntoOffer(offer, period);
                    if (printPeriod == null)
                    {
                        continue;
                    }

                    //int days = printPeriod.GetDaySpan() + 1;
                    //double price = days * offer.PricePerDay;
                    string from = printPeriod.Start.ToShortDateString();
                    string to = printPeriod.End == DateTime.MaxValue.Date ? "daljnjeg" : printPeriod.End.ToShortDateString();
                    string toPrint = $"Od {from} do {to} - cena po danu {offer.PricePerDay}";
                    output.Add(toPrint);
                }
            }

            return output;
        }

        private void DisplayFreePeriods()
        {
            List<string> output = new List<string>();
            if (freePeriods == null || freePeriods.Length == 0)
            {
                output.Add("Nema ponuda za ovaj automobil");
            }
            else
            {
                output = MatchOffersWithPeriods(freePeriods);
            }
            view.PeriodsDataSource = output;
        }

        private void CalculatePriceForPickedPeriod()
        {
            // Validate it first
            bool validNewReservationPeriod = ValidateNewReservationPeriod();
            bool validUpdateReservationPeriod = ValidateUpdateReservationPeriod();

            if (!validNewReservationPeriod && !validUpdateReservationPeriod)
            {
                view.Price = 0;
                return;
            }
            TimePeriod pickedPeriod = new TimePeriod(view.From, view.To);
            double price = 0;
            foreach(OfferModel offer in offers)
            {
                TimePeriod offerMatchedPeriod = FitPeriodIntoOffer(offer, pickedPeriod);
                if (offerMatchedPeriod == null)
                {
                    continue;
                }
                int days = offerMatchedPeriod.GetDaySpan() + 1;
                price += days * offer.PricePerDay;
            }

            view.Price = price;
        }

        private void FindUpdateLimits()
        {
            ReservationModel reservation = selectedReservation.Record;
            TimePeriod reservationPeriod = new TimePeriod(reservation.From, reservation.To);

            offers = RentACarLibrary.GlobalConfig.OfferModelConection
                .Filter(model => {
                    TimePeriod period = new TimePeriod(model.From, model.To);
                    return model.CarID == reservation.CarID &&
                           (period.HasInside(DateTime.Today) || period.IsAfter(DateTime.Today));
                });

            TimePeriod[] offerPeriods = offers
                .Select(model => new TimePeriod(model.From, model.To))
                .OrderBy(period => period.Start)
                .ToArray();

            TimePeriod[] reservationPeriods = RentACarLibrary.GlobalConfig.ReservationModelConection
                .Filter(model => model.CarID == reservation.CarID)
                .Select(model => new TimePeriod(model.From, model.To))
                .Where(period => period.HasInside(DateTime.Today) || period.IsAfter(DateTime.Today))
                .OrderBy(period => period.Start)
                .ToArray();


            outerRange = new TimePeriod(reservationPeriod.Start, reservationPeriod.End);
            
            // check reservations for outer range
            for (int i = 0; i < reservationPeriods.Length; i++)
            {
                TimePeriod period = reservationPeriods[i];
                if (period.IsExactMatch(reservationPeriod))
                {
                    try
                    {
                        outerRange.Start = reservationPeriods[i - 1].End.AddDays(1);
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                    try
                    {
                        outerRange.End = reservationPeriods[i + 1].Start.AddDays(-1);
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                    break;
                }
            }

            int offerIndex = 0;
            // find offerIndex
            for (int i = 0; i < offerPeriods.Length; i++)
            {
                if (offerPeriods[i].IntersectsWith(outerRange))
                {
                    offerIndex = i;
                    break;
                }
            }

            // check other sources for the left outer range
            //if (outerRange.HasInside(DateTime.Today))
            //{
            //    outerRange.Start = DateTime.Today;
            //}
            // check offers for the left outer range 
            if (outerRange.Start == reservationPeriod.Start)
            {
                // find left range limit
                for (int i = offerIndex; i > -1; i--)
                {
                    int dayDiff = (int)(outerRange.Start - offerPeriods[i].End).TotalDays;
                    if (offerPeriods[i].IntersectsWith(outerRange) || dayDiff == 1)
                    {
                        outerRange.Start = offerPeriods[i].Start;
                    }
                }
            }

            // find the right outer range
            if (reservationPeriods.Last().IsExactMatch(reservationPeriod))
            {
                for (int i = offerIndex; i < offerPeriods.Length; i++)
                {
                    int dayDiff = (int)(offerPeriods[i].Start - outerRange.End).TotalDays;
                    if (offerPeriods[i].IntersectsWith(outerRange) || dayDiff == 1)
                    {
                        outerRange.End = offerPeriods[i].End;
                    }
                }
            }
        }

        private void DisplayUpdateLimits()
        {
            TimePeriod[] periods = new TimePeriod[]
            {
                outerRange
            };
            List<string> output = MatchOffersWithPeriods(periods);
            view.PeriodsDataSource = output;
        }

        private void SetUpdateControlLimits()
        {
            TimePeriod reservationPeriod = new TimePeriod(selectedReservation.Record.From, selectedReservation.Record.To);

            // Enable apropriate controls
            if (reservationPeriod.IsBefore(DateTime.Today))
            {
                view.AllInputsEnabled = false;
                outerRange = null;
                return;
            }
            else
            {
                view.AllInputsEnabled = true;
            }

            if (reservationPeriod.HasInside(DateTime.Today))
            {
                view.CarSelectorEnabled = false;
                view.CustomerSelectorEnabled = false;
                view.DateFromSelectorEnabled = false;
            }
        }

        // validations

        private bool ValidateCarField()
        {
            bool valid = true;

            if (view.Car == null)
            {
                view.SetControlError("Car", Messages.ErrorRequiredField("Automobil"));
                valid = false;
            }

            return valid;
        }

        private bool ValidateCustomerField()
        {
            bool valid = true;

            if (view.User == null)
            {
                view.SetControlError("Customer", Messages.ErrorRequiredField("Mušterija"));
                valid = false;
            }

            return valid;
        }

        private bool ValidateNewReservationPeriod()
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
            catch (Exception ex)
            {
                if(ex is ArgumentException || ex is NullReferenceException)
                {
                    valid = false;
                }
            }

            return valid;
        }

        private bool ValidateUpdateReservationPeriod()
        {
            bool valid = false;
            try
            {
                TimePeriod pickedPeriod = new TimePeriod(view.From, view.To);
                valid = outerRange.HasInside(pickedPeriod);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is NullReferenceException)
                {
                    valid = false;
                }
            }

            return valid;
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
            bool carValid = ValidateCarField();
            bool customerValid = ValidateCustomerField();

            if (!carValid || !customerValid)
            {
                view.ShowAlertMessage(
                    new AlertMessage(AlertMessage.MessageType.Error, Messages.ERROR_FORM_FILL));
                return;
            }

            if (!ValidateNewReservationPeriod())
            {
                view.ShowAlertMessage(
                    new AlertMessage(AlertMessage.MessageType.Error, "Nema tog slobodnog termina"));
                return;
            }

            // Create a new Reservation object and send it to be created
            ReservationModel Reservation = new ReservationModel();
            PopulateReservation(Reservation);
            AddRecordMessage<ReservationModel> message = new AddRecordMessage<ReservationModel>(Reservation);
            eventAggregator.Publish(message);

            SetStateDefault();
        }

        private void UpdateTriggerHandler(object sender, EventArgs e)
        {
            bool carValid = ValidateCarField();
            bool customerValid = ValidateCustomerField();
            if (!carValid || !customerValid)
            {
                view.ShowAlertMessage(
                    new AlertMessage(AlertMessage.MessageType.Error, Messages.ERROR_FORM_FILL));
                return;
            }

            int carId = (view.Car as CarModel).ID;
            // If the car for the offer wasn't changed
            if (carId == selectedReservation.Record.CarID)
            {
                // Do update offer date validation
                if (!ValidateUpdateReservationPeriod())
                {
                    view.ShowAlertMessage(
                        new AlertMessage(AlertMessage.MessageType.Error, Messages.ERROR_NO_TIME_PERIOD));
                    return;
                }
            }
            else
            {
                // Do new offer date validation
                if (!ValidateNewReservationPeriod())
                {
                    view.ShowAlertMessage(
                        new AlertMessage(AlertMessage.MessageType.Error, Messages.ERROR_NO_TIME_PERIOD));
                    return;
                }
            }


            ReservationModel Reservation = selectedReservation.Record;
            PopulateReservation(Reservation);

            UpdateRecordMessage<ReservationModel> updateMessage =
                new UpdateRecordMessage<ReservationModel>(Reservation, selectedReservation.Index);
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

            if (state == ViewState.New)
            {
                FindFreePeriods(car.ID);
                DisplayFreePeriods();
                CalculatePriceForPickedPeriod();
            }
            else if(state == ViewState.Update)
            {
                TimePeriod reservationPeriod = new TimePeriod(selectedReservation.Record.From, selectedReservation.Record.To);
                if (reservationPeriod.IsBefore(DateTime.Today))
                {
                    return;
                }

                if(selectedReservation.Record.CarID == car.ID)
                {
                    FindUpdateLimits();
                    DisplayUpdateLimits();
                    CalculatePriceForPickedPeriod();
                }
                else
                {
                    FindFreePeriods(car.ID);
                    DisplayFreePeriods();
                    CalculatePriceForPickedPeriod();
                }
            }
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

        private void DatePickedHandler(object sender, EventArgs e)
        {
            // calc price for the selected dates
            CalculatePriceForPickedPeriod();
        }
    }
}
