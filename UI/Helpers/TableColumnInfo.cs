using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Helpers
{
    public struct TableColumnInfo
    {
        public string HeaderText { get; set; }
        public string DataPropertyName { get; set; }

        public TableColumnInfo(string headerText, string dataPropertyName)
        {
            HeaderText = headerText;
            DataPropertyName = dataPropertyName;
        }
    }
}
