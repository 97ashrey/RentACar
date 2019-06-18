using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACarLibrary.DataAccess;
using RentACarLibrary.Models;
using UI.Events;
using UI.Events.Messages;
using UI.Helpers;
using UI.Models;
using UI.Views.Data;

namespace UI.Presenters.Data
{
    public class CustomerReservationsTablePresenter : TablePresenter<ReservationModel>
    {
        public CustomerReservationsTablePresenter(ITableView view, IEventAggregator eventAggregator) : base(view, eventAggregator)
        {
            view.MultiselectEnabled = false;

        }

        protected override IDataConnection<ReservationModel> DataConnection
        {
            get => RentACarLibrary.GlobalConfig.ReservationModelConection;
        }

        protected override void LoadData()
        {
            UserModel currentUser = RentACarLibrary.SessionData.CurrentUser;
            ReservationModel[] reservations = DataConnection.Filter(model => model.UserID == currentUser.ID);
            List<ReservationModelWrapper> wrappedResevations = new List<ReservationModelWrapper>();
            foreach(ReservationModel model in reservations)
            {
                wrappedResevations.Add(new ReservationModelWrapper(model));
            }
            dataSource = new System.Windows.Forms.BindingSource();
            //dataSource.DataSource = reservations.ToList();
            dataSource.DataSource = wrappedResevations;
            view.DataSource = dataSource;
            view.ClearSelection();
        }

        protected override void SetTableColumns()
        {
            TableColumnInfo[] columnsInfo = new TableColumnInfo[]
            {
                new TableColumnInfo("Automobil", "CarName"),
                new TableColumnInfo("Datum od", "From"),
                new TableColumnInfo("Datum do", "To"),
                new TableColumnInfo("Cena", "Price")
            };

            view.CreateColumns(columnsInfo);
        }

        protected override string GetDeleteConfirmMessage()
        {
            return "Želite da otkažete rezervaciju?";
        }

        protected override ReservationModel DeleteRecord(int index)
        {
            ReservationModelWrapper wrapper = dataSource[index] as ReservationModelWrapper;
            ReservationModel model = DataConnection.Delete(wrapper.ID);
            return model;
        }

        // Event Handlers
        protected override void RecordSelectedHandler(object sender, RecordSelectedEventArgs e)
        {
            if(e.Type == RecordSelectedEventArgs.ClickType.Single)
            {
                SendSelectedRecordMessage(e.Index);
            }
        }

        protected override void SendSelectedRecordMessage(int index)
        {
            ReservationModelWrapper wrapper = dataSource[index] as ReservationModelWrapper;
            CarModel car = wrapper.Car;
            SelectedRecordMessage<CarModel> customerMessage = 
                new SelectedRecordMessage<CarModel>(car, index);
            eventAggregator.Publish(customerMessage);
        }
    }
}
