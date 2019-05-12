using System;
using System.Runtime.Serialization;

namespace RentACarLibrary.Models
{
    [Serializable]
    public class AdminModel: UserModel
    {

        public AdminModel() : base() { }

        public AdminModel(string username, string password)
            : base(username, password)
        {
        }

        public AdminModel(SerializationInfo info, StreamingContext context) :
           base(info, context)
        { }
    }
}
