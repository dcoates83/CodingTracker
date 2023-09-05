namespace CodingTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _running = true;
            while (_running)
            {
                UserInput.PromptUser();
                var resp = UserInput.UserResponse();

                if (resp != null && resp == "0")
                {
                    _running = false;
                }
                //var DB = new DBFactory().CreateConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);

                Console.WriteLine(resp);
            }
            //var test = ConfigurationManager.ConnectionStrings[1].ConnectionString;

            // create a table
            // modal that maps the database entities

            // class that deals with validation?
            // class that handles the SQL connections
            // class that calculates the coding session
        }

    }

}