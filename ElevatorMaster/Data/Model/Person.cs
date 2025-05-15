using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVTElevator.Data.Model
{
    public class Person
    { 
            public int PickupFloor { get; private set; }
            public int DestinationFloor { get; private set; }
            public int Passengers { get; private set; }

            public Person(int pickupFloor, int destinationFloor, int passengers)
            {
                PickupFloor = pickupFloor;
                DestinationFloor = destinationFloor;
                Passengers = passengers;
            }        
    }
}
