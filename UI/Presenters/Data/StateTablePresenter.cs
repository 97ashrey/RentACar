using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Data;
using UI.Events;
using UI.Events.Messages;
using RentACarLibrary.Models;

namespace UI.Presenters.Data
{
    public abstract class StateTablePresenter<T>: TablePresenter<T> where T: IDataModel
    {
        protected StateTablePresenter(ITableView view, IEventAggregator eventAggregator) : base(view, eventAggregator)
        {

        }

        bool subscribedToRecordSelected = true;
        
        protected override void SubscribeToEvents()
        {
            base.SubscribeToEvents();
            eventAggregator.Subscribe<ToDefaultStateMessage>(DefaultStateTransitionHandler);
            eventAggregator.Subscribe<ToNewStateMessage>(NewStateTransitionHandler);
        }

        private void SubscribeToRecordSelected()
        {
            if (!subscribedToRecordSelected)
            {
                view.RecordSelected += RecordSelectedHandler;
                subscribedToRecordSelected = true;
            }
        }

        private void UnSubsribedFromRecordSelected()
        {
            if (subscribedToRecordSelected)
            {
                view.RecordSelected -= RecordSelectedHandler;
                subscribedToRecordSelected = false;
            }
        }

        protected virtual void SetStateDefault()
        {
            SubscribeToRecordSelected();
            view.MultiselectEnabled = true;
            view.ClearSelection();
        }

        protected virtual void SetStateUpdate()
        {
            eventAggregator.Publish(new ToUpdateStateMessage());
            view.MultiselectEnabled = false;
        }

        protected virtual void SetStateNew()
        {
            UnSubsribedFromRecordSelected();
            view.MultiselectEnabled = false;
            view.ClearSelection();
        }

        protected override void DoubleClickHandler(int index)
        {
            SetStateUpdate();
            base.DoubleClickHandler(index);
        }

        private void DefaultStateTransitionHandler(ToDefaultStateMessage message)
        {
            SetStateDefault();
        }
    
        private void NewStateTransitionHandler(ToNewStateMessage message)
        {
            SetStateNew();
        }
    }
}
