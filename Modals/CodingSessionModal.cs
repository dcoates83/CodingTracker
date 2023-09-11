namespace CodingTracker.Modals
{
    internal class CodingSessionModal
    {
        private int Id { get; set; }
        public bool Active { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? Duration { get; set; }

    }
}
