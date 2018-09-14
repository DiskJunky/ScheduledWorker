namespace ScheduledWorker.Library.Core.Schedule
{
    using System;
    using Contracts.Schedule;

    /// <summary>
    /// This base class provides most of the wrapping necessary to create a basic moment provider.
    /// </summary>
    /// <seealso cref="ScheduledWorker.Library.Contracts.Schedule.IMomentProvider" />
    public abstract class BaseMomentProvider : IMomentProvider
    {
        private readonly Func<DateTime> _getMoment;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMomentProvider"/> class.
        /// </summary>
        /// <param name="getMoment">The function to use to get a moment.</param>
        public BaseMomentProvider(Func<DateTime> getMoment)
        {
            _getMoment = getMoment;
        }

        /// <summary>
        /// Gets the current date/time moment.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.DateTime" /> value representing the current moment.
        /// </returns>
        public DateTime GetCurrent()
        {
            return _getMoment();
        }
    }
}
