using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Views.Reservation
{
    public interface ICreateReservationView: IPresenter
    {
        event EventHandler DatePickedTriggered;
        event EventHandler CreateReservationTriggered;

        DateTime DateFrom { get; set; }
        DateTime DateTo { get; set; }
        double Price { get; set; }

        object PeriodsDataSource { get; set; }
    }
}
