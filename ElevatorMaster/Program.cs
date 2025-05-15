using DVTElevator.Data;
using DVTElevator.Data.Model;
using DVTElevator.Data.Services;
public class Program
{


    public static void Main(string[] args)
    {
     

        // 3 elevators, 10 floors , number of passanger per Elevator
        Building building = new Building(3, 10, 10); 
        ElevatorService controller = new ElevatorService(building);

        while (true)
        {
            CommonUserPrompt.Welcome();
            Console.Clear();
            building.ElevatorStatus();

            CommonUserPrompt.FunctionalityPrompt();
            var input = Console.ReadLine();
            if (input.ToLower() == "q")
            {
                break;
            }

            if (int.TryParse(input, out int pickupFloor))
            {
                controller.ActionUserRequest(pickupFloor);    
            }
        }

        
    }
}