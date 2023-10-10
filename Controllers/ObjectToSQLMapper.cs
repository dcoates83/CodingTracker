using CodingTracker.Modals;
using System.Reflection;

namespace CodingTracker.Controllers
{
    public class SQLColumnsAndValues
    {
        public required string columns { get; set; }
        public required string values { get; set; }
    }

    public class ObjectToSQLMapper
    {

        public static SQLColumnsAndValues MapToSQLColumnsAndValues(CodingSessionModel codingSession)
        {
            var columns = "";
            var values = "";
            Type objType = codingSession.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            foreach (PropertyInfo property in properties)
            {

                var value = property.GetValue(codingSession);

                if (value != null)
                {

                    columns += $"'{property.Name}',";
                    values += $"'{value}',";
                }

            }
            columns = columns.TrimEnd(',');
            values = values.TrimEnd(',');

            return new SQLColumnsAndValues { columns = columns, values = values };

        }
    }
}