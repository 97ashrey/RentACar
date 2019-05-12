using System;
using System.Runtime.Serialization;

namespace RentACarLibrary.Models
{
    [Serializable]
    public class ReservationModel : IDataModel
    {
        // PK
        public int ID { get; set; }
        // FK
        public int UserID { get; set; }
        public int CarID { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double Price { get; set; }

        public ReservationModel()
        {

        }

        public ReservationModel(
            int userID, 
            int carID, 
            DateTime from, 
            DateTime to, 
            double price)
        {
            UserID = userID;
            CarID = carID;
            From = from;
            To = to;
            Price = price;
        }

        public ReservationModel(SerializationInfo info, StreamingContext context)
        {
            ID = (int)info.GetValue("ID", typeof(int));
            UserID = (int)info.GetValue("UserID", typeof(int));
            CarID = (int)info.GetValue("CarID", typeof(int));
            To = (DateTime)info.GetValue("To", typeof(DateTime));
            From = (DateTime) info.GetValue("From", typeof(DateTime));
            Price = (double)info.GetValue("price", typeof(double));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", ID);
            info.AddValue("UserID", UserID);
            info.AddValue("CarID", CarID);
            info.AddValue("To", To);
            info.AddValue("From", From);
            info.AddValue("price", Price);
        }
    }
}
