namespace ScheduledWorker.Library.Contracts.Schedule
{
    using System;

    /// <summary>
    /// This contains the properties and methods for a weekly schedule item.
    /// </summary>
    public interface IWeeklyScheduleItem : IDailyScheduleItem
    {
        /// <summary>
        /// Gets the day that the scheduled item triggers on.
        /// </summary>
        DayOfWeek Day { get; }
    }
}
