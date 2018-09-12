namespace ScheduledWorker.Library.Tests.Core.Intervals
{
    using Library.Core.Intervals;
    using Xunit;

    public class SecondIntervalTests : BaseIntervalTests<SecondInterval, int>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(100)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void AddsInterval(int interval)
        {
            AssertHasElapsed(t => (int)t.TotalSeconds, interval);
        }
    }
}
