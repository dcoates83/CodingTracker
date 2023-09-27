using System.Data.SQLite;
using System.Globalization;

namespace CodingTracker.DB
{

    internal class DBFactory
    {
        static readonly string _table = "CodingSession";


        public SQLiteConnection CreateConnection(string connectionString)
        {
            var conn = new SQLiteConnection(connectionString);
            conn.Open();
            CreateTable(connectionString);
            return conn;
        }
        public static void CreateTable(string connectionString)
        {
            var conn = new SQLiteConnection(connectionString);
            conn.Open();
            var tblCommand = conn.CreateCommand();
            tblCommand.CommandText = @$"
        CREATE TABLE IF NOT EXISTS {_table} (
            Id        INTEGER PRIMARY KEY,
            StartTime DATETIME,
            EndTime   DATETIME,
            Duration  TIME
        );
        ";
            tblCommand.ExecuteNonQuery();
            conn.Close();
        }
        public static void InsertRecord(string connectionString, string column, string value)
        {
            var conn = new DBFactory().CreateConnection(connectionString);
            var tblCommand = conn.CreateCommand();
            tblCommand.CommandText = @$"
INSERT INTO {_table} (
   {column}
) VALUES ({value});
";
            tblCommand.ExecuteNonQuery();

            conn.Close();
        }
        public static void UpdateRecord(string connectionString, string column, string value, int id)
        {
            var conn = new DBFactory().CreateConnection(connectionString);
            var tblCommand = conn.CreateCommand();
            tblCommand.CommandText = @$"
UPDATE {_table} 
SET {column} = {value}
WHERE Id = {id};
;
";
            tblCommand.ExecuteNonQuery();
        }
        public static void DeleteRecord(string connectionString, int id)
        {
            var conn = new DBFactory().CreateConnection(connectionString);
            var tblCommand = conn.CreateCommand();
            tblCommand.CommandText = @$"
DELETE FROM {_table} WHERE ID = {id};
";
            tblCommand.ExecuteNonQuery();
            conn.Close();
        }
        public static T? GetRecord<T>(string connectionString, string select, string column, string searchValue)
        {
            using (var conn = new DBFactory().CreateConnection(connectionString))
            {
                using (var tblCommand = conn.CreateCommand())
                {
                    tblCommand.CommandText = $"SELECT {select} FROM {_table} WHERE {column} {searchValue};";

                    using (var reader = tblCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            if (typeof(T) == typeof(DateTime))
                            {
                                string dateTimeStr = reader.GetString(0);
                                DateTime parsedDateTime;
                                if (DateTime.TryParseExact(dateTimeStr, "yyyy-MM-dd h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDateTime))
                                {
                                    return (T)(object)parsedDateTime;
                                }
                                else
                                {
                                    // Handle failure to parse DateTime
                                    return default(T);
                                }
                            }
                            else if (reader[0] is T value)
                            {
                                return value;
                            }
                            else
                            {
                                // Handle type mismatch or throw an exception
                                return default(T);
                            }

                        }
                    }
                }
            }
            return default(T);
        }
        public static List<int> GetRecords(string connectionString, string select, string column, string searchValue)
        {
            List<int> results = new List<int>();
            using (var conn = new DBFactory().CreateConnection(connectionString))
            {
                using (var tblCommand = conn.CreateCommand())
                {
                    tblCommand.CommandText = $"SELECT {select} FROM {_table} WHERE {column} {searchValue};";

                    using (var reader = tblCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //TODO: needs to consider other values that just Int's
                                results.Add(reader.GetInt32(0));
                            }
                        }
                    }
                }
            }
            return results;
        }
    }
}
