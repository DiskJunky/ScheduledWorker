namespace ScheduledWorker.Library.Contracts.Schedule
{
    /// <summary>
    /// This outlines the properties and methods for a monthly schedule item.
    /// </summary>
    public interface IMonthlyScheduleItem : IWeeklyScheduleItem
    {
        /// <summary>
        /// Gets the month the task is to be triggered at.
        /// </summary>
        Months Month { get; }
    }
}
