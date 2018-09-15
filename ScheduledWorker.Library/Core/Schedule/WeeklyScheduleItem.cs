namespace ScheduledWorker.Library.Core.Schedule
{
    using System;
    using Contracts.Schedule;

    /// <summary>
    /// This schedule item describes a task that should kick off on a particular day of the week.
    /// </summary>
    /// <seealso cref="ScheduledWorker.Library.Core.Schedule.DailyScheduleItem" />
    /// <seealso cref="ScheduledWorker.Library.Contracts.Schedule.IWeeklyScheduleItem" />
    public class WeeklyScheduleItem : DailyScheduleItem, IWeeklyScheduleItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeeklyScheduleItem"/> class.
        /// </summary>
        /// <param name="time">The time of day that the task should kick off at.</param>
        /// <param name="day">The day of the week that the task should kick off at.</param>
        public WeeklyScheduleItem(DateTime time, DayOfWeek day)
            : base(time)
        {
            Day = day;
        }

        /// <summary>
        /// Gets the day that the scheduled item triggers on.
        /// </summary>
        public DayOfWeek Day { get; }
    }
}
