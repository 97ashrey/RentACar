using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UI.Views.Statistics
{
    public interface IStatisticsView : IPresenter, ILoad
    {
        event EventHandler DatePicked;
        event EventHandler<Graphics> DrawCanvas;
        event EventHandler<Graphics> DrawLegend;

        Font Font { get; set; }
        string Heading { get; set; }

        int CanvasWidth { get; }
        int CanvasHeight { get; }

        int legendWidth { get;}
        int LegendHeight { get; }

        void DrawStatistics();
        void DrawLegendData();

        DateTime Date { get; set; }
    }
}
