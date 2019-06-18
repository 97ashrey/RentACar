using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Views.Statistics
{
    public partial class StatisticsView : UserControl, IStatisticsView
    {
        public StatisticsView()
        {
            InitializeComponent();
            
            dtpControl.DateTimePicker.Format = DateTimePickerFormat.Custom;
            dtpControl.DateTimePicker.CustomFormat = "MMMM yyyy"; // this line gives you only the month and year.
            dtpControl.DateTimePicker.ShowUpDown = true;

            panelCanvas.Paint += panelCanvas_Paint;
            gbLegend.Paint += gbLegend_Paint;

            dtpControl.DateTimePicker.ValueChanged += dtp_ValueChanged;
            Load += LoadHandler;
        }

        private void LoadHandler(object sender, EventArgs e)
        {
            dtpControl.Date = DateTime.Today;
            LoadedTrigger?.Invoke(this, e);
            ParentChanged += ReloadHandler;
        }

        private void ReloadHandler(object sender, EventArgs e)
        {
            if(Parent != null)
                LoadedTrigger?.Invoke(this, e);
        }

        public string Heading { get => lblHeading.Text; set => lblHeading.Text = value; }

        public int CanvasWidth { get => panelCanvas.ClientSize.Width; }
        public int CanvasHeight { get => panelCanvas.ClientSize.Height; }
        public int legendWidth { get => gbLegend.ClientSize.Width; }
        public int LegendHeight { get => gbLegend.ClientSize.Height; }

        public DateTime Date { get => dtpControl.Date; set => dtpControl.Date = value; }
        public object Presenter { private get; set; }

        public event EventHandler DatePicked;
        public event EventHandler<Graphics> DrawCanvas;
        public event EventHandler<Graphics> DrawLegend;
        public event EventHandler LoadedTrigger;

        public void DrawLegendData()
        {
            gbLegend.Invalidate();
        }

        public void DrawStatistics()
        {
            panelCanvas.Invalidate();
        }

        private void gbLegend_Paint(object sender, PaintEventArgs e)
        {
            DrawLegend?.Invoke(this, e.Graphics);
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            DrawCanvas?.Invoke(this, e.Graphics);
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            DatePicked?.Invoke(this, e);
        }
    }
}
