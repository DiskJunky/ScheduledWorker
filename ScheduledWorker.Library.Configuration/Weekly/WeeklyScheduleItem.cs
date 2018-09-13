namespace ScheduledWorker.Library.Configuration
{
    using System;
    using System.Configuration;
    using Contracts;
    using Contracts.Schedule;

    /// <summary>
    /// Holds the details for a single weekly schedule.
    /// </summary>
    public class WeeklyScheduleItem : DailyScheduleItem, IWeeklyScheduleItem
    {
        #region Internal Constants
        /// <summary>
        /// Holds the key to use when referencing the 'day' configuration property.
        /// </summary>
        internal const string DayKey = "day";
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the day of the week the task should kick off at.
        /// </summary>
        [ConfigurationProperty(DayKey, DefaultValue = DayOfWeek.Monday, IsRequired = true)]
        public DayOfWeek Day => (DayOfWeek)base[DayKey];
        #endregion

        #region Public Methods
        /// <summary>
        /// This will check to see if the schedule item should kick off at the time specified.
        /// </summary>
        /// <param name="checkTime">The date/time to check if the task should kick off at.</param>
        /// <param name="tickerIntervalSeconds">The ticker interval. This is the window in which
        /// the task can kick off only once.</param>
        /// <returns>
        /// True if the task should kick off, false otherwise.
        /// </returns>
        public override bool ShouldRun(DateTime checkTime, int tickerIntervalSeconds)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
