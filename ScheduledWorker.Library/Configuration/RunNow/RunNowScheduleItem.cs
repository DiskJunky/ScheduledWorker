// <copyright company="Eric O'Sullivan">
// Copyright (c) 2016 All Right Reserved
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// </copyright>

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
