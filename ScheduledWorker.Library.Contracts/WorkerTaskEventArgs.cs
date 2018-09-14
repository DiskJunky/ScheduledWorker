namespace ScheduledWorker.Library.Contracts
{
    using System;
    using Schedule;
    using Worker;

    /// <summary>
    /// This holds details about the worker event.
    /// </summary>
    public class WorkerTaskEventArgs : EventArgs
    {
        #region Lifetime Management        
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerTaskEventArgs"/> class.
        /// </summary>
        public WorkerTaskEventArgs()
            : this(null, DateTime.Now)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerTaskEventArgs"/> class.
        /// </summary>
        /// <param name="workerTask">The worker task that the event occurred on.</param>
        /// <param name="triggeredAt">The date/time the task was triggered at, not 
        /// the event itself.</param>
        public WorkerTaskEventArgs(IWorkerTask workerTask, DateTime triggeredAt)
        {
            TriggeredAt = triggeredAt;
            Task = workerTask;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the triggered at.
        /// </summary>
        public DateTime TriggeredAt { get; protected set; }

        /// <summary>
        /// Gets or sets the task that was triggered.
        /// </summary>
        public IWorkerTask Task { get; protected set; }
        #endregion
    }
}
