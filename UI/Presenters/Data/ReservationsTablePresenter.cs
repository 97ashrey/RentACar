using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACarLibrary.DataAccess;
using RentACarLibrary.Models;
using UI.Events;
using UI.Helpers;
using UI.Models;
using UI.Views.Data;

namespace UI.Presenters.Data
{
    public class ReservationsTablePresenter : StateTablePresenter<ReservationModel>
    {
        public ReservationsTablePresenter(ITableView view, IEventAggregator eventAggregator) : base(view, eventAggregator)
        {

        }

        protected override IDataConnection<ReservationModel> DataConnection
        {
            get => RentACarLibrary.GlobalConfig.ReservationModelConection;
        }

        protected override void LoadData()
        {
            List<ReservationModelWrapper> reservations = DataConnection
                .GetAll()
                .Select(model => new ReservationModelWrapper(model))
                .OrderBy(reservation => reservation.To)
                .ToList();
            dataSource = new System.Windows.Forms.BindingSource()
            {
                DataSource = reservations
            };
            view.DataSource = dataSource;
        }

        protected override void SetTableColumns()
        {
            TableColumnInfo[] columnsInfo = new TableColumnInfo[]
            {
                new TableColumnInfo("Automobil","CarName"),
                new TableColumnInfo("Mušterija","FullName"),
                new TableColumnInfo("Datum od", "From"),
                new TableColumnInfo("Datum do", "To"),
                new TableColumnInfo("Cena", "Price")
            };

            view.CreateColumns(columnsInfo);
        }

        protected override void UpdateRecord(int index, ReservationModel data)
        {
            (dataSource[index] as ReservationModelWrapper).Reservation = data;
        }

        protected override ReservationModel GetSelectedRecord(int index)
        {
            return (dataSource.List[index] as ReservationModelWrapper).Reservation;
        }

        protected override void AddNewRecord(ReservationModel data)
        {
            ReservationModelWrapper newRecord = new ReservationModelWrapper(data);
            dataSource.Add(newRecord);
        }

        protected override ReservationModel DeleteRecord(int index)
        {
            ReservationModel model = (dataSource.List[index] as ReservationModelWrapper).Reservation;
            model = DataConnection.Delete(model.ID);
            return model;
        }
    }
}
