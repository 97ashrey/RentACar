using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACarLibrary.Models;
using UI.Events.Messages;
using UI.Views.Login;

namespace UI.Presenters.Login
{
    public class RegisterPresenter
    {
        private IRegisterView view;

        public RegisterPresenter(IRegisterView view)
        {
            this.view = view;
            this.view.RegisterTrigger += Register;
        }

        private bool UserAlreadyExists(string username)
        {
            UserModel user = RentACarLibrary.GlobalConfig.UserModelConnection.GetByUsername(username);
            return (user != null)? true: false;
        }

        private void Register(object sender, EventArgs e)
        {
            if (UserAlreadyExists(view.Username))
            {
                // raise MessageEvent
                AlertMessage m = new AlertMessage(AlertMessage.MessageType.Error, Messages.ErrorUserExists(view.Username));
                view.ShowAlertMessage(m);
                return;
            }
            // Create customer
            CustomerModel customer = new CustomerModel();
            customer.Username = view.Username;
            customer.Password = view.Password;
            customer.FirstName = view.FirstName;
            customer.LastName = view.LastName;
            customer.UMCN = view.UMCN;
            customer.PhoneNumber = view.PhoneNumber;
            customer.DateOfBirth = view.DateOfBirth.Date;

            customer = RentACarLibrary.GlobalConfig.UserModelConnection.Create(customer) as CustomerModel;
            if (customer == null)
            {
                AlertMessage m = new AlertMessage(AlertMessage.MessageType.Error, Messages.ERROR_CUSTOMER_CREATED);
                view.ShowAlertMessage(m);
                return;
            }

            // raise success message
            AlertMessage message = new AlertMessage(AlertMessage.MessageType.Success, Messages.MESSAGE_CUSTOMER_CREATED);
            view.ShowAlertMessage(message);
            view.ClearAllControls();
        }
    }
}
