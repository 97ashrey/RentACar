using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Models;

namespace UI.Views.Data
{
    public interface IOffersDataView: IOfferModelView, IViewControls, IAlert, IPresenter, ILoad
    {
        event EventHandler NewOfferTrigger;
        event EventHandler SaveOfferTrigger;
        event EventHandler UpdateOfferTrigger;
        event EventHandler DeleteOfferTrigger;
        event EventHandler CancleTrigger;
        event EventHandler CarSelectedTrigger;

        string CarInfo { get; set; }
        object FreePeriodDisplayDataSource { get; set; }

        object CarIDsDataSource { get; set; }

        string CarIDsDisplayMember { get; set; }
        string CarIDsValueMemeber { get; set; }

        bool NewOfferTriggerEnabled { get; set; }
        bool SaveOfferTriggerEnabled { get; set; }
        bool UpdateOfferTriggerEnabled { get; set; }
        bool DeleteOfferTriggerEnabled { get; set; }

        bool PricePerDayInputEnabled { get; set; }
        bool CarIDInputEnabled { get; set; }


        bool AllInputsEnabled { get; set; }
    }
}
