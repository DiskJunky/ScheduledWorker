namespace ScheduledWorker.Library.Logging
{
    using System;
    using Contracts.Logging;

    /// <summary>
    /// This will log output to the debugger Output window.
    /// </summary>
    public class DebugLogger : BaseLogger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugLogger"/> class.
        /// </summary>
        /// <param name="minimumLogLevel">The minimum log level.</param>
        /// <param name="alsoWriteTo">The also write to.</param>
        public DebugLogger(LoggingLevels minimumLogLevel = LoggingLevels.Trace,
                           Action<LoggingLevels, string> alsoWriteTo = null)
            : base(minimumLogLevel, null)
        {
            // having an "alsoWriteTo" allows us to chain loggers
            _doLogging = (level, message) =>
            {
                LogToDebug(level, message);
                alsoWriteTo?.Invoke(level, message);
            };
        }

        /// <summary>
        /// Logs to the debug output window.
        /// </summary>
        /// <param name="logLevel">The logging level the message is for.</param>
        /// <param name="message">The message to write to the output window.</param>
        protected void LogToDebug(LoggingLevels logLevel,
                                  string message = null)
        {
            // make note of the logging level and write the details
            var debugMessage = $"{logLevel}: {message}";
            System.Diagnostics.Debug.WriteLine(debugMessage);
        }
    }
}
