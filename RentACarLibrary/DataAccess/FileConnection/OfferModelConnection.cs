using RentACarLibrary.Models;

namespace RentACarLibrary.DataAccess.FileConnection
{
    public class OfferModelConnection : DataConnection<OfferModel>
    {
        public OfferModelConnection() : base(GlobalConfig.GetOffersDirectory())
        {
        }
    }
}
