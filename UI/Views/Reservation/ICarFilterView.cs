using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Models;

namespace UI.Views.Reservation
{
    public interface ICarFilterView: IViewControls, IPresenter, ILoad
    {
        event EventHandler BrandPickedTriggered;
        event EventHandler FindCarsTriggered;

        string Brand { get; set; }
        string Model { get; set; }
        string DriveType { get; set; }
        string ShiftType { get; set; }
        string CarBody { get; set; }
        string FuelType { get; set; }
        string DorCount { get; set; }

        string CreatedYearFrom { get; set; }
        string CreatedYearTo { get; set; }

        string CubicCapacityFrom { get; set; }
        string CubicCapacityTo { get; set; }

        //DataSources
        object BrandDataSource { get; set; }
        object ModelDataSource { get; set; }
        object DriveTypeDataSource { get; set; }
        object CarBodyDataSource { get; set; }
        object ShiftTypeDataSource { get; set; }
        object DorCountDataSource { get; set; }
        object FuelTypeDataSource { get; set; }
        object CreatedYearFromDataSource { get; set; }
        object CreatedYearToDataSource { get; set; }
        object CubicCapacityFromDataSource { get; set; }
        object CubicCapacityToDataSource { get; set; }
    }
}
