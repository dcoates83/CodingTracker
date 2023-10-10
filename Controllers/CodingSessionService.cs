using CodingTracker.DB;
using CodingTracker.Models;

namespace CodingTracker.Controllers
{

    public class CodingSessionService : ObjectToSQLMapper
    {

        private readonly string _connectionString;

        public CodingSessionService(string connectionString)
        {

            _connectionString = connectionString;
        }


        public void GetEndTimeRecord()
        {
            var resp = DBFactory.GetRecord<long>(_connectionString, nameof(CodingSessionModel.Id), nameof(CodingSessionModel.EndTime), "IS NULL");
            Console.WriteLine(resp.ToString());
        }
        public long? GetStartTimeId()
        {

            long? id = DBFactory.GetRecord<long>(_connectionString, nameof(CodingSessionModel.Id), nameof(CodingSessionModel.StartTime), "IS NOT NULL");
            if (id != null)
            {
                return id;
            }
            return null;
        }
        public DateTime? GetStartTime()
        {
            DateTime? startTime = DBFactory.GetRecord<DateTime>(_connectionString, nameof(CodingSessionModel.StartTime), nameof(CodingSessionModel.StartTime), "IS NOT NULL");
            if (startTime != null)
            {
                return startTime;
            }
            return null;
        }




    }
}
