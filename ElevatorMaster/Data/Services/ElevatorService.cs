using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVTElevator.Data.Model;

namespace DVTElevator.Data.Services
{
    public class ElevatorService
    {
        private Building _building;

        public ElevatorService(Building building)
        {
            //This defines the building along with elevators/elevator number / 
            _building = building;
        }

        //The end user calls an Elevator - This routine returns the best suited Elevator
        public Elevator? CallElevator(Person Person)
        {
            var suitableElevators = _building.Elevators
                .Where(e => !e.IsMoving || (e.IsMoving && e.Direction == "Stationary"))
                .OrderBy(e => Math.Abs(e.CurrentFloor - Person.PickupFloor))
                .ToList();

            //Do not itterate only do this for one elevator
            Elevator BestSuited = suitableElevators.First();

            bool LoadPassengers = BestSuited.LoadPassengers(Person.Passengers);
            if (LoadPassengers)
            {
                BestSuited.MoveToFloor(Person);

                return BestSuited;
            }

            return null;
        }

        public void Update(Elevator Elevator)
        {
            _building.UpdateElevators(Elevator);
        }

        public void ActionUserRequest(int pickupFloor) 
        {
            Elevator? SelectedForUser = null;
            if (pickupFloor > 0 && pickupFloor <=  this._building.Floors)
            {
                CommonUserPrompt.DestinationSelectionPrompt();

                var input = Console.ReadLine();
                if (int.TryParse(input, out int destinationFloor) && destinationFloor > 0 && destinationFloor <= this._building.Floors)
                {
                    CommonUserPrompt.NumberOfPassangersPrompt();
                    input = Console.ReadLine();

                    if (int.TryParse(input, out int passengers) && passengers > 0)
                    {
                        Person Person = new Person(pickupFloor, destinationFloor, passengers);
                        SelectedForUser = this.CallElevator(Person);//Get the best suited Elevator
                    }
                }
            }

            if (SelectedForUser != null)
            {
                this.Update(SelectedForUser);
            }
        }

    }
}
