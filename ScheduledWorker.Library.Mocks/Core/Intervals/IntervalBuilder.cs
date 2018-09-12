namespace ScheduledWorker.Library.Mocks.Core.Intervals
{
    using System;
    using Contracts.Intervals;
    using Library.Core.Intervals;

    /// <summary>
    /// This is used to create instances of particular <see cref="IInterval{T}"/>
    /// implementations.
    /// </summary>
    /// <typeparam name="TInterval">The type of the interval.</typeparam>
    /// <typeparam name="TFrequency">The type of the frequency.</typeparam>
    public class IntervalBuilder<TInterval, TFrequency>
        where TInterval : IInterval<TFrequency>
    {
        /// <summary>
        /// Gets a new instance of <typeparamref name="TInterval"/> at the specified frequency.
        /// </summary>
        /// <param name="frequency">The frequency should run at.</param>
        /// <returns>A new instance of <typeparamref name="TInterval"/> at the specified <paramref name="frequency"/>.</returns>
        public IInterval<TFrequency> Get(TFrequency frequency)
        {
            return (IInterval<TFrequency>)Activator.CreateInstance(typeof(TInterval), frequency);
        }
    }
}
