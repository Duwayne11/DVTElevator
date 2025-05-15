using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVTElevator.Data.Model
{
    public class Building
    {
        public List<Elevator> Elevators { get;  set; }
        public int Floors { get;  set; }

        public Building(int numberOfElevators, int floors, int maxPeoplePerElevator)
        {
            Floors = floors; 

            Elevators = new List<Elevator>();

            //Build a list of Elevators and set the max         
            for (int i = 0; i < numberOfElevators; i++)
            {
                Elevators.Add(new Elevator(i + 1, 1, maxPeoplePerElevator));
            }
        }

        public void UpdateElevators(Elevator E)
        {
            //foreach (var elevator in Elevators)
            //{
                E.SimulateElevatorMove();
            //}
        }

        public void ElevatorStatus()
        {
            foreach (var elevator in Elevators)
            {
                //if (elevator.IsMoving)
                //{
                //    Console.WriteLine($"Elevator {elevator.Id}: Is Moving: Direction: {elevator.Direction}, Passengers: {elevator.NumberOfPassengers}/{elevator.MaxPassengers}");
                //}
                //else 
                //{
                    Console.WriteLine($"Elevator {elevator.Id}: Floor {elevator.CurrentFloor}, Direction: {elevator.Direction}, Passengers: {elevator.NumberOfPassengers}/{elevator.MaxPassengers}");
                //}

                
            }
        }
    }
}
