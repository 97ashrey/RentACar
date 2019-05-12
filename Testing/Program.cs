using System;
using System.Collections.Generic;
using RentACarLibrary.Models;
using RentACarLibrary;
namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfig.InitializeDataConection();

            //UserModel admin = new UserModel("admin", "admin");

            //RentACarLibrary.GlobalConfig.UserModelConnection.Create(admin);

            //CarModel[] cars = GlobalConfig.CarModelConection.GetAll();
            //OfferModel[] offers = GlobalConfig.OfferModelConection.GetAll();
            //ReservationModel[] reservations = GlobalConfig.ReservationModelConection.GetAll();

            //Console.WriteLine("yaa");


            //CustomerModel customer = new CustomerModel();
            //customer.Username = "aleksa";
            //customer.Password = "aleksa";
            //customer.FirstName = "John";
            //customer.LastName = "Doe";
            //customer.UMCN = "2602997974589";
            //customer.PhoneNumber = "0612234931";
            //customer.DateOfBirth = DateTime.Today;

            //for (int i = 0; i < 10; i++)
            //{
            //    RentACarLibrary.GlobalConfig.UserModelConnection.Create(customer);
            //}

            //UserModel customer = null;
            //CustomerModel c2 = (CustomerModel)customer;

            //UserModel ashrey = RentACarLibrary.GlobalConfig.UserModelConnection.GetByUsername("ashrey97");
            //CarModel car = RentACarLibrary.GlobalConfig.CarModelConection.GetAll()[0];

            //DateTime from = DateTime.Today;
            //DateTime to = from.AddDays(3);

            //ReservationModel reservation = new ReservationModel(
            //    ashrey.ID,
            //    car.ID,
            //    from,
            //    to,
            //    5000
            //    );

            //for (int i=0; i<10; i++)
            //{
            //    RentACarLibrary.GlobalConfig.ReservationModelConection.Create(reservation);
            //}

            //AdminModel admin = new AdminModel("admin", "admin");
            //RentACarLibrary.GlobalConfig.UserModelConnection.Create(admin);
        }

    }

}
