namespace ScheduledWorker.Library.Logging
{
    using System;
    using Contracts.Logging;

    /// <summary>
    /// This class merely provides a empty implementation of <see cref="ILogger"/>. The purpose is
    /// for use in testing scenarios, etc., where no logging should actually be performed.
    /// </summary>
    /// <remarks>NOTE: this doesn't inherit from <see cref="BaseLogger"/> as that class does
    /// actually contain some logic that would execute and could potentially break a test.</remarks>
    /// <seealso cref="ScheduledWorker.Library.Contracts.Logging.ILogger" />
    public class NoLogger : ILogger
    {
        /// <summary>
        /// Logs a Trace level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Trace(string message, params object[] args)
        {
        }

        /// <summary>
        /// Logs a Trace level message, formatted with the supplied arguments and <see cref="T:System.Exception" /> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Trace(Exception ex, string message, params object[] args)
        {
        }

        /// <summary>
        /// Logs a Debug level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Debug(string message, params object[] args)
        {
        }

        /// <summary>
        /// Logs a Debug level message, formatted with the supplied arguments and <see cref="T:System.Exception" /> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Debug(Exception ex, string message, params object[] args)
        {
        }

        /// <summary>
        /// Logs an Info level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Info(string message, params object[] args)
        {
        }

        /// <summary>
        /// Logs an Info level message, formatted with the supplied arguments and <see cref="T:System.Exception" /> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Info(Exception ex, string message, params object[] args)
        {
        }

        /// <summary>
        /// Logs a Warning level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Warn(string message, params object[] args)
        {
        }

        /// <summary>
        /// Logs a Warning level message, formatted with the supplied arguments and <see cref="T:System.Exception" /> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Warn(Exception ex, string message, params object[] args)
        {
        }

        /// <summary>
        /// Logs an Error level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Error(string message, params object[] args)
        {
        }

        /// <summary>
        /// Logs an Error level message, formatted with the supplied arguments and <see cref="T:System.Exception" /> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Error(Exception ex, string message, params object[] args)
        {
        }

        /// <summary>
        /// Logs a Fatal level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Fatal(string message, params object[] args)
        {
        }

        /// <summary>
        /// Logs a Fatal level message, formatted with the supplied arguments and <see cref="T:System.Exception" /> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        public void Fatal(Exception ex, string message, params object[] args)
        {
        }
    }
}
