using System;
using System.Runtime.Serialization;


namespace RentACarLibrary.Models
{
    [Serializable]
    public class CustomerModel : UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        /// <summary>
        /// Represents Unique Master Citizen Number
        /// </summary>
        public string UMCN { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName { get => $"{ID} {Username} {FirstName} {LastName}"; }

        public CustomerModel() : base()
        {

        }

        public CustomerModel(
            string username,
            string password,
            string firstName,
            string lastName,
            string umcn,
            DateTime dateOfBirth,
            string telephoneNumber)
            : base(username, password)
        {
            FirstName = firstName;
            LastName = lastName;
            UMCN = umcn;
            DateOfBirth = dateOfBirth;
            PhoneNumber = telephoneNumber;
        }

        public CustomerModel(SerializationInfo info, StreamingContext context) :
            base(info,context)
        {
            FirstName = info.GetValue("FirstName", typeof(string)) as string;
            LastName = info.GetValue("LastName", typeof(string)) as string;
            UMCN = info.GetValue("UMCN", typeof(string)) as string;
            DateOfBirth = (DateTime)info.GetValue("DateOfBirth", typeof(DateTime));
            PhoneNumber = info.GetValue("Phone", typeof(string)) as string;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("FirstName", FirstName);
            info.AddValue("LastName", LastName);
            info.AddValue("UMCN", UMCN);
            info.AddValue("DateOfBirth", DateOfBirth);
            info.AddValue("Phone", PhoneNumber);
        }
    }
}
