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

        public static void Save(CodingSessionModal codingSession)
        {
            // Convert your CodingSession data to the appropriate database columns and values here
            // For instance, suppose CodingSessionModal contains StartTime, EndTime, and Duration

            var startTime = codingSession.StartTime?.ToString("O");
            var endTime = codingSession.EndTime?.ToString("O");
            var duration = codingSession.Duration?.ToString("c");
            // Use DBFactory to insert the record
            DBFactory.InsertRecord(_connectionString, "StartTime, EndTime, Duration", $"'{startTime}', '{endTime}', '{duration}'");
        }

        // Other methods for updating, deleting, etc.
    }
}
