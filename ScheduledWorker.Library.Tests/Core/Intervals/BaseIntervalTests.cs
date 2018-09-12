namespace ScheduledWorker.Library.Tests.Core.Intervals
{
    using System;
    using Library.Core.Intervals;
    using Mocks.Core.Intervals;
    using Xunit;

    public abstract class BaseIntervalTests<TInterval, TFrequency>
        where TInterval : BaseInterval<TFrequency>
    {
        private readonly DateTime _moment = new DateTime(2000, 1, 1);
        private readonly IntervalBuilder<TInterval, TFrequency> _intervalBuilder = new IntervalBuilder<TInterval, TFrequency>();

        protected void AssertHasElapsed(Func<TimeSpan, TFrequency> getElapsed, TFrequency frequency)
        {
            var interval = _intervalBuilder.Get(frequency);
            DateTime frequencyAdded = interval.Add(_moment);
            Assert.True(getElapsed(frequencyAdded.Subtract(_moment)).Equals(frequency));
        }
    }
}
