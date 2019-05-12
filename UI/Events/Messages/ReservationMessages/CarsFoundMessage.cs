using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACarLibrary.Models;

namespace UI.Events.Messages
{
    public class CarsFoundMessage : IApplicationEvent
    {
        public CarModel[] cars { get; private set; }

        public CarsFoundMessage(CarModel[] cars)
        {
            this.cars = cars;
        }
    }
}
