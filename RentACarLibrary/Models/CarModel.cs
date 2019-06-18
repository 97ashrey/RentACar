using System;
using System.Runtime.Serialization;

namespace RentACarLibrary.Models
{
    [Serializable]
    public class CarModel : IDataModel
    {

        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int CreatedYear { get; set; }
        public double CubicCapacity { get; set; }
        public string DriveType { get; set; }
        public string ShiftType { get; set; }
        public string CarBody { get; set; }
        public string FuelType { get; set; }
        public string DorCount { get; set; }

        public string CarName { get => $"{ID} {Brand} {Model}"; }

        public CarModel()
        {

        }

        public CarModel(
            string brand, 
            string model, 
            int createdYear, 
            double cubicCapacity, 
            string driveType, 
            string shiftType, 
            string carBody, 
            string fuelType, 
            string dorCount)
        {
            Brand = brand;
            Model = model;
            CreatedYear = createdYear;
            CubicCapacity = cubicCapacity;
            DriveType = driveType;
            ShiftType = shiftType;
            CarBody = carBody;
            FuelType = fuelType;
            DorCount = dorCount;
        }

        public CarModel(SerializationInfo info, StreamingContext context)
        {
            ID = (int)info.GetValue("ID", typeof(int));
            Brand = info.GetValue("Brand", typeof(string)) as string;
            Model = info.GetValue("Model", typeof(string)) as string;
            CreatedYear = (int)info.GetValue("CreatedYear", typeof(int));
            CubicCapacity = (double)info.GetValue("CubicCapacity", typeof(double));
            DriveType = info.GetValue("DriveType", typeof(string)) as string;
            ShiftType = info.GetValue("ShiftType", typeof(string)) as string;
            CarBody = info.GetValue("CarBody", typeof(string)) as string;
            FuelType = info.GetValue("FuelType", typeof(string)) as string;
            DorCount = info.GetValue("DorCount", typeof(string)) as string;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", ID);
            info.AddValue("Brand", Brand);
            info.AddValue("Model", Model);
            info.AddValue("CreatedYear", CreatedYear);
            info.AddValue("CubicCapacity", CubicCapacity);
            info.AddValue("DriveType", DriveType);
            info.AddValue("ShiftType", ShiftType);
            info.AddValue("CarBody", CarBody);
            info.AddValue("FuelType", FuelType);
            info.AddValue("DorCount", DorCount);
        }
    }
}
