namespace ScheduledWorker.Library.Contracts.Schedule
{
    using Worker;

    /// <summary>
    /// This outlines the methods for a <see cref="IWorkerTask"/> scheduled to run all the time.
    /// </summary>
    public interface IRunNowScheduleItem : IScheduleItem
    {
    }
}
