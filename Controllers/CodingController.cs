namespace CodingTracker.Controllers
{
    internal class CodingController
    {

        public string? TimeFormat { get; set; }
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
                    var _timeFormat = new CodingController().TimeFormat = "MM/dd/yyyy hh:mm";

                    Console.WriteLine($"Please provide a Start Time, in the format of {_timeFormat}");
                    var _startTimeResp = Console.ReadLine();
                    DateTime _startTime = Validation.ValidateDateResponse(ref _startTimeResp, _timeFormat);

                    Console.WriteLine($"Please provide a End Time, in the format of {_timeFormat}");
                    var _endTimeResp = Console.ReadLine();
                    DateTime _endTime = Validation.ValidateDateResponse(ref _endTimeResp, _timeFormat);

                    CodingSession.SetStartTime((DateTime)_startTime);
                    CodingSession.SetEndTime((DateTime)_endTime);

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
