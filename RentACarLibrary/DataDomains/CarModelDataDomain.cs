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
            "ručni",
            "automatik",
            "polu automatik"
        };
        //public enum ShiftType
        //{
        //    Manual,
        //    Automatic,
        //    SemiAutomatic
        //}

        public static readonly string[] CarBodies= new string[]
        {
            "kupe",
            "pikap",
            "hečbek",
            "kabriolet",
            "karavan",
            "limuzina",
            "minibus/Van",
            "suv",
            "sedan"
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
            "benzin",
            "dizel",
            "električan",
            "hibrid",
            "cng"
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
            "prednji",
            "zadnji",
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
