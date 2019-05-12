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

        protected override void DeleteSelectedRecordsHandler(DeleteSelectedRecordsMessage message)
        {
            MessageBox.Show("Cascade Delete before user delete");
            base.DeleteSelectedRecordsHandler(message);
        }

        protected override bool ConfirmDeleteion()
        {
            return base.ConfirmDeleteion();
        }
    }
}
