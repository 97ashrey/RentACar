using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using UI.Views.Data;
using UI.Events;
using UI.Events.Messages;
using RentACarLibrary.Models;
using RentACarLibrary.DataAccess;
using System.Windows.Forms;

namespace UI.Presenters.Data
{
    public abstract class TablePresenter<T> where T: IDataModel
    {
        protected IEventAggregator eventAggregator;
        protected ITableView view;
        protected abstract IDataConnection<T> DataConnection { get;}

        protected BindingSource dataSource;

        protected TablePresenter(ITableView view, IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.view = view;
            SubscribeToEvents();
            SetTableColumns();
        }

        protected virtual void SubscribeToEvents()
        {
            view.RecordSelected += RecordSelectedHandler;
            view.LoadData += LoadDataHandler;
            eventAggregator.Subscribe<AddRecordMessage<T>>(AddRecordHandler);
            eventAggregator.Subscribe<UpdateRecordMessage<T>>(UpdateRecordHandler);
            eventAggregator.Subscribe<DeleteSelectedRecordsMessage>(DeleteSelectedRecordsHandler);
            eventAggregator.Subscribe<ReloadDataMessage>(ReloadDataHandler);
        }

        protected abstract void SetTableColumns();

        protected abstract void LoadData();

        protected virtual string GetDeleteConfirmMessage()
        {
            string count = view.SelectedIndexes.Length == 1 ? "zapis" : "zapisa";
            return $"Želite da obrišete {view.SelectedIndexes.Length} {count}?";
        }

        protected virtual void SendCrudMessage(CrudOperationMessage.CrudOperation operation, CrudOperationMessage.CrudResult result)
        {
            // Raise update error
            CrudOperationMessage crudMessage = new CrudOperationMessage(operation,result);
            eventAggregator.Publish<CrudOperationMessage>(crudMessage);
        }

        // Overidable steps for crud handlers
        protected virtual bool ConfirmDeleteion()
        {
            DialogResult result = MessageBox.Show(
                            view as IWin32Window,
                            GetDeleteConfirmMessage(),
                            "Upozorenje",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);
            return (result == DialogResult.Yes)? true: false;
        }

        protected virtual T DeleteRecord(int index)
        {
            T model = (T)dataSource[index];
            model = DataConnection.Delete(model.ID);
            return model;
        }

        protected virtual void UpdateRecord(int index, T data)
        {
            dataSource[index] = data;
        }

        protected virtual T GetSelectedRecord(int index)
        {
            return (T)dataSource.List[index];
        }

        protected virtual void AddNewRecord(T data)
        {
            dataSource.Add(data);
        }

        // Event Handlers
        protected virtual void LoadDataHandler(object sender, EventArgs e)
        {
            LoadData();
        }

        protected virtual void RecordSelectedHandler(object sender, RecordSelectedEventArgs e)
        {
            if (e.Type == RecordSelectedEventArgs.ClickType.Single)
            {
                SingleClickHandler(e.Index);
            }
            else
            {
                DoubleClickHandler(e.Index);
            }
        }
        
        protected virtual void DoubleClickHandler(int index)
        {
            SendSelectedRecordMessage(index);
        }

        protected virtual void SingleClickHandler(int index)
        {
            SendSelectedRecordMessage(index);
        }

        protected virtual void SendSelectedRecordMessage(int index)
        {
            T selectedRecord = GetSelectedRecord(index);
            SelectedRecordMessage<T> recordMessage = new SelectedRecordMessage<T>(selectedRecord, index);
            eventAggregator.Publish(recordMessage);
        }

        // Crud Handlers
        protected virtual void UpdateRecordHandler(UpdateRecordMessage<T> message)
        {
            // index out of range error
            bool indexInList = dataSource.Count > message.Index;
            if (!indexInList)
            {
                SendCrudMessage(
                    CrudOperationMessage.CrudOperation.Update,
                    CrudOperationMessage.CrudResult.Error);
                return;
            }
            T record = DataConnection.Update(message.Record);
            if (record == null)
            {
                SendCrudMessage(
                    CrudOperationMessage.CrudOperation.Update,
                    CrudOperationMessage.CrudResult.Error);
                return;
            }
            // this part needs to be overidable
            UpdateRecord(message.Index, message.Record);
            //dataSource[message.Index] = message.Record;
            view.RefreshTable();
            // Raise update success
            SendCrudMessage(
                     CrudOperationMessage.CrudOperation.Update,
                     CrudOperationMessage.CrudResult.Success);
        }

        protected virtual void DeleteSelectedRecordsHandler(DeleteSelectedRecordsMessage message)
        {
            int numberOfRecords = view.SelectedIndexes.Length;
            if (numberOfRecords <= 0)
            {
                // TODO Mybe raise message?
                return;
            }
            // Overridable step
            if (!ConfirmDeleteion())
            {
                return;
            }
            int deletedRecords = 0;
            foreach (int index in view.SelectedIndexes)
            {
                // Overidable step
                T model = DeleteRecord(index);
                if (model == null)
                {
                    // TODO mybe raise error
                    continue;
                }
                dataSource.RemoveAt(index);
                deletedRecords += 1;
            }
            view.DataSource = dataSource;
            // Raise deletion success
            if (deletedRecords != 0)
            {
                AlertMessage alertMessage =
                    new AlertMessage(
                        AlertMessage.MessageType.Success,
                        Messages.MessageDeletionSuccess(deletedRecords, numberOfRecords)
                        );
                eventAggregator.Publish(alertMessage);
                SendCrudMessage(CrudOperationMessage.CrudOperation.Delete, CrudOperationMessage.CrudResult.Success);
            }
        }

        protected virtual void AddRecordHandler(AddRecordMessage<T> message)
        {
            T newRecord = DataConnection.Create(message.Record);
            if (newRecord == null)
            {
                SendCrudMessage(CrudOperationMessage.CrudOperation.Create, CrudOperationMessage.CrudResult.Error);
                return;
            }
            AddNewRecord(newRecord);
            SendCrudMessage(CrudOperationMessage.CrudOperation.Create, CrudOperationMessage.CrudResult.Success);
        }

        protected virtual void ReloadDataHandler(ReloadDataMessage message)
        {
            LoadData();
        }
    }
}
