using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Events;
using UI.Events.Messages;
using UI.Helpers;
using UI.Views.Reservation;
using RentACarLibrary.Models;


namespace UI.Presenters.Reservation
{
    public class CreateReservationPresenter
    {
        private IEventAggregator eventAggregator;
        private ICreateReservationView view;


        private TimePeriod[] freePeriods;
        private OfferModel[] offers;

        public CreateReservationPresenter(ICreateReservationView view, IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.view = view;

            SubscribeToEvents();
        }

        private CarModel selectedCar = null;

        private void SubscribeToEvents()
        {
            view.CreateReservationTriggered += CreateReservationHandler;
            view.DatePickedTriggered += DatePickedHandler;
            eventAggregator.Subscribe<CarSelectedMessage>(CarSelectedHandler);
            eventAggregator.Subscribe<ResetViewMessage>(ResetViewHandler);
        }

        private void ResetViewHandler(ResetViewMessage obj)
        {
            view.DateFrom = DateTime.Today;
            view.DateTo = DateTime.Today;
            view.Price = 0;
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

            TimePeriod firstPeriod = freePeriods.First();
            firstPeriod.Start = firstPeriod.Start < DateTime.Today? DateTime.Today: firstPeriod.Start;
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
            if (freePeriods == null)
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
            if (!ValidateNewReservationPeriod())
            {
                view.Price = 0;
                return;
            }
            TimePeriod pickedPeriod = new TimePeriod(view.DateFrom, view.DateTo);
            double price = 0;
            foreach (OfferModel offer in offers)
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


        private void ShowAvailablePeriods()
        {
            FindFreePeriods(selectedCar.ID);
            DisplayFreePeriods();
            CalculatePriceForPickedPeriod();
        }

        private bool ValidateNewReservationPeriod()
        {
            bool valid = false;
            // check if picked dates are in free periods
            try
            {
                TimePeriod pickedPeriod = new TimePeriod(view.DateFrom, view.DateTo);
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
                if (ex is ArgumentException || ex is NullReferenceException)
                {
                    valid = false;
                }
            }

            return valid;
        }

        // event handlers

        private void CreateReservationHandler(object sender, EventArgs e)
        {
            if (!ValidateNewReservationPeriod())
            {
                AlertMessage errorMessage = new AlertMessage(
                    AlertMessage.MessageType.Error,
                    Messages.ERROR_NO_TIME_PERIOD);
                eventAggregator.Publish(errorMessage);
                return;
            }
            ReservationModel reservation = new ReservationModel()
            {
                CarID = selectedCar.ID,
                UserID = RentACarLibrary.SessionData.CurrentUser.ID,
                From = view.DateFrom.Date,
                To = view.DateTo.Date,
                Price = view.Price
            };

            reservation = RentACarLibrary.GlobalConfig.ReservationModelConection.Create(reservation);
            if(reservation == null)
            {
                AlertMessage errorMessage = new AlertMessage(
                    AlertMessage.MessageType.Error,
                    Messages.ERROR_RESERVATION_CREATE);
                eventAggregator.Publish(errorMessage);
            }
            // TODO SUCCESS
            AlertMessage successMessage = new AlertMessage(
                AlertMessage.MessageType.Success,
                Messages.MESSAGE_RESERVATION_CREATE);
            eventAggregator.Publish(successMessage);
            ShowAvailablePeriods();
        }

        private void DatePickedHandler(object sender, EventArgs e)
        {
            CalculatePriceForPickedPeriod();
        }


        private void CarSelectedHandler(CarSelectedMessage message)
        {
            if(message.Car == null)
            {
                view.PeriodsDataSource = null;
                return;
            }
            selectedCar = message.Car;
            ShowAvailablePeriods();
        }
    }
}
