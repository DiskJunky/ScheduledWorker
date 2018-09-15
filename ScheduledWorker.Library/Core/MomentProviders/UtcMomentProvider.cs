namespace ScheduledWorker.Library.Core.MomentProviders
{
    using System;
    using Contracts.MomentProviders;

    /// <summary>
    /// This always returns the current moment as <see cref="DateTime.UtcNow"/>.
    /// </summary>
    /// <seealso cref="IMomentProvider" />
    public class UtcMomentProvider : BaseMomentProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UtcMomentProvider"/> class.
        /// </summary>
        public UtcMomentProvider() : base(() => DateTime.UtcNow)
        { }
    }
}
