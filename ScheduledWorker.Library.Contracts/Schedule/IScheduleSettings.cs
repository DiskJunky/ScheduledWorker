namespace ScheduledWorker.Library.Contracts.Schedule
{
    using Intervals;

    /// <summary>
    /// This outlines the settings required for an implementation of <see cref="ISchedule"/>.
    /// </summary>
    /// <typeparam name="TCheckFrequency">The type of the check frequency.</typeparam>
    public interface IScheduleSettings<TCheckFrequency>
    {
        /// <summary>
        /// Gets the interval to wait between checking if a <see cref="IScheduleItem"/> has run.
        /// </summary>
        IInterval<TCheckFrequency> CheckFrequency { get; }
    }
}
