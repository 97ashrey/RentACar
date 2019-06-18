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
using System.Windows.Forms;

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

        protected override CarModel DeleteRecord(int index)
        {
            // get the car in question
            CarModel car = dataSource[index] as CarModel;

            ReservationModel[] reservations = RentACarLibrary.GlobalConfig.ReservationModelConection
                .Filter(model => model.CarID == car.ID);

            ReservationModel[] activeReservations = reservations
                .Where(model => {
                    TimePeriod period = new TimePeriod(model.From, model.To);
                    return period.HasInside(DateTime.Today) || period.IsAfter(DateTime.Today);
                })
                .ToArray();

            ReservationModel[] inActiveReservations = reservations
                .Where(model => {
                    TimePeriod period = new TimePeriod(model.From, model.To);
                    return period.IsBefore(DateTime.Today);
                })
                .ToArray();

            // check if it has active reservations
            if (activeReservations.Length > 0)
            {
                //stop deletion
                MessageBox.Show(
                 ($"Automobil sa podacima\n" +
                  $"{car.CarName}\n" +
                  $"Ima aktivne rezervacije i neće biti obrisan"),
                 "Upozorenje",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
                return null;
            }
            else if(inActiveReservations.Length > 0)
            {
                // delete inactive reservations
                foreach(ReservationModel reservation in inActiveReservations)
                {
                    RentACarLibrary.GlobalConfig.ReservationModelConection
                        .Delete(reservation.ID);
                }
            }

            // delete
            car = DataConnection.Delete(car.ID);
            return car;
        }
    }
}
