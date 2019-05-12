using RentACarLibrary.Models;

namespace RentACarLibrary.DataAccess
{
    public interface IUserDataConnection : IDataConnection<UserModel>
    {
        UserModel GetByUsername(string username);
    }
}
