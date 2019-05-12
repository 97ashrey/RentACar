using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACarLibrary.DataAccess;
using RentACarLibrary.Models;
using UI.Events;
using UI.Helpers;
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
            ReservationModel[] reservations = DataConnection.GetAll();
            dataSource = new System.Windows.Forms.BindingSource();
            dataSource.DataSource = reservations.ToList();
            view.DataSource = dataSource;
        }

        protected override void SetTableColumns()
        {
            TableColumnInfo[] columnsInfo = new TableColumnInfo[]
            {
                new TableColumnInfo("ID automobila","CarID"),
                new TableColumnInfo("ID kupca","UserID"),
                new TableColumnInfo("Datum od", "From"),
                new TableColumnInfo("Datum do", "To"),
                new TableColumnInfo("Cena", "Price")
            };

            view.CreateColumns(columnsInfo);
        }
    }
}
