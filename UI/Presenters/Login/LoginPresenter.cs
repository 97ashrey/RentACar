using System;
using UI.Events.Messages;
using UI.Views.Login;
using RentACarLibrary.Models;

namespace UI.Presenters.Login
{
    public class LoginPresenter
    {
        private ILoginView view;

        public LoginPresenter(ILoginView view)
        {
            this.view = view;
            this.view.LoginTrigger += LoginHandler;
            this.view.RegisterTrigger += RegisterHandler;
        }

        // Event handlers
        private void LoginHandler(object sender, EventArgs e)
        {
            UserModel user = RentACarLibrary.GlobalConfig.UserModelConnection.GetByUsername(view.Username);

            if (user == null)
            {
                AlertMessage am = new AlertMessage(AlertMessage.MessageType.Error, Messages.ErrorUserDoesntExist(view.Username));
                view.ShowAlertMessage(am);
                view.SetControlFocus("Username");
                return;
            }
            if (user.Password != view.Password)
            {
                AlertMessage am = new AlertMessage(AlertMessage.MessageType.Error, Messages.ERROR_WRONG_PASSWORD);
                view.ShowAlertMessage(am);
                view.SetControlFocus("Password");
                return;
            }
            bool isAdmin = (user is AdminModel) ? true : false;
            RentACarLibrary.SessionData.LogUserIn(user);
            view.LoginSuccess();
            view.ClearAllControls();
        }

        private void RegisterHandler(object sender, EventArgs e)
        {
            RegisterView regView = new RegisterView();
            RegisterPresenter registerPresenter = new RegisterPresenter(regView);
            regView.Presenter = registerPresenter;
            regView.ShowDialog();
        }
    }
}
