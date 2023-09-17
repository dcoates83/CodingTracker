using CodingTracker.Modals;

namespace CodingTracker.Controllers
{
    internal class UserInput
    {
        //private static string _connectionString;


        public static void PromptUser()
        {


            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Main Menu");
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(
                @"
Type 0 to  Close Application
Type 1 to Start a Timer
Type 2 to Stop a Timer
Type 3 to Create a Coding Session Record
Type 4 to View All Records
Type 5 to Delete a Record
Type 6 to Update a Record
");
            Console.WriteLine("-----------------------------------");
        }
        public static string IsValidUserResponse()
        {
            var resp = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(resp))
            {
                Console.WriteLine("Please Enter a valid response");
                return "";
            }
            else
            {
                return resp;
            }
        }
        public static void ParseUserInput(string input)
        {
            var CodingSession = new CodingSession();
            var CodingTime = new CodingSessionModal();

            switch (input)
            {
                case "1":
                    CodingSession.StartTimer();
                    break;
                case "2":
                    CodingSession.StopTimer();

                    //var CodingSessionService = new CodingSessionService(_connectionString);
                    //CodingSessionService.Save(CodingTime);
                    break;
                case "3":
                    CodingSession = CodingSession.CreateTimerRecord(ref CodingTime);

                    break;
                case "4":
                    //Console.WriteLine("Delete A Record");
                    break;
                case "5":
                    //Console.WriteLine("Update A Record");
                    break;
                case "6":
                    Console.WriteLine("");
                    break;
                default:
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Invalid Input, please type a response");
                    }
                    else
                    {
                        Console.WriteLine("Please select a value in the list");
                    }
                    break;
            }


        }
    }
}
