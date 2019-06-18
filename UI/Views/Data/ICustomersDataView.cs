using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Models;

namespace UI.Views.Data
{
    public interface ICustomersDataView: ICustomerModelView, IViewControls, IAlert, IPresenter, ILoad
    {
        event EventHandler RegisterNewCustomerTrigger;
        event EventHandler UpdateCustomerTrigger;
        event EventHandler DeleteCustomerTrigger;
        event EventHandler CancleTrigger;

        bool RegisterNewCustomerTriggerEnabled { get; set; }
        bool UpdateCustomerTriggerEnabled { get; set; }
        bool DeleteCustomerTriggerEnabled { get; set; }

        bool AllInputsEnabled { get; set; }

        string Password { get; set; }

    }
}
