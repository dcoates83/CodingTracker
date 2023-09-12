using CodingTracker.Modals;

namespace CodingTracker.Controllers
{
    public class CodingSession
    {

        private CodingSessionModal? _time;

        public void StartTimer()
        {
            if (_time == null)
            {

                _time = new CodingSessionModal();
                _time.StartTime = DateTime.Now;
                Console.WriteLine($"Timer Started at {DateTime.Now.ToString()}");
            }
            if (_time.StartTime != null)
            {
                Console.WriteLine($"There is already an active timer. Timer: {_time.StartTime.ToString()}");
            }

        }
        // Constructor with an initial time value
        public void SetStartTime(DateTime initialTime)
        {

            if (_time == null)
            {
                _time = new CodingSessionModal();
                _time.StartTime = initialTime;
            }

        }
        public void StopTimer()
        {
            if (_time != null && _time.StartTime != null)
            {
                _time.EndTime = DateTime.Now;
                _time.Duration = _time.EndTime - _time.StartTime;
                Console.WriteLine($"Timer Ended at {DateTime.Now.ToString()}");
                Console.WriteLine($"Duration: {_time.Duration}");
            }
            else
            {
                Console.WriteLine("There is no active timer, please start a timer");
            }


        }
        // Constructor with an initial time value
        public void SetEndTime(DateTime endTime)
        {
            if (_time != null && _time.StartTime != null)
            {
                _time.EndTime = endTime;
                _time.Duration = _time.EndTime - _time.StartTime;

                Console.WriteLine();
                Console.WriteLine($"Duration: {_time.Duration}");
            }
            else
            {
                Console.WriteLine("There is no active timer, please start a timer");
            }


        }

        public static CodingSession CreateTimerRecord()
        {
            var CodingSession = new CodingSession();

            var _timeFormat = "MM/dd/yyyy hh:mm";
            //var _timeFormat = new TimeFomat("MM/dd/yyyy hh:mm")

            Console.WriteLine($"Please provide a Start Time, in the format of {_timeFormat}");
            var _startTimeResp = Console.ReadLine();
            DateTime _startTime = Validation.ValidateDateResponse(ref _startTimeResp, _timeFormat);

            Console.WriteLine($"Please provide a End Time, in the format of {_timeFormat}");
            var _endTimeResp = Console.ReadLine();
            DateTime _endTime = Validation.ValidateDateResponse(ref _endTimeResp, _timeFormat);

            CodingSession.SetStartTime((DateTime)_startTime);
            CodingSession.SetEndTime((DateTime)_endTime);

            return CodingSession;
        }

        public void Save()
        {
            var service = new CodingSessionService("your_connection_string_here");
            service.Save(this);
        }
    }
}
