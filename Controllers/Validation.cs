namespace CodingTracker.Controllers
{
    internal class Validation
    {
        public static DateTime ValidateDateResponse(ref string? _line, string format)
        {
            DateTime _Time;
            while (!DateTime.TryParseExact(_line, format, null, System.Globalization.DateTimeStyles.AllowInnerWhite, out _Time))
            {
                Console.WriteLine("Invalid date, please retry");
                _line = Console.ReadLine();
            }

            return _Time;
        }
    }
}
