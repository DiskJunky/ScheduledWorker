namespace ScheduledWorker.Library.Logging
{
    using System;
    using Contracts.Logging;

    /// <summary>
    /// This class provides the constructs necessary to make it a lot easier to create a
    /// logging implementation but does not actually log anywhere itself.
    /// </summary>
    /// <seealso cref="ScheduledWorker.Library.Contracts.Logging.ILogger" />
    public abstract class BaseLogger : ILogger
    {
        #region Protected Members
        /// <summary>
        /// Holds as reference to delegate to call with our output so that it
        /// can be sent to an external function as well as to the Debug Output
        /// window.
        /// </summary>
        protected Action<LoggingLevels, string> _doLogging;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseLogger"/> class.
        /// </summary>
        /// <param name="doLogging">Holds as reference of a delegate to call to perform the
        /// actual logging.</param>
        /// <param name="minimumLogLevel">The minimum log level at which to actually write the log.</param>
        public BaseLogger(LoggingLevels minimumLogLevel = LoggingLevels.Trace,
                          Action<LoggingLevels, string> doLogging = null)
        {
            MinimumLoggingLevel = minimumLogLevel;
            _doLogging = doLogging;
        }
        #endregion

        #region Protected Properties
        /// <summary>
        /// Gets the logging level.
        /// </summary>
        protected LoggingLevels MinimumLoggingLevel { get; }
        #endregion

        #region ILogger Implementation        
        /// <summary>
        /// Logs a Trace level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Trace(string message, params object[] args)
        {
            LogMessage(nameof(Trace), null, message, args);
        }

        /// <summary>
        /// Logs a Trace level message, formatted with the supplied arguments and <see cref="T:System.Exception" /> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Trace(Exception ex, string message, params object[] args)
        {
            LogMessage(nameof(Trace), ex, message, args);
        }

        /// <summary>
        /// Logs a Debug level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Debug(string message, params object[] args)
        {
            LogMessage(nameof(Debug), null, message, args);
        }

        /// <summary>
        /// Logs a Debug level message, formatted with the supplied arguments and <see cref="T:System.Exception" /> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Debug(Exception ex, string message, params object[] args)
        {
            LogMessage(nameof(Debug), ex, message, args);
        }

        /// <summary>
        /// Logs an Info level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Info(string message, params object[] args)
        {
            LogMessage(nameof(Info), null, message, args);
        }

        /// <summary>
        /// Logs an Info level message, formatted with the supplied arguments and <see cref="T:System.Exception" /> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Info(Exception ex, string message, params object[] args)
        {
            LogMessage(nameof(Info), ex, message, args);
        }

        /// <summary>
        /// Logs a Warning level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Warn(string message, params object[] args)
        {
            LogMessage(nameof(Warn), null, message, args);
        }

        /// <summary>
        /// Logs a Warning level message, formatted with the supplied arguments and <see cref="T:System.Exception" /> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Warn(Exception ex, string message, params object[] args)
        {
            LogMessage(nameof(Warn), ex, message, args);
        }

        /// <summary>
        /// Logs an Error level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Error(string message, params object[] args)
        {
            LogMessage(nameof(Error), null, message, args);
        }

        /// <summary>
        /// Logs an Error level message, formatted with the supplied arguments and <see cref="T:System.Exception" /> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Error(Exception ex, string message, params object[] args)
        {
            LogMessage(nameof(Error), ex, message, args);
        }

        /// <summary>
        /// Logs a Fatal level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Fatal(string message, params object[] args)
        {
            LogMessage(nameof(Fatal), null, message, args);
        }

        /// <summary>
        /// Logs a Fatal level message, formatted with the supplied arguments and <see cref="T:System.Exception" /> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Fatal(Exception ex, string message, params object[] args)
        {
            LogMessage(nameof(Fatal), ex, message, args);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Logs the message to the configured log action <see cref="DoLogging"/>.
        /// </summary>
        /// <param name="callingMethodName">The name of the calling method.</param>
        /// <param name="e">The expception details, if any..</param>
        /// <param name="message">The message to write to the output window.</param>
        /// <param name="args">The arguments to format the message with.</param>
        private void LogMessage(string callingMethodName,
                                Exception e = null,
                                string message = null,
                                params object[] args)
        {
            if (string.IsNullOrWhiteSpace(callingMethodName))
            {
                throw new ArgumentNullException(nameof(callingMethodName), "No calling method name was supplied to the logger. Cannot determine the correct logging level.");
            }

            // covert the calling method name to a logging level - they must be identical
            // or this won't work.
            LoggingLevels callerLoggingLevel = LoggingLevels.Trace;
            bool parsed = Enum.TryParse(callingMethodName, ignoreCase: true, result: out callerLoggingLevel);
            if (!parsed)
            {
                // always log if we're not sure
                callerLoggingLevel = MinimumLoggingLevel;
            }
            if (callerLoggingLevel < MinimumLoggingLevel)
            {
                // we don't need to log anything
                return;
            }

            // apply message formatting
            if (args != null && args.Length > 0)
            {
                message = string.Format(message, args);
            }

            if (e != null)
            {
                message += $"{Environment.NewLine}{e}";
            }

            // make note of the logging level and write the details
            _doLogging?.Invoke(callerLoggingLevel, message);
        }
        #endregion
    }
}
