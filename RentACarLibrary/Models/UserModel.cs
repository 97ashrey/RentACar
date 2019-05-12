using System;
using System.Runtime.Serialization;

namespace RentACarLibrary.Models
{
    [Serializable]
    public class UserModel : IDataModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserModel()
        {

        }

        public UserModel(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public UserModel(SerializationInfo info, StreamingContext context) 
        {
            ID = (int)info.GetValue("ID", typeof(int));
            Username = (string)info.GetValue("Username", typeof(string));
            Password = (string)info.GetValue("Password", typeof(string));
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", ID);
            info.AddValue("Username", Username);
            info.AddValue("Password", Password);
        }

        public override string ToString()
        {
            return Username;
        }
    }
}
