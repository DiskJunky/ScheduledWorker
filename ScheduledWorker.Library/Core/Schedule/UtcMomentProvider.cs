namespace ScheduledWorker.Library.Core.Schedule
{
    using System;

    /// <summary>
    /// This always returns the current moment as <see cref="DateTime.UtcNow"/>.
    /// </summary>
    /// <seealso cref="ScheduledWorker.Library.Contracts.Schedule.IMomentProvider" />
    public class UtcMomentProvider : BaseMomentProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UtcMomentProvider"/> class.
        /// </summary>
        public UtcMomentProvider() : base(() => DateTime.UtcNow)
        { }
    }
}
