using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Views.Data
{
    public interface ICustomerReservationsDataView : IPresenter, IAlert
    {
        event EventHandler CancleReservationTriggered;

        string CarInfo { get; set; }
    }
}
