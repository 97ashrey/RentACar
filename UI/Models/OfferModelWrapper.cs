using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACarLibrary.Models;

namespace UI.Models
{
    public class OfferModelWrapper
    {
        private OfferModel offer;

        public OfferModel Offer
        {
            get => offer;
            set
            {
                offer = value;
                GetReferencedModels();
            }
        }
        public CarModel Car { get; private set; }

        public OfferModelWrapper(OfferModel offer)
        {
            Offer = offer;
        }

        private void GetReferencedModels()
        {
            Car = RentACarLibrary.GlobalConfig.CarModelConection.Get(Offer.CarID);
        }

        public int ID { get => Offer.ID; set => Offer.ID = value; }
        public DateTime From { get => Offer.From; }
        public DateTime To { get => Offer.To; }
        public double PricePerDay { get => Offer.PricePerDay; }


        public int CarID { get => Offer.CarID; set => Offer.CarID = value; }
        public string CarName { get => Car.CarName; }

    }
}
