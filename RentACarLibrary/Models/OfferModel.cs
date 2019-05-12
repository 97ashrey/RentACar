using System;
using System.Runtime.Serialization;

namespace RentACarLibrary.Models
{
    [Serializable]
    public class OfferModel : IDataModel
    {
        //PK
        public int ID { get; set; }
        // FK
        public int CarID { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double PricePerDay { get; set; }

        public OfferModel()
        {

        }

        public OfferModel(int carID, DateTime from, DateTime to, double pricePerDay)
        {
            CarID = carID;
            From = from;
            To = to;
            PricePerDay = pricePerDay;
        }

        public OfferModel(SerializationInfo info, StreamingContext context)
        {
            ID = (int)info.GetValue("ID", typeof(int));
            CarID = (int)info.GetValue("CarID", typeof(int));
            To = (DateTime)info.GetValue("To", typeof(DateTime));
            From = (DateTime)info.GetValue("From", typeof(DateTime));
            PricePerDay = (double)info.GetValue("PricePerDay", typeof(double));
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", ID);
            info.AddValue("CarID", CarID);
            info.AddValue("To", To);
            info.AddValue("From", From);
            info.AddValue("PricePerDay", PricePerDay);
        }
    }
}
