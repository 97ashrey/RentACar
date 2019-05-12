using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using RentACarLibrary.Models;

namespace UI.Presenters
{
    public static class PresenterHelpers
    {
        public static Dictionary<string, string> ToDict(this CarModel car)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.Add("Brand", car.Brand);
            dict.Add("Model", car.Model);
            dict.Add("CreatedYear", car.CreatedYear.ToString());
            dict.Add("CubicCapacity", car.CreatedYear.ToString());
            dict.Add("CarBody", car.CarBody);
            dict.Add("ShiftType", car.ShiftType);
            dict.Add("DriveType", car.DriveType);
            dict.Add("DorCount", car.DorCount);
            dict.Add("FuelType", car.FuelType);

            return dict;
        }

        public static string CarInfo(this CarModel car)
        {
            string output = $"ID: {car.ID} " +
                            $"Marka: {car.Brand} " +
                            $"Model: {car.Model} " +
                            $"Godište: {car.CreatedYear} " +
                            $"Kubikaža: {car.CubicCapacity} " +
                            $"Pogon: {car.DriveType} " +
                            $"Vrsta menjača: {car.ShiftType} " +
                            $"Karoserija: {car.CarBody} " +
                            $"Gorivo: {car.FuelType} " +
                            $"Broj vrata: {car.DorCount}";
            return output;
        }

        public static string[] months = new string[]
            {
                "Januar",
                "Februar",
                "Mart",
                "April",
                "Maj",
                "Jun",
                "Jul",
                "Avgust",
                "Septrembar",
                "Oktobar",
                "Novembar",
                "Decembar"
            };

        public static Color HsvToRgb(double h, double S, double V)
        {
            double H = h;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0)
            { R = G = B = 0; }
            else if (S <= 0)
            {
                R = G = B = V;
            }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {

                    // Red is the dominant color

                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color

                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    // Blue is the dominant color

                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    // Red is the dominant color

                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = V; // Just pretend its black/white
                        break;
                }
            }
            int r = Clamp((int)(R * 255.0));
            int g = Clamp((int)(G * 255.0));
            int b = Clamp((int)(B * 255.0));

            return Color.FromArgb(r, g, b);
        }

        private static int Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }

        public static bool ValuePicked(this string value)
        {
            return value != null && value != "Izaberi";
        }
    }
}
