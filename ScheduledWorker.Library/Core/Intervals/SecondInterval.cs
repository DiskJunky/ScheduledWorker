namespace ScheduledWorker.Library.Core.Intervals
{
    using System;
    using Contracts.Intervals;

    /// <summary>
    /// This implements a schedule based on the number of seconds between runs.
    /// </summary>
    /// <seealso cref="int" />
    public class SecondInterval : BaseInterval<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecondInterval"/> class.
        /// </summary>
        public SecondInterval() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecondInterval"/> class.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        public SecondInterval(int seconds)
            : base(seconds)
        {
        }

        /// <summary>
        /// Adds the frequency value to the supplied instance of <see cref="T:System.DateTime" />.
        /// </summary>
        /// <param name="moment">The <see cref="T:System.DateTime" /> to add <see cref="P:ScheduledWorker.Library.Contracts.Intervals.IInterval`1.Frequency" /> to.</param>
        /// <returns>
        /// The <see cref="P:ScheduledWorker.Library.Contracts.Intervals.IInterval`1.Frequency" /> value added to <paramref name="moment" />.
        /// </returns>
        public override DateTime Add(DateTime moment)
        {
            return moment.AddSeconds(Frequency);
        }
    }
}
