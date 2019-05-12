using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RentACarLibrary.Models
{
    public interface IDataModel : ISerializable
    {
        int ID { get; set; }
    }
}
