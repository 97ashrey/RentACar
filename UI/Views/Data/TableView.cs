using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Events;
using UI.Helpers;

namespace UI.Views.Data
{
    public partial class TableView : UserControl, ITableView
    {
        public TableView()
        {
            InitializeComponent();
            Load += TableView_Load;
            VisibleChanged += TableView_VisibleChanged;
            dgv.AutoGenerateColumns = false;
            dgv.MultiSelectChanged += Dgv_MultiSelectChanged;
        }

        public object Presenter { private get; set; }

        // When multiselect is changed dgv clears it's selection
        // this is a quick fix hope it doesn't break
        int selectedIndex = -1;
        private void Dgv_MultiSelectChanged(object sender, EventArgs e)
        {
            if(selectedIndex == -1)
            {
                return;
            }
            dgv.Rows[selectedIndex].Selected = true;
        }

        private void TableView_VisibleChanged(object sender, EventArgs e)
        {
            if(Visible == true)
            {
                LoadData?.Invoke(this, e);
            }
        }

        private void TableView_Load(object sender, EventArgs e)
        {
            LoadData?.Invoke(this, e);
        }

        public event EventHandler<RecordSelectedEventArgs> RecordSelected;
        public event EventHandler LoadData;

        public object DataSource { get => dgv.DataSource; set => dgv.DataSource = value; }

        public int[] SelectedIndexes
        {
            get
            {
                List<int> output = new List<int>();
                for (int i = 0; i < dgv.SelectedRows.Count; i++)
                {
                    output.Add(dgv.SelectedRows[i].Index);
                }
                return output.ToArray();
            }
        }

        public bool MultiselectEnabled { get => dgv.MultiSelect; set => dgv.MultiSelect = value; }
        public bool TableEnabled { get => dgv.Enabled; set => dgv.Enabled = value; }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                return;
            }
            selectedIndex = e.RowIndex;
            RecordSelectedEventArgs args = new RecordSelectedEventArgs(e.RowIndex, RecordSelectedEventArgs.ClickType.Single);
            RecordSelected?.Invoke(this, args);
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RecordSelectedEventArgs args = new RecordSelectedEventArgs(e.RowIndex, RecordSelectedEventArgs.ClickType.Double);
            RecordSelected?.Invoke(this, args);
        }

        public void CreateColumns(TableColumnInfo[] tableColumnInfos)
        {
            foreach(TableColumnInfo columnInfo in tableColumnInfos)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = column.DataPropertyName = columnInfo.DataPropertyName;
                column.HeaderText = columnInfo.HeaderText;
                dgv.Columns.Add(column);
            }
        }

        public void RefreshTable()
        {
            dgv.Refresh();
        }

        public void ClearSelection()
        {
            dgv.ClearSelection();
            selectedIndex = -1;
        }
    }
}
