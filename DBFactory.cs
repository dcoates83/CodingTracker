using System.Data.SQLite;

namespace CodingTracker
{

    internal class DBFactory
    {
        static readonly string _table = "CodingSession";

        static string GetTable()
        {
            return _table;
        }
        public SQLiteConnection CreateConnection(string connectionString)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                return conn;
            }
        }
        public static void CreateTable(string connectionString)
        {
            var conn = new DBFactory().CreateConnection(connectionString);
            var tblCommand = conn.CreateCommand();
            tblCommand.CommandText = @$"
CREATE TABLE IF NOT EXISTS {_table} (
    Id        INT  NOT NULL,
    StartTime TIME,
    EndTime   TIME,
    Duration  TIME,
    PRIMARY KEY (
        Id
    )
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
        }
    }
}
