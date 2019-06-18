using System;
using System.Collections.Generic;
using System.Linq;
using RentACarLibrary.Models;
using RentACarLibrary;
using UI.Helpers;
namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfig.InitializeDataConection();

            // TimePeriodTesting();
            // OfferUpdateAlgTesting();
            //ReservationUpdateAlgTesting();

            OfferModel offer = new OfferModel()
            {
                CarID = 1,
                From = new DateTime(2019, 4, 1),
                To = new DateTime(2019, 4, 29),
                PricePerDay = 100
            };

            ReservationModel reservation = new ReservationModel()
            {
                CarID = 1,
                UserID = 2,
                From = new DateTime(2019, 4, 5),
                To = new DateTime(2019, 4, 12),
                Price = 500
            };

            GlobalConfig.ReservationModelConection.Create(reservation);
            GlobalConfig.OfferModelConection.Create(offer);
        }

        private static void TimePeriodTesting()
        {
            CarModel car = GlobalConfig.CarModelConection.Get(1);
            OfferModel[] offers = GlobalConfig.OfferModelConection.GetAll();
            offers = offers.OrderBy(offer => offer.From).ToArray();
            ReservationModel[] reservations = GlobalConfig.ReservationModelConection.Filter(
                    model => model.CarID == car.ID
                );
            //TimePeriod[] reservedDates = new TimePeriod[]
            //{
            //    new TimePeriod(DateTime.Today.AddDays(4),DateTime.Today.AddDays(6)),
            //    new TimePeriod(DateTime.Today,DateTime.Today.AddDays(2)),
            //    new TimePeriod(DateTime.Today.AddDays(9),DateTime.Today.AddDays(13)),
            //    new TimePeriod(DateTime.Today.AddDays(14),DateTime.Today.AddDays(19))
            //};

            List<TimePeriod> reservedDates = reservations.Select(
                    reservation => new TimePeriod(reservation.From, reservation.To)
                ).OrderBy(period => period.Start).ToList();
            //reservedDates.Add(new TimePeriod(new DateTime(2019, 9, 5), new DateTime(2019, 9, 11)));
            TimePeriod range = new TimePeriod(DateTime.Today.AddDays(-2), offers.Last().To);
            TimePeriod[] freePeriods = TimePeriod.GetFreePeriods(range, reservedDates.ToArray());

            List<string> freeDatePriceOutput = new List<string>();
            foreach (OfferModel offer in offers)
            {
                TimePeriod offerPeriod = new TimePeriod(offer.From, offer.To);
                TimePeriod printPeriod = new TimePeriod(DateTime.Today, DateTime.Today);
                foreach (TimePeriod period in freePeriods)
                {
                    if (offerPeriod.IsBefore(period) || offerPeriod.IsAfter(period))
                    {
                        continue;
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


                    int days = printPeriod.GetDaySpan() + 1;
                    double price = days * offer.PricePerDay;
                    string output = $"{printPeriod} - price {price}";
                    freeDatePriceOutput.Add(output);
                }
            }

            Console.WriteLine("Offers");
            foreach(OfferModel offer in offers)
            {
                Console.WriteLine($"{offer.From.ToShortDateString()}-{offer.To.ToShortDateString()} price per day {offer.PricePerDay}");
            }

            Console.WriteLine("Reserved Dates");
            foreach(TimePeriod period in reservedDates)
            {
                Console.WriteLine(period);
            }

            Console.WriteLine("Free dates");
            foreach(TimePeriod period in freePeriods)
            {
                Console.WriteLine(period);
            }

            Console.WriteLine("Prices");
            foreach (string output in freeDatePriceOutput)
            {
                Console.WriteLine(output);
            }

            // for user time period input
            // check if it is in the free periods
            // find which offers corespond to that time period
            // calculate the price

            Console.WriteLine("sad");
        }

        private static void OfferUpdateAlgTesting()
        {
            OfferModel offer = GlobalConfig.OfferModelConection.GetAll()
                .OrderBy(model => model.From)
                .ToArray().First();

            TimePeriod offerPeriod = new TimePeriod(offer.From, offer.To);

            TimePeriod leftRange = null;
            TimePeriod rightRange = null;
            if (offerPeriod.IsBefore(DateTime.Today))
            {
                leftRange = new TimePeriod(offerPeriod.Start, offerPeriod.Start);
                rightRange = new TimePeriod(offerPeriod.End, offerPeriod.End);
            }
            else {
                TimePeriod[] offerPeriods = GlobalConfig.OfferModelConection.GetAll()
                    .Select(model => new TimePeriod(model.From, model.To))
                    .OrderBy(period => period.Start)
                    .ToArray();
                TimePeriod[] reservedPeriods = GlobalConfig.ReservationModelConection.GetAll()
                    .Select(model => new TimePeriod(model.From, model.To))
                    .Where(period => offerPeriod.IntersectsWith(period))
                    .OrderBy(period => period.Start)
                    .ToArray();

                // Find outer limits
                DateTime leftOuterLimit = DateTime.Today;
                DateTime rightOuterLimit = DateTime.MaxValue;
                for (int i = 0; i < offerPeriods.Length; i++)
                {
                    TimePeriod period = offerPeriods[i];
                    if (period.IsExactMatch(offerPeriod))
                    {
                        try
                        {
                            leftOuterLimit = offerPeriods[i - 1].End.AddDays(1);
                        }
                        catch (IndexOutOfRangeException)
                        {
                        }
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

                DateTime leftInnerLimit = rightOuterLimit;
                DateTime rightInnerLimit = leftOuterLimit;
                if (reservedPeriods.Length > 0)
                {
                    TimePeriod first = reservedPeriods[0];
                    TimePeriod last = reservedPeriods[reservedPeriods.Length - 1];
                    leftInnerLimit = first.Start < DateTime.Today ? DateTime.Today : first.Start;
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
            Console.WriteLine("sds");
        }

        private static void ReservationUpdateAlgTesting()
        {
            ReservationModel reservation = GlobalConfig.ReservationModelConection.GetAll()
                .OrderBy(model => model.From)
                .First();
            TimePeriod reservationPeriod = new TimePeriod(reservation.From, reservation.To);

            OfferModel[] offers = GlobalConfig.OfferModelConection
                .Filter(model => {
                    TimePeriod period = new TimePeriod(model.From, model.To);
                    return model.CarID == reservation.CarID && 
                           (period.HasInside(DateTime.Today) || period.IsAfter(DateTime.Today));
                });

            TimePeriod[] offerPeriods = offers
                .Select(model => new TimePeriod(model.From, model.To))
                .OrderBy(period => period.Start)
                .ToArray();

            TimePeriod[] reservationPeriods = GlobalConfig.ReservationModelConection
                .Filter(model => model.CarID == reservation.CarID)
                .Select(model => new TimePeriod(model.From, model.To))
                .Where(period => period.HasInside(DateTime.Today) || period.IsAfter(DateTime.Today))
                .OrderBy(period => period.Start)
                .ToArray();


            TimePeriod outerRange = new TimePeriod(reservationPeriod.Start, reservationPeriod.End);
            int offerIndex = 0;
            for (int i = 0; i < offerPeriods.Length; i++)
            {
                if (offerPeriods[i].IntersectsWith(outerRange))
                {
                    offerIndex = i;
                    break;
                }
            }

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

            // check other sources for the left outer range
            if (outerRange.HasInside(DateTime.Today))
            {
                outerRange.Start = DateTime.Today;
            }
            // check offers for the left outer range 
            else if (outerRange.Start == reservationPeriod.Start)
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
            if(reservationPeriods.Last().IsExactMatch(reservationPeriod))
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

            Console.WriteLine("asd");
        }

    }

}
