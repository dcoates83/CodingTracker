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

            return new SQLColumnsAndValues { columns = columns, values = values };

        }
    }
}