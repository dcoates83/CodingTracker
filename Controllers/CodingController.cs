namespace CodingTracker.Controllers
{
    internal class CodingController
    {

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
                    Console.WriteLine("Please provide a Start Time");
                    var _startTimeResp = Console.ReadLine();
                    DateTime _startTime = Validation.ValidateDateResponse(ref _startTimeResp);

                    Console.WriteLine("Please provide a End Time");
                    var _endTimeResp = Console.ReadLine();
                    DateTime _endTime = Validation.ValidateDateResponse(ref _endTimeResp);

                    CodingSession.StartTimer((DateTime)_startTime);
                    CodingSession.StopTimer((DateTime)_endTime);

                    break;
                case "4":
                    Console.WriteLine("Delete A Record");
                    break;
                case "5":
                    Console.WriteLine("Update A Record");
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
