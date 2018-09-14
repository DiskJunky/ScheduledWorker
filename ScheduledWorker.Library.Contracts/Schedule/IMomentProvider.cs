namespace ScheduledWorker.Library.Contracts.Schedule
{
    using System;

    /// <summary>
    /// This interface is used to provide comment methods for retrieving details
    /// about a moment in time.
    /// </summary>
    public interface IMomentProvider
    {
        /// <summary>
        /// Gets the current date/time moment.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> value representing the current moment.</returns>
        DateTime GetCurrent();
    }
}
