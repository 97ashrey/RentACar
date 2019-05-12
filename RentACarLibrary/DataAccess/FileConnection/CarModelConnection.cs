using RentACarLibrary.Models;

namespace RentACarLibrary.DataAccess.FileConnection
{
    public class CarModelConnection : DataConnection<CarModel>
    {
        public CarModelConnection() : base(GlobalConfig.GetCarsDirectory())
        {
        }
    }
}
