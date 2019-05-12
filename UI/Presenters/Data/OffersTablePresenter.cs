using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Events;
using UI.Events.Messages;
using UI.Views.Data;
using RentACarLibrary.DataAccess;
using RentACarLibrary.Models;
using UI.Helpers;

namespace UI.Presenters.Data
{
    public class OffersTablePresenter : StateTablePresenter<OfferModel>
    {
        public OffersTablePresenter(ITableView view, IEventAggregator eventAggregator) : base(view, eventAggregator)
        {

        }

        protected override IDataConnection<OfferModel> DataConnection
        {
            get => RentACarLibrary.GlobalConfig.OfferModelConection;
        }

        protected override void LoadData()
        {
            OfferModel[] offers = DataConnection.GetAll();
            dataSource = new System.Windows.Forms.BindingSource();
            dataSource.DataSource = offers.ToList();
            view.DataSource = dataSource;
        }

        protected override void SetTableColumns()
        {
            TableColumnInfo[] columnsInfo = new TableColumnInfo[]
            {
                new TableColumnInfo("ID automobila","CarID"),
                new TableColumnInfo("Datum od", "From"),
                new TableColumnInfo("Datum do", "To"),
                new TableColumnInfo("Cena po danu", "PricePerDay")
            };

            view.CreateColumns(columnsInfo);
        }
    }
}
