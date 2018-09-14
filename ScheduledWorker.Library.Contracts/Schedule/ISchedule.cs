namespace ScheduledWorker.Library.Contracts.Schedule
{
    using System.Collections.Generic;

    /// <summary>
    /// This outlines the methods and properties for a schedule.
    /// </summary>
    public interface ISchedule
    {
        /// <summary>
        /// Gets the items scheduled to run.
        /// </summary>
        ICollection<IScheduleItem> Items { get; }
    }
}
