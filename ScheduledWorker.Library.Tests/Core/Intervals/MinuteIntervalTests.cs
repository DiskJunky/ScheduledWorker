namespace ScheduledWorker.Library.Tests.Core.Intervals
{
    using Library.Core.Intervals;
    using Xunit;

    public class MinuteIntervalTests : BaseIntervalTests<MinuteInterval, int>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(100)]
        [InlineData(-99999999)]
        [InlineData(int.MaxValue)]
        public void AddsInterval(int interval)
        {
            AssertHasElapsed(t => (int)t.TotalMinutes, interval);
        }
    }
}
