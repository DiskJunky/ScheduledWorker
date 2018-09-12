
using ScheduledWorker.Library.Schedule;

namespace ScheduledWorker.Library.Worker
{
    using Contracts;
    using NLog;

    /// <summary>
    /// This class provides common logic for worker tasks.
    /// </summary>
    public abstract class BaseWorkerTask : IWorkerTask
    {
        #region NLog instance
        /// <summary>
        /// The single instance of an NLog LogManager for this class.
        /// </summary>
        protected Logger _logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor
        /// <summary>
        /// The default constructor used to instantiate the object.
        /// </summary>
        protected BaseWorkerTask()
        {
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
