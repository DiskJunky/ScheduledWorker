namespace ScheduledWorker.Library.Configuration
{
    using System;

    /// <summary>
    /// Holds details about a task that should be run immediately.
    /// </summary>
    public class RunNowScheduleItem : BaseScheduleItem
    {
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
            // always run
            return true;
        }
        #endregion
    }
}
