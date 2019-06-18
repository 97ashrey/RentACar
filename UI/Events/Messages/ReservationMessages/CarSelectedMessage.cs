using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACarLibrary.Models;

namespace UI.Events.Messages
{
    class CarSelectedMessage: IApplicationEvent
    {
        public CarModel Car { get; set; }

        public CarSelectedMessage(CarModel car)
        {
            Car = car;
        }
    }
}
