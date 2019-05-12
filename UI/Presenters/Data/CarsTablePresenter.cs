using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Data;
using UI.Events;
using UI.Events.Messages;
using RentACarLibrary.Models;
using RentACarLibrary.DataAccess;
using UI.Helpers;

namespace UI.Presenters.Data
{
    public class CarsTablePresenter : StateTablePresenter<CarModel>
    {
        public CarsTablePresenter(ITableView view, IEventAggregator eventAggregator): base(view, eventAggregator)
        {

        }

        protected override IDataConnection<CarModel> DataConnection
        {
            get => RentACarLibrary.GlobalConfig.CarModelConection;
        }

        protected override void LoadData()
        {
            CarModel[] cars = DataConnection.GetAll();
            dataSource = new System.Windows.Forms.BindingSource();
            dataSource.DataSource = cars.ToList();
            view.DataSource = dataSource;
        }

        protected override void SetTableColumns()
        {
            TableColumnInfo[] columnsInfo = new TableColumnInfo[]
            {
                new TableColumnInfo("ID","ID"),
                new TableColumnInfo("Marka","Brand"),
                new TableColumnInfo("Model","Model"),
                new TableColumnInfo("Godište", "CreatedYear"),
                new TableColumnInfo("Kubikaža","CubicCapacity"),
                new TableColumnInfo("Karoserija","CarBody"),
                new TableColumnInfo("Broj vrata","DorCount"),
                new TableColumnInfo("Gorivo","FuelType"),
                new TableColumnInfo("Pogon", "DriveType"),
                new TableColumnInfo("Menjač", "ShiftType")
            };

            view.CreateColumns(columnsInfo);
        }
    }
}
