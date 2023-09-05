namespace CodingTracker
{
    internal class CodingSessionModal
    {
        private int Id { get; set; }
        private DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        TimeSpan Duration { get; set; }


    }
}
