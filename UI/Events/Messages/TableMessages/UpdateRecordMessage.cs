using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Events.Messages
{
    public class UpdateRecordMessage<T>: SelectedRecordMessage<T>, IApplicationEvent
    {
        public UpdateRecordMessage(T record, int index) : base(record,index)
        {
        }
    }
}
