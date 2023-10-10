﻿namespace CodingTracker.Modals
{
    public class CodingSessionModel
    {
        public int? Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? Duration { get; set; }

    }
}
