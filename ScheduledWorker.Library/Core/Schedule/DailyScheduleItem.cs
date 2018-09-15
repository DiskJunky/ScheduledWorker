namespace ScheduledWorker.Library.Core.Schedule
{
    using System;
    using Contracts.Schedule;

    /// <summary>
    /// This schedule item describes a task that should be kicked off at a particular time of day.
    /// </summary>
    /// <seealso cref="ScheduledWorker.Library.Core.Schedule.BaseScheduleItem" />
    /// <seealso cref="ScheduledWorker.Library.Contracts.Schedule.IDailyScheduleItem" />
    public class DailyScheduleItem : BaseScheduleItem, IDailyScheduleItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DailyScheduleItem"/> class.
        /// </summary>
        /// <param name="time">The time that the task should kick off at.</param>
        public DailyScheduleItem(DateTime time)
        {
            Time = time;
        }

        /// <summary>
        /// Gets the time that the schedule should kick off at. Only the time component is used.
        /// </summary>
        public DateTime Time { get; }
    }
}
