namespace ScheduledWorker.Library.Core.Intervals
{
    using System;
    using Contracts.Intervals;
    using Contracts.Schedule;

    /// <summary>
    /// This class is to be used as a starting template for creating an implementation of
    /// <see cref="IInterval{T}"/> and provides basic functionality and initializion for
    /// child classes to implement.
    /// </summary>
    /// <typeparam name="T">The type of interval value for the freqency.</typeparam>
    /// <seealso cref="ScheduledWorker.Library.Contracts.Intervals.IInterval{T}" />
    public abstract class BaseInterval<T> : IInterval<T>
    {
        /// <summary>
        /// Holds the frequency at which a <see cref="IScheduleItem"/> can be run.
        /// </summary>
        protected T _frequency;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseInterval{T}"/> class.
        /// </summary>
        public BaseInterval() : this(default(T))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseInterval{T}"/> class.
        /// </summary>
        /// <param name="frequency">The frequency.</param>
        public BaseInterval(T frequency)
        {
            _frequency = frequency;
        }

        /// <summary>
        /// Gets the frequency measurement at which to run, e.g., Seconds, Months, etc.
        /// </summary>
        public virtual T Frequency => _frequency;

        /// <summary>
        /// Adds the frequency value to the supplied instance of <see cref="T:System.DateTime" />.
        /// </summary>
        /// <param name="moment">The <see cref="T:System.DateTime" /> to add <see cref="P:ScheduledWorker.Library.Contracts.Intervals.IInterval`1.Frequency" /> to.</param>
        /// <returns>
        /// The <see cref="P:ScheduledWorker.Library.Contracts.Intervals.IInterval`1.Frequency" /> value added to <paramref name="moment" />.
        /// </returns>
        public abstract DateTime Add(DateTime moment);
    }
}
