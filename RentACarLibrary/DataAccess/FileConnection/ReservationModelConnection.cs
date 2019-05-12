using RentACarLibrary.Models;

namespace RentACarLibrary.DataAccess.FileConnection
{
    public class ReservationModelConnection : DataConnection<ReservationModel>
    {
        public ReservationModelConnection() : base(GlobalConfig.GetReservationsDirectory())
        {
        }
    }
}
