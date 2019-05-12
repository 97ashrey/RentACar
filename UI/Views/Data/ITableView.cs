using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Events;
using UI.Helpers;

namespace UI.Views.Data
{
    public interface ITableView : IPresenter
    {
        event EventHandler<RecordSelectedEventArgs> RecordSelected;
        event EventHandler LoadData;

        object DataSource { get; set; }
        int[] SelectedIndexes { get; }

        void CreateColumns(TableColumnInfo[] tableColumnInfos);

        void RefreshTable();
        void ClearSelection();
        bool MultiselectEnabled { get; set; }
        bool TableEnabled { get; set; }
    }
}
