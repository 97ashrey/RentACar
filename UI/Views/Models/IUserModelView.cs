using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Views.Models
{
    public interface IUserModelView
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
