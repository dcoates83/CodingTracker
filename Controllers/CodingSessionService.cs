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


        public void GetTimerRecord(string mode)
        {
            var CodingModal = new CodingSessionModal();
            string Id = nameof(CodingModal.Id);
            switch (mode)
            {
                case "start":
                    {
                        string StartTime = nameof(CodingModal.StartTime);
                        var resp = DBFactory.GetRecord(_connectionString, Id, StartTime, "IS NULL");
                        Console.WriteLine(resp.ToString());
                        break;
                    }
                case "stop":
                    {
                        string EndTime = nameof(CodingModal.EndTime);
                        var resp = DBFactory.GetRecord(_connectionString, Id, EndTime, "IS NULL");
                        Console.WriteLine(resp.ToString());
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public void Save(CodingSessionModal codingSession)
        {


            var columns = "";
            var values = "";
            Type objType = codingSession.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(codingSession);
                if (value != null)
                {
                    columns += property.Name;
                    values += $"'{value}'";
                }

            }

        }


    }
}
