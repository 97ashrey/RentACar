using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Events;
using UI.Helpers;
using UI.Models;
using UI.Views.Data;
using RentACarLibrary.DataAccess;
using RentACarLibrary.Models;

using System.Windows.Forms;

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
            List<OfferModelWrapper> offers = DataConnection
                .GetAll()
                .Select(model => new OfferModelWrapper(model))
                .OrderBy(model => model.To)
                .ToList();
            dataSource = new System.Windows.Forms.BindingSource()
            {
                DataSource = offers
            };
            view.DataSource = dataSource;
        }

        protected override void SetTableColumns()
        {
            TableColumnInfo[] columnsInfo = new TableColumnInfo[]
            {
                new TableColumnInfo("Automobil","CarName"),
                new TableColumnInfo("Datum od", "From"),
                new TableColumnInfo("Datum do", "To"),
                new TableColumnInfo("Cena po danu", "PricePerDay")
            };

            view.CreateColumns(columnsInfo);
        }

        protected override void UpdateRecord(int index, OfferModel data)
        {
            (dataSource[index] as OfferModelWrapper).Offer = data;
        }

        protected override OfferModel GetSelectedRecord(int index)
        {
            return (dataSource.List[index] as OfferModelWrapper).Offer;
        }

        protected override void AddNewRecord(OfferModel data)
        {
            OfferModelWrapper newRecord = new OfferModelWrapper(data);
            dataSource.Add(newRecord);
        }

        protected override OfferModel DeleteRecord(int index)
        {
            OfferModelWrapper wrappedOffer = dataSource.List[index] as OfferModelWrapper;
            OfferModel offer = wrappedOffer.Offer;
            TimePeriod offerPeriod = new TimePeriod(offer.From, offer.To);

            ReservationModel[] reservations = RentACarLibrary.GlobalConfig.ReservationModelConection
                .Filter(model => 
                    {
                        TimePeriod period = new TimePeriod(model.From, model.To);
                        return model.CarID == offer.CarID && offerPeriod.IntersectsWith(period);
                    });

            if (!offerPeriod.IsBefore(DateTime.Today))
            {
                if (reservations.Length > 0)
                {
                    MessageBox.Show(
                        $"{wrappedOffer.OfferInfo()}Ima aktivne rezervacije i neće biti obrisana",
                        "Upozorenje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return null;
                }
            }
            else
            {
                // TODO delete all the reservations for this offer
                foreach(ReservationModel reservation in reservations)
                {
                    RentACarLibrary.GlobalConfig.ReservationModelConection
                        .Delete(reservation.ID);
                }
            }
            offer = DataConnection.Delete(offer.ID);
            return offer;
        }
    }
}
