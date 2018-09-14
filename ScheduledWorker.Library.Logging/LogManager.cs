namespace ScheduledWorker.Library.Logging
{
    using Contracts.Logging;

    /// <summary>
    /// This class is used to provide common functionality across the library.
    /// </summary>
    public static class LogManager
    {
        /// <summary>
        /// Gets a new instance of the the default logger.
        /// </summary>
        public static ILogger Default => new ConsoleLogger();

        /// <summary>
        /// Gets a new instance of <see cref="NoLogger"/>.
        /// </summary>
        public static ILogger None => new NoLogger();
    }
}
