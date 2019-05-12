using RentACarLibrary.Models;

namespace RentACarLibrary.DataAccess.FileConnection
{
    public class UserModelConnection : DataConnection<UserModel>, IUserDataConnection
    {
        public UserModelConnection() : base(GlobalConfig.GetUsersDirectory())
        {
        }

        public UserModel GetByUsername(string username)
        {
            UserModel[] users = Filter(model => model.Username == username);
            if(users.Length == 0)
            {
                return null;
            }
            return users[0];
        }
    }
}
