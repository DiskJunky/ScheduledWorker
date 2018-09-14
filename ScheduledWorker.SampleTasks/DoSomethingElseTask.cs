namespace ScheduledWorker.SampleTasks
{
    using Library.Contracts.Logging;
    using Library.Worker;

    /// <summary>
    /// This class writes out a basic message to the console.
    /// </summary>
    public class DoSomethingElseTask : BaseWorkerTask
    {
        public DoSomethingElseTask()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoSomethingElseTask"/> class.
        /// </summary>
        /// <param name="logger">The logger to use for logging.</param>
        public DoSomethingElseTask(ILogger logger) : base(logger)
        {
        }

        /// <summary>
        /// Perform the task and write out a message to the window.
        /// </summary>
        /// <returns>The successful result of the task.</returns>
        public override bool DoWork()
        {
            _logger.Info("I'm doing something else!");
            return true;
        }
    }
}
