using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using RentACarLibrary.Models;

namespace UI.Helpers
{
    public class ReservationModelWrapper 
    {
        public ReservationModel Reservation { get; }
        public CarModel Car { get; }

        public ReservationModelWrapper(ReservationModel reservation)
        {
            this.Reservation = reservation;
            Car = RentACarLibrary.GlobalConfig.CarModelConection.Get(reservation.CarID);
        }

        public int ID { get => Reservation.ID; set => Reservation.ID = value; }
        public DateTime From { get => Reservation.From;}
        public DateTime To { get => Reservation.To; }
        public string CarName { get => Car.CarName; }
        public double Price { get => Reservation.Price; }
    }
}
