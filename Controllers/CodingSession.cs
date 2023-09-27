using CodingTracker.Modals;
using System.Configuration;

namespace CodingTracker.Controllers
{
    public class CodingSession
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
        public void StartTimer()
        {

            var time = new CodingSessionModal();
            var CodingSessionService = new CodingSessionService(_connectionString);
            //CodingSessionService.GetTimerRecord("start");

            time.StartTime = DateTime.Now;

            Console.WriteLine($"Timer Started at {DateTime.Now.ToString()}");

            CodingSessionService.Save(time);


        }
        // Constructor with an initial time value
        public void SetStartTime(ref CodingSessionModal time, DateTime initialTime)
        {

            if (time == null)
            {
                time = new CodingSessionModal();
                time.StartTime = initialTime;
            }

        }
        public void StopTimer()

        {
            var time = new CodingSessionModal();
            var CodingSessionService = new CodingSessionService(_connectionString);
            //var startTimeId = CodingSessionService.GetStartTimeId();
            var startTime = CodingSessionService.GetStartTime();
            if (startTime == null)
            {
                Console.WriteLine("There is no active timer, please start a timer");
            }
            else if (startTime != null)
            {
                time.EndTime = DateTime.Now;
                time.Duration = time.EndTime - startTime;
                Console.WriteLine($"Timer Ended at {DateTime.Now.ToString()}");
                Console.WriteLine($"Duration: {time.Duration}");
            }



        }
        // Constructor with an initial time value
        public void SetEndTime(ref CodingSessionModal time, DateTime endTime)
        {
            if (time != null && time.StartTime != null)
            {
                time.EndTime = endTime;
                time.Duration = time.EndTime - time.StartTime;

                Console.WriteLine();
                Console.WriteLine($"Duration: {time.Duration}");
            }
            else
            {
                Console.WriteLine("There is no active timer, please start a timer");
            }


        }

        public static CodingSession CreateTimerRecord(ref CodingSessionModal time)
        {
            var CodingSession = new CodingSession();

            var timeFormat = "MM/dd/yyyy hh:mm";
            //var timeFormat = new TimeFomat("MM/dd/yyyy hh:mm")

            Console.WriteLine($"Please provide a Start Time, in the format of {timeFormat}");
            var _startTimeResp = Console.ReadLine();
            DateTime _startTime = Validation.ValidateDateResponse(ref _startTimeResp, timeFormat);

            Console.WriteLine($"Please provide a End Time, in the format of {timeFormat}");
            var _endTimeResp = Console.ReadLine();
            DateTime _endTime = Validation.ValidateDateResponse(ref _endTimeResp, timeFormat);

            CodingSession.SetStartTime(ref time, (DateTime)_startTime);
            CodingSession.SetEndTime(ref time, (DateTime)_endTime);

            return CodingSession;
        }


    }
}
