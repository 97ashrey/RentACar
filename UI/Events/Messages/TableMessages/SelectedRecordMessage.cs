using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Events.Messages
{
    public class SelectedRecordMessage<T>: IApplicationEvent
    {
        public T Record { get; private set; }
        public int Index { get; private set; }

        public SelectedRecordMessage(T record, int index)
        { 
            Record = record;
            Index = index;
        }
    }
}
