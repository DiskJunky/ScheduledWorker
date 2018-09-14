namespace ScheduledWorker.Library.Contracts.Worker
{
    /// <summary>
    /// This outlines the tasks that a worker task must have in order to be processed
    /// </summary>
    public interface IWorkerTask
    {
        /// <summary>
        /// This performs the actual work for the task.
        /// </summary>
        /// <returns>True if the task succeeded, false otherwise.</returns>
        bool DoWork();
    }
}
