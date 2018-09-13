namespace ScheduledWorker.Library.Configuration
{
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using Contracts;
    using Contracts.Schedule;
    using Contracts.Worker;

    /// <summary>
    /// This holds basic details about a scheduled item.
    /// </summary>
    public abstract class BaseScheduleItem : ConfigurationElement, IScheduleItem
    {
        #region Private Members        
        /// <summary>
        /// The <see cref="Type"/> of the task object to execute. Must implement <see cref="IWorkerTask"/>.
        /// </summary>
        private Type _task;
        #endregion

        #region Internal Constants
        /// <summary>
        /// Holds the key to use when referencing the task property.
        /// </summary>
        internal const string TaskTypePropertyKey = "run";
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the task that is scheduled.
        /// </summary>
        [ConfigurationProperty(TaskTypePropertyKey, IsRequired = true, Options = ConfigurationPropertyOptions.IsTypeStringTransformationRequired)]
        [TypeConverter(typeof(WorkerTaskConverter))]
        public IWorkerTask Task => (IWorkerTask)base[TaskTypePropertyKey];

        public DateTime LastRunUtc { get; set; }

        /// <summary>
        /// Gets or sets the date/time that the task was last run.
        /// </summary>
        public DateTime LastRun { get; set; }
        #endregion

        #region Protected Methods
        /// <summary>
        /// This will check to see if the schedule item should kick off at the time specified.
        /// </summary>
        /// <param name="checkTime">The date/time to check if the task should kick off at.</param>
        /// <param name="tickerIntervalSeconds">The ticker interval. This is the window in which
        /// the task can kick off only once.</param>
        /// <returns>True if the task should kick off, false otherwise.</returns>
        public abstract bool ShouldRun(DateTime checkTime, int tickerIntervalSeconds);
        #endregion

        /// <summary>
        /// The <see cref="Type"/> of the task object to execute. Must implement <see cref="IWorkerTask"/>.
        /// </summary>
        Type IScheduleItem.Task => _task;
    }
}