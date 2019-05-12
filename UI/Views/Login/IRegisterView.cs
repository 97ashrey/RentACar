using System;
using UI.Views.Models;

namespace UI.Views.Login
{
    public interface IRegisterView: IUserModelView, ICustomerModelView, IAlert, IViewControls, IPresenter
    {
        event EventHandler RegisterTrigger;
    }
}
