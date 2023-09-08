namespace CodingTracker.Controllers
{
    internal class CodingController
    {
        static void

        public static void ParseUserInput(string input)
        {
            switch (input)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
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
