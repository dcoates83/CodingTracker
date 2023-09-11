namespace CodingTracker
{
    internal class UserInput
    {
        public static void PromptUser()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Main Menu");
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(
                @"
Type 0 to  Close Application
Type 1 to Start a Timer
Type 2 to Stop a Timer
Type 3 to Create a Coding Session Record
Type 4 to View All Records
Type 5 to Delete a Record
Type 6 to Update a Record
");
            Console.WriteLine("-----------------------------------");
        }
        public static string IsValidUserResponse()
        {
            var resp = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(resp))
            {
                Console.WriteLine("Please Enter a valid response");
                return "";
            }
            else
            {
                return resp;
            }
        }
    }
}
