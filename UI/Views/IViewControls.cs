
namespace UI.Views
{
    public interface IViewControls
    {
        void SetControlError(string controlName, string message);
        void SetControlFocus(string controlName);
        void ClearAllControlErrors();
        void FocusOnTopError();
        void ClearAllControls();
    }
}
