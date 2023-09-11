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
        public void StartTimer(DateTime initialTime)
        {
            if (_time == null)
            {
                _time = new CodingSessionModal();
                _time.StartTime = initialTime;
            }
            if (_time.StartTime != null)
            {
                Console.WriteLine($"There is already an active timer. Timer: {_time.StartTime.ToString()}");
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
        public void StopTimer(DateTime endTime)
        {
            if (_time != null && _time.StartTime != null)
            {
                _time.EndTime = endTime;
                _time.Duration = _time.EndTime - _time.StartTime;

                Console.WriteLine($"Duration: {_time.Duration}");
            }
            else
            {
                Console.WriteLine("There is no active timer, please start a timer");
            }


        }


    }
}
