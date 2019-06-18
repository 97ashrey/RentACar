using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using RentACarLibrary.Models;

namespace UI.Models
{
    public class ReservationModelWrapper 
    {
        private ReservationModel reservation;

        public ReservationModel Reservation
        {
            get => reservation;
            set
            {
                reservation = value;
                GetReferencedModels();
            }
        }
        public CarModel Car { get; private set; }
        public CustomerModel Customer { get; private set; }

        public ReservationModelWrapper(ReservationModel reservation)
        {
            Reservation = reservation;
        }

        private void GetReferencedModels()
        {
            Car = RentACarLibrary.GlobalConfig.CarModelConection.Get(reservation.CarID);
            Customer = RentACarLibrary.GlobalConfig.UserModelConnection.Get(reservation.UserID) as CustomerModel;
        }

        public int ID { get => Reservation.ID; set => Reservation.ID = value; }
        public DateTime From { get => Reservation.From;}
        public DateTime To { get => Reservation.To; }
        public double Price { get => Reservation.Price; }


        public int CarID { get => Reservation.CarID; set => Reservation.CarID = value; }
        public string CarName { get => Car.CarName; }

        public int UserId { get => Reservation.UserID; set => Reservation.UserID = value; }
        public string FullName { get => Customer.FullName; }
        
    }
}
