using DVTElevator.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVTUnitTest
{
    public class ElevatorTests
    {

        //Evevator is initialized - 
        [Test]
        public void Elevator_Initialization()
        {
            // Arrange
            int id = 1;
            int initialFloor = 0;
            int maxPassengers = 5;

            // Act
            var elevator = new Elevator(id, initialFloor, maxPassengers);

            // Assert
            Assert.AreEqual(id, elevator.Id);

            Assert.AreEqual(initialFloor, elevator.CurrentFloor);

            Assert.AreEqual(maxPassengers, elevator.MaxPassengers);

            Assert.AreEqual(0, elevator.NumberOfPassengers);
        }

        [Test]
        public void Elevator_Direction_Down()
        {
            // Arrange
            var elevator = new Elevator(id: 1, initialFloor: 5, maxPassengers: 10);
            elevator.TargetFloor = 3;
            elevator.PersonCallingFloor = 8;
            elevator.IsMoving = true;
            elevator.NumberOfPassengers = 2;
        

            // Act
            var directionExpacted  = "Down";

            // Assert
            Assert.AreEqual( directionExpacted, elevator.Direction);
        }

        [Test]
        public void Elevator_Direction_UP()
        {
            // Arrange
            var elevator = new Elevator(id: 1, initialFloor: 2, maxPassengers: 10);
            elevator.TargetFloor = 8;
            elevator.PersonCallingFloor = 8;
            elevator.IsMoving = true;
            elevator.NumberOfPassengers = 12;


            // Act
            var directionExpacted = "UP";

            // Assert
            Assert.AreEqual(directionExpacted, elevator.Direction);
        }

    }
}
