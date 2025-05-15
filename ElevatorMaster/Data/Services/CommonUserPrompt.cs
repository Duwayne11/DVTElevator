using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVTElevator.Data.Services
{
    public class CommonUserPrompt
    {

        public static void Welcome() 
        {
            string Company = "The Continental Hotel";
            Console.WriteLine($"Welcome to {Company}");
        }

        public static void FunctionalityPrompt() 
        {
            Console.WriteLine("What function would you like to perform: Enter Pickup Floor , Elevator Status - 's'  , Quit - 'q' ");
        }

        public static void DestinationSelectionPrompt() 
        {
            Console.WriteLine("Enter destination floor: ");
        }

        public static void NumberOfPassangersPrompt()  
        {
            Console.WriteLine("Enter number of passengers: ");
        }

        public static void LoadPassangerPrompt() 
        {
            Console.WriteLine($"Loading Pasanger/s . . . ");
        }

        public static void UnLoadPassangerOnFloorPrompt(int CurrentFloor) 
        {
            Console.WriteLine($"Unloading Pasanger/s on the {CurrentFloor} floor . . . ");
        }

        public static void ElevatorInTransitPrompt(int Id,int CurrentFloor) 
        {
            Console.WriteLine($"Elevator {Id} is in transit current floor {CurrentFloor}");
        }

        public static void ReadLine()
        {
            Console.ReadLine();
        }

    }
}
