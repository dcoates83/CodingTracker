using CodingTracker.DB;
using CodingTracker.Modals;
using System.Reflection;

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


        public void GetEndTimeRecord()
        {
            var resp = DBFactory.GetRecord<long>(_connectionString, nameof(CodingSessionModal.Id), nameof(CodingSessionModal.EndTime), "IS NULL");
            Console.WriteLine(resp.ToString());
        }
        public long? GetStartTimeId()
        {

            long? id = DBFactory.GetRecord<long>(_connectionString, nameof(CodingSessionModal.Id), nameof(CodingSessionModal.StartTime), "IS NOT NULL");
            if (id != null)
            {
                return id;
            }
            return null;
        }
        public DateTime? GetStartTime()
        {
            DateTime? startTime = DBFactory.GetRecord<DateTime>(_connectionString, nameof(CodingSessionModal.StartTime), nameof(CodingSessionModal.StartTime), "IS NOT NULL");
            if (startTime != null)
            {
                return startTime;
            }
            return null;
        }
        public void Save(CodingSessionModal codingSession)
        {

            var columns = "";
            var values = "";
            Type objType = codingSession.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            foreach (PropertyInfo property in properties)
            {

                var value = property.GetValue(codingSession);

                // because id can be 0 when unset it always defaults to 0
                // this causes the bug where you can't save and item with a id of 0 though

                if (value != null && value.GetType() == typeof(int) && (int)value == 0)
                {
                    continue;
                }
                else if (value != null)
                {

                    columns += $"'{property.Name}',";
                    values += $"'{value}',";
                }

            }
            columns = columns.TrimEnd(',');
            values = values.TrimEnd(',');

            DBFactory.InsertRecord(_connectionString, columns, values);
        }


    }
}
