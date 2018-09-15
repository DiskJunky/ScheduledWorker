namespace ScheduledWorker.Library.Core.Schedule
{
    using Contracts.Schedule;

    /// <summary>
    /// This schedule describes a task that should be run on each cycle.
    /// </summary>
    /// <seealso cref="ScheduledWorker.Library.Contracts.Schedule.IRunNowScheduleItem" />
    public class RunNowScheduleItem : BaseScheduleItem, IRunNowScheduleItem
    {
    }
}
