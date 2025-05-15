using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVTElevator.Data.Services;

namespace DVTElevator.Data.Model
{
    public class Elevator
    {
        public int Id { get;  set; }
        public int CurrentFloor { get;  set; }
        public int TargetFloor { get;  set; }

        public int PersonCallingFloor { get; set; }
        public bool IsMoving { get;  set; }
        public int NumberOfPassengers { get;  set; }
        public int MaxPassengers { get;  set; }

        //The direction will be up down or stationary / 

        //public string Direction => IsMoving ? (CurrentFloor < TargetFloor ? "Up" : "Down") : "Stationary";

        public string Direction 
        {  
            get {
                if (PersonCallingFloor == CurrentFloor && (CurrentFloor > TargetFloor)) //Person and the Elevator are currently on the same floor and will move down
                {
                    return "Down";
                }
                else if ((PersonCallingFloor < CurrentFloor) && (PersonCallingFloor < TargetFloor) )  //The Elevator is on an upper floor and have to decent, pick up the person and than ascend 
                {
                    return "Down_Than_Up";   
                }
                else if (CurrentFloor < TargetFloor)
                {
                    return "UP";
                }
                else if (CurrentFloor > TargetFloor && IsMoving)
                {
                    return "Down";
                }
                else
                {
                    return "Stationary";
                }       
                } 
            //set { Direction = value; }         
        }
            


        public Elevator(int id, int initialFloor, int maxPassengers)
        {
            Id = id;
            CurrentFloor = initialFloor;
            IsMoving = false;
            NumberOfPassengers = 0;
            MaxPassengers = maxPassengers;
        }

        public void MoveToFloor(Person Person)
        {
            TargetFloor = Person.DestinationFloor;
            PersonCallingFloor = Person.PickupFloor;
            IsMoving = true;
        }

        public void SimulateElevatorMove()
        {

            if (Direction == "Down") 
            {
                this.Move_Passanger_Down();
            }
            if (Direction == "UP")
            {
                this.Move_Passanger_Up();
            }
            else if (Direction == "Down_Than_Up")
            {                
                this.Move_Passanger_ElevatorDown_PassangerUp();
            }

        }

        public bool LoadPassengers(int count)
        {
            if (NumberOfPassengers + count <= MaxPassengers)
            {
                NumberOfPassengers += count;
                return true;
            }
            return false;
        }

        public void UnloadPassengers(int count)
        {
            NumberOfPassengers = Math.Max(0, NumberOfPassengers - count);
            PersonCallingFloor = TargetFloor;
        }

        public void Move_Passanger_Down() 
        {
            bool continueToMove = true;

            int decrFloor = CurrentFloor;
            //for (int i = 1; i < CurrentFloor; i++)
            while (CurrentFloor > TargetFloor)
            {
                decrFloor--;
                CurrentFloor = decrFloor;

                if (decrFloor == PersonCallingFloor)
                {
                    CommonUserPrompt.LoadPassangerPrompt();
                }
                else
                {
                    CommonUserPrompt.ElevatorInTransitPrompt(Id, decrFloor);
                }

                Thread.Sleep(1000);
            }

            CurrentFloor = decrFloor;


            if (decrFloor == TargetFloor)
            {
                CommonUserPrompt.UnLoadPassangerOnFloorPrompt(CurrentFloor);
                this.UnloadPassengers(NumberOfPassengers);
                continueToMove = false;
            }
            else
            {
                //Pick up the passanger on the lower down floor and take them to their destination floor
                CommonUserPrompt.LoadPassangerPrompt();
            }
        }

        public void Move_Passanger_Up() 
        {
            //The elevator is moving up
            Console.WriteLine($"Elevator {Id} is moving to floor {TargetFloor}");

            if (CurrentFloor < TargetFloor)
            {

                for (int i = 1; i < TargetFloor; i++)
                {
                    Console.WriteLine($"Elevator {Id} is in transit current floor {i}");
                    Thread.Sleep(1000);
                }

                CurrentFloor = TargetFloor;

                this.UnloadPassengers(NumberOfPassengers);
            }
            //else if (CurrentFloor > TargetFloor)
            //{
            //    CurrentFloor--;
            //}

            //The elevator is Stationary 
            if (CurrentFloor == TargetFloor)
                IsMoving = false;
        }

        public void Move_Passanger_ElevatorDown_PassangerUp() 
        {
            if (PersonCallingFloor < CurrentFloor)  //Move Down - Then Up
            {
                while (CurrentFloor > PersonCallingFloor) //Elevator moving down to pick up the person/s
                {
                    CurrentFloor--;

                    if (CurrentFloor == PersonCallingFloor)
                    {
                        CommonUserPrompt.LoadPassangerPrompt();
                    }
                    else
                    {
                        CommonUserPrompt.ElevatorInTransitPrompt(Id, CurrentFloor);
                    }

                    Thread.Sleep(1000);
                }

                while (CurrentFloor < TargetFloor)  //Move up
                {
                    CurrentFloor++;

                    if (CurrentFloor == PersonCallingFloor)
                    {
                        CommonUserPrompt.LoadPassangerPrompt();
                    }
                    else
                    {
                        CommonUserPrompt.ElevatorInTransitPrompt(Id, CurrentFloor);
                    }

                    Thread.Sleep(1000);
                }

                this.UnloadPassengers(NumberOfPassengers);
            }
        }

        //public override string ToString()
        //{
        //    return $"Elevator {Id}: Floor {CurrentFloor}, Direction: {Direction}, Passengers: {NumberOfPassengers}/{MaxPassengers}";
        //}
    }
}
