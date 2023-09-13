using System.Data.SQLite;

namespace CodingTracker.DB
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
            var conn = new SQLiteConnection(connectionString);
            conn.Open();
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
            return conn;
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
        }
        public static int? GetRecordId(string connectionString, string searchValue, string column)
        {
            var conn = new DBFactory().CreateConnection(connectionString);
            var tblCommand = conn.CreateCommand();
            tblCommand.CommandText = $"SELECT id FROM {_table} WHERE {column} = @SearchValue";
            tblCommand.Parameters.AddWithValue("@SearchValue", searchValue);
            tblCommand.ExecuteNonQuery();
            var reader = tblCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    return reader.GetInt32(0); // Gets the integer value from the first column (ID)
                }
            }
            reader.Close();
            conn.Close();

            return null;
        }
    }
}
