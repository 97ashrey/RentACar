using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Events.Messages
{
    public class AddRecordMessage<T> : IApplicationEvent
    {
        public T Record { get; private set; }

        public AddRecordMessage(T record)
        {
            Record = record;
        }
    }
}
