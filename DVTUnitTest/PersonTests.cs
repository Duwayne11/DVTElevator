using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVTElevator.Data.Model;

namespace DVTUnitTest
{
    public class PersonTests
    {
        [Test]
        public void Person_Initialization()
        {
            // Arrange
            int pickupFloor = 2;
            int destinationFloor = 5;
            int passengers = 3;

            // Act
            var person = new Person(pickupFloor, destinationFloor, passengers);

            // Assert
            Assert.AreEqual(pickupFloor, person.PickupFloor);
            Assert.AreEqual(destinationFloor, person.DestinationFloor);
            Assert.AreEqual(passengers, person.Passengers);
        }

    }
}
