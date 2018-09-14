namespace ScheduledWorker.Library.Contracts.Schedule
{
    /// <summary>
    /// This outlines the properties and methods for a monthly schedule item.
    /// </summary>
    public interface IMonthlyScheduleItem : IDailyScheduleItem
    {
        /// <summary>
        /// Gets the month the task is to be triggered at.
        /// </summary>
        Months Month { get; }

        /// <summary>
        /// Gets the day of the month to be triggered at.
        /// </summary>
        int Day { get; }
    }
}
