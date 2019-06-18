using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACarLibrary.Models;
using RentACarLibrary.DataAccess;
using UI.Helpers;
using UI.Events;
using UI.Events.Messages;
using UI.Views.Data;
using System.Windows.Forms;

namespace UI.Presenters.Data
{
    public class CustomersTablePresenter : StateTablePresenter<UserModel>
    {
        public CustomersTablePresenter(ITableView view, IEventAggregator eventAggregator)
            : base(view, eventAggregator)
        {
            
        }

        protected override void SubscribeToEvents()
        {
            base.SubscribeToEvents();
            eventAggregator.Unsubscribe<AddRecordMessage<UserModel>>(AddRecordHandler);
        }

        protected override IDataConnection<UserModel> DataConnection
        {
            get => RentACarLibrary.GlobalConfig.UserModelConnection as IDataConnection<UserModel>;
        }

        protected override void LoadData()
        {
            UserModel[] users = RentACarLibrary.GlobalConfig.UserModelConnection.Filter(
                    user => user is CustomerModel
                );
            List<CustomerModel> custmersList = new List<CustomerModel>();
            foreach (UserModel user in users)
            {
                custmersList.Add(user as CustomerModel);
            }
            dataSource = new BindingSource()
            {
                DataSource = custmersList
            };
            view.DataSource = dataSource;
        }

        protected override void SetTableColumns()
        {
            TableColumnInfo[] columnsInfo = new TableColumnInfo[]
           {
                new TableColumnInfo("ID","ID"),
                new TableColumnInfo("Ime","FirstName"),
                new TableColumnInfo("Prezime","LastName"),
                new TableColumnInfo("Datum rodjenja", "DateOfBirth"),
                new TableColumnInfo("JMBG","UMCN"),
                new TableColumnInfo("Broj telefona","PhoneNumber")
           };

            view.CreateColumns(columnsInfo);
        }

        protected override UserModel DeleteRecord(int index)
        {
            CustomerModel customer = dataSource[index] as CustomerModel;
            // find reservations
            ReservationModel[] reservations = RentACarLibrary.GlobalConfig.ReservationModelConection
               .Filter(model => model.UserID == customer.ID);

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
                 ($"Mušterija sa podacima\n" +
                  $"{customer.FullName}\n" +
                  $"Ima aktivne rezervacije i neće biti obrisana"),
                 "Upozorenje",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
                return null;
            }
            else if (inActiveReservations.Length > 0)
            {
                // delete inactive reservations
                foreach (ReservationModel reservation in inActiveReservations)
                {
                    RentACarLibrary.GlobalConfig.ReservationModelConection
                        .Delete(reservation.ID);
                }
            }

            // delete
            return DataConnection.Delete(customer.ID);
        }
    }
}
