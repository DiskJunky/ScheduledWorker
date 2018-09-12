namespace ScheduledWorker.Library.Contracts.Logging
{
    using System;

    /// <summary>
    /// This is used to provide an abstracted interface for logging scheduler information.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a Trace level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        void Trace(string message, params object[] args);

        /// <summary>
        /// Logs a Trace level message, formatted with the supplied arguments and <see cref="Exception"/> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        void Trace(Exception ex, string message, params object[] args);

        /// <summary>
        /// Logs a Debug level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        void Debug(string message, params object[] args);

        /// <summary>
        /// Logs a Debug level message, formatted with the supplied arguments and <see cref="Exception"/> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        void Debug(Exception ex, string message, params object[] args);

        /// <summary>
        /// Logs an Info level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        void Info(string message, params object[] args);

        /// <summary>
        /// Logs an Info level message, formatted with the supplied arguments and <see cref="Exception"/> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        void Info(Exception ex, string message, params object[] args);

        /// <summary>
        /// Logs a Warning level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        void Warn(string message, params object[] args);

        /// <summary>
        /// Logs a Warning level message, formatted with the supplied arguments and <see cref="Exception"/> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        void Warn(Exception ex, string message, params object[] args);

        /// <summary>
        /// Logs an Error level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        void Error(string message, params object[] args);

        /// <summary>
        /// Logs an Error level message, formatted with the supplied arguments and <see cref="Exception"/> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        void Error(Exception ex, string message, params object[] args);

        /// <summary>
        /// Logs a Fatal level message, formatted with the supplied arguments.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        void Fatal(string message, params object[] args);

        /// <summary>
        /// Logs a Fatal level message, formatted with the supplied arguments and <see cref="Exception"/> details.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message with.</param>
        void Fatal(Exception ex, string message, params object[] args);
    }
}
