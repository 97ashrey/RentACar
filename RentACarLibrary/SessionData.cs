using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACarLibrary.Models;

namespace RentACarLibrary
{
    public static class SessionData
    {
        public static UserModel CurrentUser { get; private set; }

        public static void LogUserIn(UserModel user)
        {
            CurrentUser = user;
        }

        public static void LogUserOut()
        {
            CurrentUser = null;
        }

        public static bool IsAdmin()
        {
            return (CurrentUser is AdminModel);
        }
    }
}
