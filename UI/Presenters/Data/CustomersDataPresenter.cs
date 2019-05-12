using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Events;
using UI.Events.Messages;
using UI.Views.Data;
using UI.Views.Login;
using UI.Presenters.Login;
using RentACarLibrary.Models;


namespace UI.Presenters.Data
{
    public class CustomersDataPresenter
    {
        private ICustomersDataView view;
        private IEventAggregator eventAggregator;

        private SelectedRecordMessage<UserModel> selectedCustomer;

        public CustomersDataPresenter(ICustomersDataView view, IEventAggregator eventAggregator)
        {
            this.view = view;
            this.eventAggregator = eventAggregator;
            SubsribeToEvents();
        }

        private void SubsribeToEvents()
        {
            eventAggregator.Subscribe<AlertMessage>(view.ShowAlertMessage);
            eventAggregator.Subscribe<CrudOperationMessage>(CrudOperationMessageHandler);
            view.LoadedTrigger += LoadHandler;
            view.RegisterNewCustomerTrigger += RegisterNewCustomerHandler;
            view.UpdateCustomerTrigger += UpdateTriggerHandler;
            view.DeleteCustomerTrigger += DeleteTriggerHandler;
            view.CancleTrigger += CancelTriggerHandler;
        }

        private void PopulateView(CustomerModel customer)
        {
            view.FirstName = customer.FirstName;
            view.LastName = customer.LastName;
            view.UMCN = customer.UMCN;
            view.PhoneNumber = customer.PhoneNumber;
            view.DateOfBirth = customer.DateOfBirth;
        }

        private void PopulateCustomer(CustomerModel customer)
        {
            customer.FirstName = view.FirstName;
            customer.LastName = view.LastName;
            customer.UMCN = view.UMCN;
            customer.PhoneNumber = view.PhoneNumber;
            customer.DateOfBirth = view.DateOfBirth.Date;
        }

        private void SetStateDefault()
        {
            eventAggregator.Publish(new ToDefaultStateMessage());
            selectedCustomer = null;
            view.ClearAllControls();
            view.AllInputsEnabled = false;
            view.RegisterNewCustomerTriggerEnabled = true;
            view.UpdateCustomerTriggerEnabled = false;
            view.DeleteCustomerTriggerEnabled = true;
            eventAggregator.Subscribe<ToUpdateStateMessage>(ToUpdateStateMessageHandler);
            eventAggregator.Unsubscribe<SelectedRecordMessage<UserModel>>(RecordSelectedHandler);
        }

        private void SetStateUpdate()
        {
            view.AllInputsEnabled = true;
            view.RegisterNewCustomerTriggerEnabled = false;
            view.UpdateCustomerTriggerEnabled = true;
            view.DeleteCustomerTriggerEnabled = false;
            eventAggregator.Unsubscribe<ToUpdateStateMessage>(ToUpdateStateMessageHandler);
            eventAggregator.Subscribe<SelectedRecordMessage<UserModel>>(RecordSelectedHandler);
        }

        private void UpdateCrudMessage(CrudOperationMessage.CrudResult result)
        {
            switch (result)
            {
                case CrudOperationMessage.CrudResult.Error:
                    AlertMessage error = new AlertMessage(
                        AlertMessage.MessageType.Error,
                        Messages.ERROR_CUSTOMER_UPDATE
                        );
                    view.ShowAlertMessage(error);
                    break;
                default:
                    AlertMessage success = new AlertMessage(
                     AlertMessage.MessageType.Success,
                     Messages.MESSAGE_CUSTOMER_UPDATE
                     );
                    view.ShowAlertMessage(success);
                    break;
            }
        }

        // Event Handlers
        private void LoadHandler(object sender, EventArgs e)
        {
            SetStateDefault();
        }

        private void RecordSelectedHandler(SelectedRecordMessage<UserModel> message)
        {
            selectedCustomer = message;
            PopulateView(message.Record as CustomerModel);
        }

        private void ToUpdateStateMessageHandler(ToUpdateStateMessage message)
        {
            SetStateUpdate();
        }

        private void CancelTriggerHandler(object sender, EventArgs e)
        {
            SetStateDefault();
        }

        private void RegisterNewCustomerHandler(object sender, EventArgs e)
        {
            RegisterView regView = new RegisterView();
            RegisterPresenter registerPresenter = new RegisterPresenter(regView);
            regView.Presenter = registerPresenter;
            regView.ShowDialog();
            eventAggregator.Publish(new ReloadDataMessage());
        }

        private  void UpdateTriggerHandler(object sender, EventArgs e)
        {
            UserModel customer = selectedCustomer.Record;
            PopulateCustomer(customer as CustomerModel);

            UpdateRecordMessage<UserModel> updateMessage = 
                new UpdateRecordMessage<UserModel>(customer, selectedCustomer.Index);
            eventAggregator.Publish(updateMessage);
        }

        private void DeleteTriggerHandler(object sender, EventArgs e)
        {
            eventAggregator.Publish(new DeleteSelectedRecordsMessage());
        }

        private void CrudOperationMessageHandler(CrudOperationMessage message)
        { 
            // This presenter only cares about the update operation
            switch (message.Operation)
            {
                case CrudOperationMessage.CrudOperation.Update:
                    UpdateCrudMessage(message.Result);
                    break;
                default:
                    break;
            }
        }

    }
}
