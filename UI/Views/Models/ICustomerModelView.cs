using System;

namespace UI.Views.Models
{
    public interface ICustomerModelView
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string UMCN { get; set; }
        string PhoneNumber { get; set; }
        DateTime DateOfBirth { get; set; }
    }
}
