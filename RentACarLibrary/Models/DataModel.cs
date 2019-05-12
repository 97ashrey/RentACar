using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace RentACarLibrary.Models
{
    [Serializable]
    public abstract class DataModel : ISerializable
    {
        public int ID { get; set; }

        protected DataModel()
        {

        }

        protected DataModel(SerializationInfo info, StreamingContext context)
        {
            ID = (int)info.GetValue("ID", typeof(int));
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", ID);
        }
    }
}
