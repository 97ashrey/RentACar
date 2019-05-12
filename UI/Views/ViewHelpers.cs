using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.UserControls;
using UI.Events.Messages;

namespace UI.Views
{
    public static class ViewHelpers
    {
        private static UCAlert.AlertType AlertMessageTypeToUCAlertType(AlertMessage.MessageType type)
        {
            switch (type)
            {
                case AlertMessage.MessageType.Error:
                    return UCAlert.AlertType.Danger;
                case AlertMessage.MessageType.Warning:
                    return UCAlert.AlertType.Warning;
                default:
                    return UCAlert.AlertType.Success;
            }
        }

        public static void Display(this UCAlert alert, AlertMessage alertMessage)
        {
            UCAlert.AlertType type = AlertMessageTypeToUCAlertType(alertMessage.Type);
            alert.Display(type, alertMessage.Message);
        }

        // Extension methods for errorProvider

        public static void ClearError(this ErrorProvider errorProvider, Control control)
        {
            if(errorProvider.ControlHasError(control))
                errorProvider.SetError(control, "");
        }

        public static bool ControlHasError(this ErrorProvider errorProvider, Control control)
        {
            return (errorProvider.GetError(control) != "");
        }

        public static void SelectedFocus(this TextBox tb)
        {
            tb.Focus();
            tb.SelectionStart = 0;
            tb.SelectionLength = tb.Text.Length;
        }
    }
}
