using CodingTracker.DB;
using CodingTracker.Modals;

namespace CodingTracker.Controllers
{
    public class CodingSessionService
    {
        private readonly DBFactory _dbFactory;
        private readonly string _connectionString;

        public CodingSessionService(string connectionString)
        {
            _dbFactory = new DBFactory();
            _connectionString = connectionString;
        }

        public void Save(CodingSessionModal codingSession)
        {

            var startTime = codingSession.StartTime?.ToString();
            var endTime = codingSession.EndTime?.ToString();
            var duration = codingSession.Duration?.ToString();
            // Use DBFactory to insert the record
            DBFactory.InsertRecord(_connectionString, "StartTime, EndTime, Duration", $"'{startTime}', '{endTime}', '{duration}'");
        }


    }
}
