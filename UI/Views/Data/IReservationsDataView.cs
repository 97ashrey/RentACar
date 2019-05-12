using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Models;

namespace UI.Views.Data
{
    public interface IReservationsDataView : IReservationModelView, IViewControls, IAlert, IPresenter, ILoad
    {
        event EventHandler NewReservationTrigger;
        event EventHandler SaveReservationTrigger;
        event EventHandler UpdateReservationTrigger;
        event EventHandler DeleteReservationTrigger;
        event EventHandler CancleTrigger;

        event EventHandler CarSelectedTrigger;
        event EventHandler CustomerSelectedTrigger;

        string CarInfo { get; set; }
        string UserInfo { get; set; }

        object CarDataSource { get; set; }
        string CarDisplayMember { get; set; }

        object CustomerDataSource { get; set; }
        string CustomerDisplayMember { get; set; }

        bool NewReservationTriggerEnabled { get; set; }
        bool SaveReservationTriggerEnabled { get; set; }
        bool UpdateReservationTriggerEnabled { get; set; }
        bool DeleteReservationTriggerEnabled { get; set; }

        bool AllInputsEnabled { get; set; }
    }
}
