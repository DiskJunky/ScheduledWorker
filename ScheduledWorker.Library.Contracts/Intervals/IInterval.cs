namespace ScheduledWorker.Library.Contracts.Intervals
{
    using System;
    using Schedule;

    /// <summary>
    /// This describes the interval frequency that a <see cref="IScheduleItem"/> can be run at.
    /// </summary>
    public interface IInterval<T>
    {
        /// <summary>
        /// Gets the frequency measurement at which to run, e.g., Seconds, Months, etc.
        /// </summary>
        T Frequency { get; }

        /// <summary>
        /// Adds the frequency value to the supplied instance of <see cref="DateTime"/>.
        /// </summary>
        /// <param name="moment">The <see cref="DateTime"/> to add <see cref="Frequency"/> to.</param>
        /// <returns>The <see cref="Frequency"/> value added to <paramref name="moment"/>.</returns>
        DateTime Add(DateTime moment);
    }
}
