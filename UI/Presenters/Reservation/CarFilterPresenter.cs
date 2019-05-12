using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Reservation;
using UI.Events;
using UI.Events.Messages;
using RentACarLibrary.DataDomains;
using RentACarLibrary.Models;

namespace UI.Presenters.Reservation
{
    public class CarFilterPresenter
    {
        private ICarFilterView view;
        private IEventAggregator eventAggregator;

        public CarFilterPresenter(ICarFilterView view, IEventAggregator eventAggregator)
        {
            this.view = view;
            this.eventAggregator = eventAggregator;

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            view.LoadedTrigger += LoadHandler;
            view.BrandPickedTriggered += BrandPickedHandler;
            view.FindCarsTriggered += FindCarsHandler;
        }

        private List<string> AddDefaultChoice(List<string> list)
        {
            list.Insert(0, "Izaberi");
            return list;
        }

        private void SetDataSources()
        {
            SetBrandDataSource();
            //List<string> carBodies = CarModelDataDomain.CarBodies.ToList();
            //carBodies.Insert(0, null);
            view.CarBodyDataSource = AddDefaultChoice(CarModelDataDomain.CarBodies.ToList());
            view.DorCountDataSource = AddDefaultChoice(CarModelDataDomain.DorCount.ToList());
            view.DriveTypeDataSource = AddDefaultChoice(CarModelDataDomain.DriveTypes.ToList());
            view.FuelTypeDataSource = AddDefaultChoice(CarModelDataDomain.FuelTypes.ToList());
            view.ShiftTypeDataSource = AddDefaultChoice(CarModelDataDomain.ShiftTypes.ToList());
            view.CreatedYearFromDataSource = AddDefaultChoice(CarModelDataDomain.GetCreatedYearDomain());
            view.CreatedYearToDataSource = AddDefaultChoice(CarModelDataDomain.GetCreatedYearDomain());
            view.CubicCapacityFromDataSource = AddDefaultChoice(CarModelDataDomain.CubicCapacity.ToList());
            view.CubicCapacityToDataSource = AddDefaultChoice(CarModelDataDomain.CubicCapacity.ToList());
            //view.ClearAllControls();
        }

        private void SetBrandDataSource()
        {
            CarModel[] cars = RentACarLibrary.GlobalConfig.CarModelConection.GetAll();
            HashSet<string> brands = new HashSet<string>();
            foreach(CarModel car in cars)
            {
                brands.Add(car.Brand);
            }
            view.BrandDataSource = AddDefaultChoice(brands.ToList());
        }

        private void SetModelDataSource(string brand)
        {
            CarModel[] cars = RentACarLibrary.GlobalConfig.CarModelConection.Filter(
                model => model.Brand == brand
                );
            HashSet<string> models = new HashSet<string>();
            foreach(CarModel car in cars)
            {
                models.Add(car.Model);
            }
            view.ModelDataSource = AddDefaultChoice(models.ToList());
        }

        private void FindCars()
        {
            Dictionary<string, string> values = GetFilterValues();
            // find all cars
            CarModel[] cars = RentACarLibrary.GlobalConfig.CarModelConection.Filter(
                model =>
                {
                    Dictionary<string, string> carDict = model.ToDict();
                    foreach (string key in values.Keys)
                    {
                        if (carDict[key] != values[key])
                        {
                            return false;
                        }
                    }
                    // Check for created year and cubic capacity ranges
                    bool cubicValuesPicked = view.CubicCapacityFrom.ValuePicked() && view.CubicCapacityFrom.ValuePicked();
                    if (cubicValuesPicked)
                    {
                        double cubicCapacityFrom = double.Parse(view.CubicCapacityFrom);
                        double cubicCapacityTo = double.Parse(view.CubicCapacityTo);
                        bool inCubicRange = cubicCapacityFrom <= model.CubicCapacity && model.CubicCapacity <= cubicCapacityTo;
                        if (!inCubicRange)
                        {
                            return false;
                        }
                    }
                        
                    bool yearValuesPicked = view.CreatedYearFrom.ValuePicked() && view.CreatedYearTo.ValuePicked();
                    if (yearValuesPicked)
                    {
                        int createdYearFrom = int.Parse(view.CreatedYearFrom);
                        int createdYearTo = int.Parse(view.CreatedYearTo);
                        bool inCreatedYearRange = createdYearFrom <= model.CreatedYear && model.CreatedYear <= createdYearTo;
                        if (!inCreatedYearRange)
                        {
                            return false;
                        }
                    }
                        
                    return true;
                }
                );
            // send selected cars via event aggregator
            CarsFoundMessage carsFoundMessage = new CarsFoundMessage(cars);
            eventAggregator.Publish(carsFoundMessage);
        }

        private Dictionary<string,string> GetFilterValues()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            #region Value Adding
            if(view.Brand.ValuePicked())
            {
                values.Add("Brand", view.Brand);
            }
            if(view.Model .ValuePicked())
            {
                values.Add("Model", view.Model);
            }
            if(view.CarBody.ValuePicked())
            {
                values.Add("CarBody", view.CarBody);
            }
            if(view.DorCount.ValuePicked())
            {
                values.Add("DorCount", view.DorCount);
            }
            if (view.FuelType.ValuePicked())
            {
                values.Add("FuelType", view.FuelType);
            }
            if (view.ShiftType.ValuePicked())
            {
                values.Add("ShiftType", view.ShiftType);
            }
            if (view.DriveType.ValuePicked())
            {
                values.Add("DriveType", view.DriveType);
            }
            #endregion
            return values;
        }

        // Event Handlers
        private void LoadHandler(object sender, EventArgs e)
        {
            FindCars();
            SetDataSources();
        }

        private void BrandPickedHandler(object sender, EventArgs e)
        {
            if (!view.Brand.ValuePicked())
            {
                view.ModelDataSource = null;
                return;
            }
            SetModelDataSource(view.Brand);
        }

        private void FindCarsHandler(object sender, EventArgs e)
        {
            FindCars();
        }
    }
}
