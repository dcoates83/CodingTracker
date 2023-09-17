using System.Data.SQLite;

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
        public static int? GetRecord(string connectionString, string select, string column, string searchValue)
        {
            using (var conn = new DBFactory().CreateConnection(connectionString))
            {
                using (var tblCommand = conn.CreateCommand())
                {
                    tblCommand.CommandText = $"SELECT {select} FROM {_table} WHERE {column} {searchValue};";
                    //tblCommand.Parameters.AddWithValue("@SearchValue", searchValue);
                    //var result = tblCommand.ExecuteScalar();
                    using (var reader = tblCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return reader.GetInt32(0); // Gets the integer value from the first column (ID)
                            }
                        }
                    }
                }
            }
            return null;
        }

        //public static int? GetRecord(string connectionString, string select, string column, string searchValue)
        //{
        //    var conn = new DBFactory().CreateConnection(connectionString);
        //    var tblCommand = conn.CreateCommand();

        //    tblCommand.CommandText = $"SELECT {select} FROM {_table} WHERE {column} = @SearchValue";
        //    tblCommand.Parameters.AddWithValue("@SearchValue", searchValue);
        //    tblCommand.ExecuteNonQuery();
        //    var reader = tblCommand.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            return reader.GetInt32(0); // Gets the integer value from the first column (ID)
        //        }
        //    }
        //    reader.Close();
        //    conn.Close();

        //    return null;
        //}
    }
}
