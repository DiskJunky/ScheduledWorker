namespace ScheduledWorker.Library.Worker
{
    using Contracts;
    using Contracts.Logging;
    using Contracts.Schedule;
    using Contracts.Worker;
    using Logging;

    /// <summary>
    /// This class provides common logic for worker tasks.
    /// </summary>
    public abstract class BaseWorkerTask : IWorkerTask
    {
        #region Protected Members        
        /// <summary>
        /// The logger instance to use.
        /// </summary>
        protected readonly ILogger _logger;
        #endregion

        #region Constructor
        /// <summary>
        /// The default constructor used to instantiate the object.
        /// </summary>
        protected BaseWorkerTask()
        {
            _logger = LogManager.None;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseWorkerTask"/> class.
        /// </summary>
        /// <param name="logger">The logger to use for logging.</param>
        protected BaseWorkerTask(ILogger logger)
        {
            _logger = logger;
        }
        #endregion

        #region IWorkerTask Impelementation
        /// <summary>
        /// This will perform the actual task to be done.
        /// </summary>
        /// <returns>True if the task succeed, false otherwise.</returns>
        public abstract bool DoWork();

        /// <summary>
        /// Called when the task has triggered and <see cref="DoWork" /> is about to be called.
        /// </summary>
        /// <param name="sender">The sender starting the task.</param>
        /// <param name="e">The <see cref="WorkerTaskEventArgs" /> instance containing the event data.</param>
        public virtual void OnStarting(object sender, WorkerTaskEventArgs e)
        {
            _logger.Trace("{0}.OnStarted() triggered.", GetType().FullName);
        }

        /// <summary>
        /// Called when <see cref="DoWork" /> has completed.
        /// </summary>
        /// <param name="sender">The sender completing the task.</param>
        /// <param name="e">The <see cref="WorkerTaskEventArgs" /> instance containing the event data.</param>
        public virtual void OnCompleted(object sender, WorkerTaskEventArgs e)
        {
            _logger.Trace("{0}.Completed() triggered", GetType().FullName);
        }
        #endregion
    }
}
