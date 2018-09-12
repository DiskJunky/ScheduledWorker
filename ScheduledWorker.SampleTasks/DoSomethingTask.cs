namespace ScheduledWorker.SampleTasks
{
    using Library.Contracts.Logging;
    using Library.Worker;

    /// <summary>
    /// This class demonstrates what's required for a task.
    /// </summary>
    public class DoSomethingTask : BaseWorkerTask
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoSomethingTask"/> class.
        /// </summary>
        /// <param name="logger">The logger to use for logging.</param>
        public DoSomethingTask(ILogger logger) : base(logger)
        {
        }

        /// <summary>
        /// This will perform the actual task
        /// </summary>
        /// <returns>True if the task succeeded, false otherwise.</returns>
        public override bool DoWork()
        {
            // write out something to the log
            _logger.Info("This task did something!");
            return true;
        }
    }
}
