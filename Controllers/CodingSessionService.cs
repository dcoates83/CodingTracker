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
        static List<string> ReturnPropertyNamesThatHaveValues(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            List<string> propertyNames = new List<string>();

            foreach (PropertyInfo property in properties)
            {

                object value = property.GetValue(obj);
                if (value != null)
                {
                    propertyNames.Add(property.Name);
                }


            }

            return propertyNames;
        }
        static List<string> ReturnPropertyValuesThatHaveValues(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            List<string> propertyNames = new List<string>();

            foreach (PropertyInfo property in properties)
            {

                object value = property.GetValue(obj);
                if (value != null)
                {
                    propertyNames.Add(property.Name);
                }


            }

            return propertyNames;
        }

        static bool VerifyPropertyValues(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            var allPropertiesAreValid = false;
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);
                if (value == null || (property.PropertyType.IsValueType && value.Equals(Activator.CreateInstance(property.PropertyType))))
                {
                    Console.WriteLine($"Property '{property.Name}' has no value.");
                    allPropertiesAreValid = false;
                    break;
                }
                else
                {
                    //Console.WriteLine($"Property '{property.Name}' has a value: {value}");
                    allPropertiesAreValid = true;
                }

            }
            return allPropertiesAreValid;
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

            var result = VerifyPropertyValues(codingSession);
            if (!String.IsNullOrWhiteSpace(columns) && !String.IsNullOrWhiteSpace(values))
            {
                DBFactory.InsertRecord(_connectionString, columns, values);
            }

        }


    }
}
