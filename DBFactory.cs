using System.Data.SQLite;

namespace CodingTracker
{
    internal class DBFactory
    {
        public SQLiteConnection CreateConnection(string connectionString)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                return conn;
            }
        }
        public static void CreateDatabase(string connectionString)
        {
            var conn = new DBFactory().CreateConnection(connectionString);
            var tblCommand = conn.CreateCommand();
            tblCommand.CommandText = @"
CREATE TABLE IF NOT EXISTS CodingSession (
    ID        INT  NOT NULL,
    StartTime TIME ,
    EndTime   TIME ,
    Duration  TIME ,
    PRIMARY KEY (
        ID
    )
);
";
            tblCommand.ExecuteNonQuery();
            conn.Close();
        }
    }
}
