namespace CodingTracker.Controllers
{
    internal class UserInput
    {

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

            switch (input)
            {
                case "1":
                    CodingSession.StartTimer();
                    break;
                case "2":
                    CodingSession.StopTimer();
                    break;
                case "3":
                    CodingSession.CreateTimerRecord();
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
