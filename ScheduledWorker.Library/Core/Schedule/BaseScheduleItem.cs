namespace ScheduledWorker.Library.Core.Schedule
{
    using System;
    using Contracts.Schedule;

    /// <summary>
    /// This class provides the basic constructs for a <see cref="IScheduleItem"/> implementation.
    /// </summary>
    /// <seealso cref="ScheduledWorker.Library.Contracts.Schedule.IScheduleItem" />
    public abstract class BaseScheduleItem : IScheduleItem
    {
        /// <summary>
        /// Gets or sets the type of task that is scheduled. Must implement <see cref="T:ScheduledWorker.Library.Contracts.Worker.IWorkerTask" />.
        /// </summary>
        public Type Task { get; }

        /// <summary>
        /// Gets or sets the date/time that the task was last run.
        /// </summary>
        public DateTime LastRun { get; set; }
    }
}
