using System;
using UI.Views.Models;

namespace UI.Views.Login
{
    public interface ILoginView : IUserModelView, IViewControls, IAlert, IPresenter
    {
        event EventHandler LoginTrigger;
        event EventHandler RegisterTrigger;

        void LoginSuccess();
    }
}
