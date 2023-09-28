using CodingTracker.DB;
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

            time.StartTime = DateTime.Now;

            Console.WriteLine($"Timer Started at {DateTime.Now}");

            CodingSessionService.InsertNewCodingSession(time);


        }
        public void SetStartTime(DateTime initialTime)
        {
            var time = new CodingSessionModal();
            var CodingSessionService = new CodingSessionService(_connectionString);

            time.StartTime = initialTime;

            CodingSessionService.InsertNewCodingSession(time);
        }
        public void StopTimer()

        {
            var time = new CodingSessionModal();
            var CodingSessionService = new CodingSessionService(_connectionString);
            var startTime = CodingSessionService.GetStartTime();
            var id = (int?)CodingSessionService.GetStartTimeId();

            if (startTime == null)
            {
                Console.WriteLine("There is no active timer, please start a timer");
            }
            else if (startTime != null && id != null)
            {
                time.EndTime = DateTime.Now;
                time.StartTime = startTime;
                time.Duration = time.EndTime - time.StartTime;
                try
                {
                    DBFactory.UpdateRecord(_connectionString, nameof(time.EndTime), $"'{time.EndTime?.ToString("yyyy-MM-dd HH:mm:ss")}'", (int)id);
                    DBFactory.UpdateRecord(_connectionString, nameof(time.Duration), value: time.Duration?.TotalSeconds, (int)id);
                    //CodingSessionService.UpdateExistingCodingSessionById(time, (int)id);
                    Console.WriteLine($"Timer Ended at {DateTime.Now.ToString()}");
                    Console.WriteLine($"Duration: {time.Duration}");
                }
                catch (Exception)
                {

                    throw;
                }

            }



        }
        public void SetEndTime(DateTime endTime)
        {
            var time = new CodingSessionModal();
            var CodingSessionService = new CodingSessionService(_connectionString);
            var startTime = CodingSessionService.GetStartTime();
            var id = (int?)CodingSessionService.GetStartTimeId();

            if (time != null && startTime != null && id != null)
            {
                time.Id = (int)id;
                time.StartTime = startTime;
                time.EndTime = endTime;
                time.Duration = time.EndTime - time.StartTime;

                CodingSessionService.UpdateExistingCodingSessionById(time, (int)id);
                Console.WriteLine();
                Console.WriteLine($"Duration: {time.Duration}");

            }
            else
            {
                Console.WriteLine("There is no active timer, please start a timer");
            }


        }

        public static void CreateTimerRecord()
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

            CodingSession.SetStartTime((DateTime)_startTime);
            CodingSession.SetEndTime((DateTime)_endTime);

        }


    }
}
