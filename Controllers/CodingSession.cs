using CodingTracker.Modals;

namespace CodingTracker.Controllers
{
    public class CodingSession
    {

        public void StartTimer(CodingSessionModal time)
        {
            if (time != null && time.StartTime != null)
            {
                Console.WriteLine($"There is already an active timer. Timer: {time.StartTime.ToString()}");
            }
            else
            {

                time = new CodingSessionModal();
                time.StartTime = DateTime.Now;
                Console.WriteLine($"Timer Started at {DateTime.Now.ToString()}");
            }


        }
        // Constructor with an initial time value
        public void SetStartTime(CodingSessionModal time, DateTime initialTime)
        {

            if (time == null)
            {
                time = new CodingSessionModal();
                time.StartTime = initialTime;
            }

        }
        public void StopTimer(CodingSessionModal time)

        {
            if (time == null)
            {
                Console.WriteLine("There is no active timer, please start a timer");
            }
            else if (time != null && time.StartTime != null)
            {
                time.EndTime = DateTime.Now;
                time.Duration = time.EndTime - time.StartTime;
                Console.WriteLine($"Timer Ended at {DateTime.Now.ToString()}");
                Console.WriteLine($"Duration: {time.Duration}");
            }



        }
        // Constructor with an initial time value
        public void SetEndTime(CodingSessionModal time, DateTime endTime)
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

        public static CodingSession CreateTimerRecord(CodingSessionModal time)
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

            CodingSession.SetStartTime(time, (DateTime)_startTime);
            CodingSession.SetEndTime(time, (DateTime)_endTime);

            return CodingSession;
        }


    }
}
