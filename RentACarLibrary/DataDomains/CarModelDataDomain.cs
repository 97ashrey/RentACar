using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarLibrary.DataDomains
{
    public static class CarModelDataDomain
    {
        public static readonly string[] ShiftTypes = new string[]
        {
            "Ručni",
            "Automatik",
            "Polu automatik"
        };
        //public enum ShiftType
        //{
        //    Manual,
        //    Automatic,
        //    SemiAutomatic
        //}

        public static readonly string[] CarBodies= new string[]
        {
            "Kupe",
            "Pikap",
            "Hečbek",
            "Kabriolet",
            "Karavan",
            "Limuzina",
            "Minibus/Van",
            "SUV",
            "Sedan"
        };

        //public enum CarBody
        //{
        //    Coupe,
        //    Pickup,
        //    Hatchback,
        //    Convertible,
        //    Caravan,
        //    Limousine,
        //    Van,
        //    SUV
        //}

        public static readonly string[] FuelTypes = new string[]
        {
            "Benzin",
            "Dizel",
            "Električan",
            "Hibrid",
            "CNG"
        };

        //public enum FuelType
        //{
        //    Gasoline,
        //    Diesel,
        //    Electric,
        //    Hybrid,
        //    CNG
        //}

        public static readonly string[] DriveTypes = new string[]
        {
            "Prednji",
            "Zadnji",
            "4x4"
        };

        //public enum DriveType
        //{
        //    Front,
        //    Back,
        //    ALL_FOUR
        //}

        public static readonly string[] DorCount  = new string[]
        {
            "2/3",
            "4/5",
            "6/7"
        };

        public static readonly string[] CubicCapacity = new string[]
        {
            "50",
            "125",
            "250",
            "400",
            "600",
            "900",
            "1100",
            "1300",
            "1600",
            "1900",
            "2000",
            "2500",
            "3000",
            "3500",
            "8000"
        };

        public static List<string> GetCreatedYearDomain()
        {
            List<string> output = new List<string>();
            int yearStep = 1;
            int yearTop = DateTime.Now.Year;
            int yearBottom = 1980;
            int middleGround = 2000;

            int currentYear = yearTop;

            while (currentYear >= yearBottom)
            {
                output.Add(currentYear.ToString());
                if (currentYear == middleGround)
                {
                    yearStep = 5;
                }
                currentYear -= yearStep;
            }

            return output;
        }

        
    }
}
