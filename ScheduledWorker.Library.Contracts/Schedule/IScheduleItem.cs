using System;

namespace ScheduledWorker.Library.Contracts.Schedule
{
    using Worker;

    /// <summary>
    /// This contains base details about a scheduled item.
    /// </summary>
    public interface IScheduleItem
    {
        /// <summary>
        /// Gets or sets the type of task that is scheduled. Must implement <see cref="IWorkerTask"/>.
        /// </summary>
        Type Task { get; }

        /// <summary>
        /// Gets or sets the UTC date/time that the task was last run.
        /// </summary>
        DateTime LastRunUtc { get; set; }
    }
}
