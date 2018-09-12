namespace ScheduledWorker.Library.Contracts.Logging
{
    /// <summary>
    /// This enumerates the different levels of logging supported by the library.
    /// </summary>
    public enum LoggingLevels
    {
        /// <summary>
        /// The logging level is unknown or unspecified.
        /// </summary>
        None = 0,

        /// <summary>
        /// A Trace level log. Used for low-level diagnostic information, not usually in the main logs.
        /// </summary>
        Trace = 1,

        /// <summary>
        /// A Debug level log. Used for specific use-cases or debugging some logic.
        /// </summary>
        Debug = 2,

        /// <summary>
        /// An Information level log. Used for logging the start, state or result of an operation.
        /// </summary>
        Info = 3,

        /// <summary>
        /// A Warn level log. Used for notifying exceptional but non-breaking events.
        /// </summary>
        Warn = 4,

        /// <summary>
        /// An Error level log. Used for logging error details, usually where such errors do not break the
        /// overall process being carried out, e.g., one item failed in a batch.
        /// </summary>
        Error = 5,

        /// <summary>
        /// A Fatal level log. Used for logging events where the application crashed or had to stop completely.
        /// </summary>
        Fatal = 6,
    }
}
