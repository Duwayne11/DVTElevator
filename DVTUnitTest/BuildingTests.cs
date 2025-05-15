using DVTElevator.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVTUnitTest
{
    public class BuildingTests
    {

        //On constructor initialization a building is created in which the number of elevators are defined along with the max amount of passanges each
        //elevator can accomodate

        [Test]
        public void Buildinginitialization()
        {
            // Arrange
            int numberOfElevators = 3;
            int floors = 10;
            int maxPeoplePerElevator = 5;


            // Act
            var building = new Building(numberOfElevators, floors, maxPeoplePerElevator);
            

            // Assert Elevators
            Assert.AreEqual(numberOfElevators, building.Elevators.Count);

            Assert.AreEqual(floors, building.Floors);

            var ElevatorsInBuilding = building.Elevators;

            foreach (Elevator elevator in building.Elevators)
            {    
                Assert.AreEqual(maxPeoplePerElevator, elevator.MaxPassengers);
            }
        }

        //[Test]
        //public void UpdateElevators_Calls_SimulateElevatorMove_On_Elevator()
        //{
        //    // Arrange
        //    var elevator = new TestElevator(1, 1, 5);
        //    var building = new Building(1, 10, 5);

        //    // Act
        //    building.UpdateElevators(elevator);

        //    // Assert
        //    Assert.IsTrue(elevator.SimulateCalled);
        //}

        //// Helper test double for Elevator
        //private class TestElevator : Elevator
        //{
        //    public bool SimulateCalled { get; private set; } = false;

        //    public TestElevator(int id, int initialFloor, int maxPassengers)
        //        : base(id, initialFloor, maxPassengers) { }

        //    public  void SimulateElevatorMove()
        //    {
        //        SimulateCalled = true;
        //    }
        //}
    }
}
