using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Events
{
    public class RecordSelectedEventArgs : EventArgs
    {
        public enum ClickType
        {
            Single,
            Double
        }

        public int Index { get; private set; }
        public ClickType Type { get; private set; }

        public RecordSelectedEventArgs(int index, ClickType type)
        {
            Index = index;
            Type = type;
        }
    }
}
