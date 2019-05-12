using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Drawing;
using UI.Views.Statistics;
using RentACarLibrary.Models;

namespace UI.Presenters.Statistics
{
    public class StatisticsPresenter
    {
        private IStatisticsView view;

        int sum = 0;
        Dictionary<int, int> carStatisticsNumber;
        Dictionary<int, float> carStatisticsPercentage;

        struct HSV
        {
            public double h;
            public double S;
            public double V;

            public HSV(double h, double s, double v)
            {
                this.h = h;
                S = s;
                V = v;
            }
        }

        HSV hsvColor = new HSV(0, 1, 0.8);

        public StatisticsPresenter(IStatisticsView view)
        {
            this.view = view;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            view.LoadedTrigger += LoadHandler;
            view.DatePicked += DatePickedHandler;
            view.DrawCanvas += DrawCanvasHandler;
            view.DrawLegend += DrawLegendHandler;
        }

        private void CalculateStatistics()
        {
            DateTime date = view.Date;
            ReservationModel[] reservations = RentACarLibrary.GlobalConfig.ReservationModelConection.Filter(
             reservation => reservation.From.Month == date.Month && reservation.To.Month == date.Month
            );


            carStatisticsNumber = new Dictionary<int, int>();
            foreach(ReservationModel reservation in reservations)
            {
                if (!carStatisticsNumber.ContainsKey(reservation.CarID))
                {
                    carStatisticsNumber.Add(reservation.CarID, 1);
                    continue;
                }
                carStatisticsNumber[reservation.CarID] += 1;
            }

            carStatisticsPercentage = new Dictionary<int, float>();
            sum = reservations.Length;
            foreach(int key in carStatisticsNumber.Keys)
            {
                float value = carStatisticsNumber[key];
                float percentage = value * 100 / sum;
                carStatisticsPercentage.Add(key, percentage);
            }
        }

        private float GetDegresFromPercentage(float percentage)
        {
            return 360 * percentage / 100;
        }

        private void SetHeading()
        {
            DateTime date = view.Date;
            string month = PresenterHelpers.months[date.Month - 1];
            string heading = $"Statistika automobila za mesec {month.ToLower()} {date.Year}. godine";
            view.Heading = heading;
        }

        // Event handlers
        private void LoadHandler(object sender, EventArgs e)
        {
            SetHeading();
            CalculateStatistics();
        }

        private void DatePickedHandler(object sender, EventArgs e)
        {
            SetHeading();
            CalculateStatistics();
            view.DrawStatistics();
            view.DrawLegendData();
        }

        private void DrawCanvasHandler(object sender, Graphics g)
        {
            int radius = view.CanvasWidth - 10;
            int x = (view.CanvasWidth / 2) - radius / 2;
            int y = (view.CanvasHeight / 2) - radius / 2;
            Rectangle pieRadius = new Rectangle(x, y, radius, radius);

            g.FillEllipse(Brushes.CadetBlue, pieRadius);

            List<KeyValuePair<int, float>> statList = carStatisticsPercentage.ToList();
            statList.Sort((kv1,kv2) => (int)(kv2.Value - kv1.Value));
            float startAngle = 0;
            foreach(KeyValuePair<int, float> kv in statList)
            {
                float percentage = kv.Value;
                float degrees = GetDegresFromPercentage(percentage);
                Color c = PresenterHelpers.HsvToRgb(startAngle, hsvColor.S, hsvColor.V);
                SolidBrush brush = new SolidBrush(c);
                g.FillPie(brush, pieRadius, -startAngle, -degrees);
                startAngle += degrees;
            }
        }

        private void DrawLegendHandler(object sender, Graphics g)
        {
            int rowHeight = 20;
            int marginBottom = 5;
            int padding = 10;

            int squareSize = rowHeight;

            int y = 30;
            int x = padding;

            Font font = new Font(view.Font.FontFamily, view.Font.Size, view.Font.Style);
            List<KeyValuePair<int, float>> statList = carStatisticsPercentage.ToList();
            statList.Sort((kv1, kv2) => (int)(kv2.Value - kv1.Value));
            double hue = 0;
            foreach (KeyValuePair<int, float> kv in statList)
            {
                float percentage = kv.Value;
                int red = (int)(255 * percentage / 100);

                Color c = PresenterHelpers.HsvToRgb(hue, hsvColor.S, hsvColor.V);
                SolidBrush brush = new SolidBrush(c);
                hue += GetDegresFromPercentage(percentage);
                Rectangle square = new Rectangle(x, y, squareSize, squareSize);
                g.FillRectangle(brush, square);
                CarModel car = RentACarLibrary.GlobalConfig.CarModelConection.Get(kv.Key);

                float p = (float)(Math.Round(percentage));
                string str = $"{car.CarName} {carStatisticsNumber[kv.Key]}/{sum} {p}%";
                g.DrawString(str, font, Brushes.Black, squareSize + 10, y+2);
                y += rowHeight + marginBottom;
            }
        }
    }
}
