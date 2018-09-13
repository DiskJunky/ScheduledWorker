namespace ScheduledWorker.Library.Contracts.Schedule
{
    using System;

    /// <summary>
    /// This outlines the fields and methods for a daily scheduled item.
    /// </summary>
    public interface IDailyScheduleItem : IScheduleItem
    {
        /// <summary>
        /// Gets the time that the schedule should kick off at. Only the time component is used.
        /// </summary>
        DateTime Time { get; }
    }
}
