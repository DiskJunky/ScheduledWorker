﻿namespace ScheduledWorker.Library.Core.Intervals
{
    using System;

    /// <summary>
    /// This implements a schedule based on the number of minuets between runs.
    /// </summary>
    /// <seealso cref="int" />
    public class MinuteInterval : BaseInterval<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteInterval"/> class.
        /// </summary>
        public MinuteInterval() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteInterval"/> class.
        /// </summary>
        /// <param name="minutes">The minutes.</param>
        public MinuteInterval(int minutes)
            : base(minutes)
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
            return moment.AddMinutes(Frequency);
        }
    }
}
