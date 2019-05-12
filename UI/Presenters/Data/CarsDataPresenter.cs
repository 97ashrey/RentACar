using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Data;
using UI.Events;
using UI.Events.Messages;
using RentACarLibrary.Models;
using RentACarLibrary.DataDomains;
using System.Windows.Forms;

namespace UI.Presenters.Data
{
    public class CarsDataPresenter
    {
        ICarsDataView view;
        IEventAggregator eventAggregator;

        private SelectedRecordMessage<CarModel> selectedCar;

        public CarsDataPresenter(ICarsDataView view, IEventAggregator eventAggregator)
        {
            this.view = view;
            this.eventAggregator = eventAggregator;
            SubsribeToEvents();
            SetViewDataSources();
        }

        private void SubsribeToEvents()
        {
            eventAggregator.Subscribe<AlertMessage>(view.ShowAlertMessage);
            eventAggregator.Subscribe<CrudOperationMessage>(CrudOperationMessageHandler);
            view.LoadedTrigger += LoadHandler;
            view.NewCarTrigger += NewTriggerHandler;
            view.SaveCarTrigger += SaveTriggerHandler;
            view.UpdateCarTrigger += UpdateTriggerHandler;
            view.DeleteCarTrigger += DeleteTriggerHandler;
            view.CancleTrigger += CancelTriggerHandler;
        }

        private void SetViewDataSources()
        {
            BindingSource bs = new BindingSource
            {
                DataSource = CarModelDataDomain.CarBodies
            };
            view.CarBodyDataSource = bs;

            bs = new BindingSource
            {
                DataSource = CarModelDataDomain.FuelTypes
            };
            view.FuelTypeDataSource = bs;

            bs = new BindingSource
            {
                DataSource = CarModelDataDomain.ShiftTypes
            };
            view.ShiftTypeDataSource = bs;

            bs = new BindingSource
            {
                DataSource = CarModelDataDomain.DriveTypes
            };
            view.DriveTypeDataSource = bs;

            bs = new BindingSource
            {
                DataSource = CarModelDataDomain.DorCount
            };
            view.DorCountDataSource = bs;

        }

        private void PopulateView(CarModel car)
        {
            view.Brand = car.Brand;
            view.Model = car.Model;
            view.CreatedYear = car.CreatedYear;
            view.CubicCapacity = car.CubicCapacity;
            view.CarBody = car.CarBody;
            view.FuelType = car.FuelType;
            view.ShiftType = car.ShiftType;
            view.DriveType = car.DriveType;
            view.DorCount = car.DorCount;
        }

        private void PopulateCar(CarModel car)
        {
            car.Brand = view.Brand;
            car.Model = view.Model;
            car.CreatedYear = view.CreatedYear;
            car.CubicCapacity = view.CubicCapacity;
            car.CarBody = view.CarBody;
            car.FuelType = view.FuelType;
            car.ShiftType = view.ShiftType;
            car.DriveType = view.DriveType;
            car.DorCount = view.DorCount;
        }

        private void SetStateDefault()
        {
            eventAggregator.Publish(new ToDefaultStateMessage());
            selectedCar = null;
            view.ClearAllControls();
            view.AllInputsEnabled = false;
            view.NewCarTriggerEnabled = true;
            view.SaveCarTriggerEnabled = false;
            view.UpdateCarTriggerEnabled = false;
            view.DeleteCarTriggerEnabled = true;
            eventAggregator.Subscribe<ToUpdateStateMessage>(ToUpdateStateMessageHandler);
            eventAggregator.Unsubscribe<SelectedRecordMessage<CarModel>>(RecordSelectedHandler);
        }

        private void SetStateUpdate()
        {
            view.AllInputsEnabled = true;
            view.NewCarTriggerEnabled = false;
            view.SaveCarTriggerEnabled = false;
            view.UpdateCarTriggerEnabled = true;
            view.DeleteCarTriggerEnabled = false;
            eventAggregator.Unsubscribe<ToUpdateStateMessage>(ToUpdateStateMessageHandler);
            eventAggregator.Subscribe<SelectedRecordMessage<CarModel>>(RecordSelectedHandler);
        }

        private void SetStateNew()
        {
            eventAggregator.Publish(new ToNewStateMessage());
            selectedCar = null;
            view.ClearAllControls();
            view.AllInputsEnabled = true;
            view.NewCarTriggerEnabled = false;
            view.SaveCarTriggerEnabled = true;
            view.UpdateCarTriggerEnabled = false;
            view.DeleteCarTriggerEnabled = false;
        }

        private void UpdateResult(CrudOperationMessage.CrudResult result)
        {
            AlertMessage message;
            switch (result)
            {
                case CrudOperationMessage.CrudResult.Error:
                    message = new AlertMessage(
                        AlertMessage.MessageType.Error,
                        Messages.ERROR_CAR_UPDATE
                        );
                    break;
                default:
                    message = new AlertMessage(
                     AlertMessage.MessageType.Success,
                     Messages.MESSAGE_CAR_UPDATE
                     );
                    break;
            }
            view.ShowAlertMessage(message);
        }

        private void CreateResult(CrudOperationMessage.CrudResult result)
        {
            AlertMessage message;
            switch (result)
            {
                case CrudOperationMessage.CrudResult.Error:
                    message = new AlertMessage(
                        AlertMessage.MessageType.Error,
                        Messages.ERROR_CAR_CREATE
                        );
                    break;
                default:
                    message = new AlertMessage(
                     AlertMessage.MessageType.Success,
                     Messages.MESSAGE_CAR_CREATE
                     );
                    view.ClearAllControls();
                    break;
            }
            view.ShowAlertMessage(message);
        }

        // Event Handlers
        private void LoadHandler(object sender, EventArgs e)
        {
            SetStateDefault();
        }
        private void RecordSelectedHandler(SelectedRecordMessage<CarModel> message)
        {
            selectedCar = message;
            PopulateView(message.Record);
        }

        private void ToUpdateStateMessageHandler(ToUpdateStateMessage message)
        {
            SetStateUpdate();
        }

        private void NewTriggerHandler(object sender, EventArgs e)
        {
            SetStateNew();
        }

        private void SaveTriggerHandler(object sender, EventArgs e)
        {
            // Create a new car object and send it to be created
            CarModel car = new CarModel();
            PopulateCar(car);
            AddRecordMessage<CarModel> message = new AddRecordMessage<CarModel>(car);
            eventAggregator.Publish(message);
        }

        private void UpdateTriggerHandler(object sender, EventArgs e)
        {
            CarModel car = selectedCar.Record;
            PopulateCar(car);

            UpdateRecordMessage<CarModel> updateMessage =
                new UpdateRecordMessage<CarModel>(car, selectedCar.Index);
            eventAggregator.Publish(updateMessage);
        }

        private void DeleteTriggerHandler(object sender, EventArgs e)
        {
            eventAggregator.Publish(new DeleteSelectedRecordsMessage());
        }

        private void CancelTriggerHandler(object sender, EventArgs e)
        {
            SetStateDefault();
        }

        private void CrudOperationMessageHandler(CrudOperationMessage message)
        {
            // This presenter only cares about the update operation
            switch (message.Operation)
            {
                case CrudOperationMessage.CrudOperation.Update:
                    UpdateResult(message.Result);
                    break;
                case CrudOperationMessage.CrudOperation.Create:
                    CreateResult(message.Result);
                    break;
                default:
                    break;
            }
        }
    }
}
