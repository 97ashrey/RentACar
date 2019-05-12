using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Models;

namespace UI.Views.Data
{
    public interface ICarsDataView: ICarModelView, IViewControls, IAlert, IPresenter, ILoad
    {
        event EventHandler NewCarTrigger;
        event EventHandler SaveCarTrigger;
        event EventHandler UpdateCarTrigger;
        event EventHandler DeleteCarTrigger;
        event EventHandler CancleTrigger;

        bool NewCarTriggerEnabled { get; set; }
        bool SaveCarTriggerEnabled { get; set; }
        bool UpdateCarTriggerEnabled { get; set; }
        bool DeleteCarTriggerEnabled { get; set; }

        object CarBodyDataSource { get; set; }
        object ShiftTypeDataSource { get; set; }
        object FuelTypeDataSource { get; set; }
        object DriveTypeDataSource { get; set; }
        object DorCountDataSource { get; set; }

        bool AllInputsEnabled { get; set; }
    }
}
