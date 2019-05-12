using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Views.Reservation
{
    public interface ISelectCarView : IPresenter
    {
        event EventHandler CarPickedTriggered;

        string CarInfo { get; set; }

        object SelectedCar { get; set; }
        object CarsDataSource { get; set; }
        string CarsDisplayMember { get; set; }
    }
}
