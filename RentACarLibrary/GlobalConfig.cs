using System;
using System.IO;
using RentACarLibrary.DataAccess.FileConnection;
using RentACarLibrary.DataAccess;
using RentACarLibrary.Models;
namespace RentACarLibrary
{
    public static class GlobalConfig
    {
        public const string RootDirectory = @"D:\Projects\c#\Rent_a_car\Rent a car";
        public static string GetDataDirectory()
        {
            return $"{RootDirectory}\\data";
        }

        public static string GetUsersDirectory()
        {

            return $"{GetDataDirectory()}\\users";
        }

        public static string GetCarsDirectory()
        {
            return $"{GetDataDirectory()}\\cars";
        }

        public static string GetReservationsDirectory()
        {
            return $"{GetDataDirectory()}\\reservations";
        }

        public static string GetOffersDirectory()
        {
            return $"{GetDataDirectory()}\\offers";
        }

        public static IUserDataConnection UserModelConnection { get; private set; }
        public static IDataConnection<CarModel> CarModelConection { get; private set; }
        public static IDataConnection<ReservationModel> ReservationModelConection { get; private set; }
        public static IDataConnection<OfferModel> OfferModelConection { get; private set; }

        public static void InitializeDataConection()
        {
            UserModelConnection = new UserModelConnection();
            CarModelConection = new CarModelConnection();
            ReservationModelConection = new ReservationModelConnection();
            OfferModelConection = new OfferModelConnection();
        }

        public static void GenerateStorageDirectories()
        {
            // Create storage directories if they dont exist
            if (!Directory.Exists(RootDirectory))
            {
                Directory.CreateDirectory(RootDirectory);
            }
            if (!Directory.Exists(GetDataDirectory()))
            {
                Directory.CreateDirectory(GetDataDirectory());
            }
            if (!Directory.Exists(GetUsersDirectory()))
            {
                Directory.CreateDirectory(GetUsersDirectory());
            }
            if (!Directory.Exists(GetCarsDirectory()))
            {
                Directory.CreateDirectory(GetCarsDirectory());
            }
            if (!Directory.Exists(GetReservationsDirectory()))
            {
                Directory.CreateDirectory(GetReservationsDirectory());
            }
            if (!Directory.Exists(GetOffersDirectory()))
            {
                Directory.CreateDirectory(GetOffersDirectory());
            }
        }
    }
}
