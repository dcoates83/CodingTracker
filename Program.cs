using CodingTracker.Controllers;

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
                var resp = UserInput.IsValidUserResponse();

                if (resp != null && resp == "0")
                {
                    _running = false;
                }
                UserInput.ParseUserInput(resp);

            }

        }

    }

}