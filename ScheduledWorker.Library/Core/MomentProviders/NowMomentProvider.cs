namespace ScheduledWorker.Library.Core.MomentProviders
{
    using System;

    /// <summary>
    /// This class always returns a moment of <see cref="DateTime.Now"/>.
    /// </summary>
    /// <seealso cref="BaseMomentProvider" />
    public class NowMomentProvider : BaseMomentProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NowMomentProvider"/> class.
        /// </summary>
        public NowMomentProvider() : base(() => DateTime.Now)
        {
        }
    }
}
