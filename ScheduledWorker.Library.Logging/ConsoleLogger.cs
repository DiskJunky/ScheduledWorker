namespace ScheduledWorker.Library.Logging
{
    using System;
    using System.Collections.Generic;
    using Contracts.Logging;

    /// <summary>
    /// This logs output to the console (if it can) and the debug Output window.
    /// </summary>
    /// <seealso cref="ScheduledWorker.Library.Logging.DebugLogger" />
    public class ConsoleLogger : DebugLogger
    {
        /// <summary>
        /// The console colors to use per logging level. TODO; make this configurable.
        /// </summary>
        private readonly Dictionary<LoggingLevels, ConsoleColor> _levelColors = new Dictionary<LoggingLevels, ConsoleColor>
        {
            { LoggingLevels.None, ConsoleColor.Cyan },      // shouldn't happen but cover all bases...
            { LoggingLevels.Trace, ConsoleColor.DarkGray },
            { LoggingLevels.Debug, ConsoleColor.Gray },
            { LoggingLevels.Info, ConsoleColor.White },
            { LoggingLevels.Warn, ConsoleColor.Yellow},
            { LoggingLevels.Error, ConsoleColor.Red },
            { LoggingLevels.Fatal, ConsoleColor.DarkMagenta },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleLogger"/> class.
        /// </summary>
        /// <param name="minimumLogLevel">The minimum log level.</param>
        /// <param name="alsoWriteTo">The also write to.</param>
        public ConsoleLogger(LoggingLevels minimumLogLevel = LoggingLevels.Trace,
                             Action<LoggingLevels, string> alsoWriteTo = null)
            : base(minimumLogLevel, null)
        {
            // having an "alsoWriteTo" allows us to chain loggers
            _doLogging = (level, message) =>
            {
                LogToConsole(level, message);
                alsoWriteTo?.Invoke(level, message);
            };
        }

        /// <summary>
        /// Logs to debug.
        /// </summary>
        /// <param name="loggingLevel">The logging level.</param>
        /// <param name="message">The message.</param>
        private void LogToConsole(LoggingLevels loggingLevel, string message)
        {
            LogToDebug(loggingLevel, message);
            if (!Environment.UserInteractive)
            {
                // running in headless mode, can't write out to the console...
                return;
            }

            // now we can write out to the console
            var color = _levelColors[loggingLevel];
            Console.ForegroundColor = color;
            Console.WriteLine($"{DateTime.Now} - {loggingLevel}: {message}");
            Console.ResetColor();
        }
    }
}
