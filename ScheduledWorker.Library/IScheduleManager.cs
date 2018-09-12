namespace ScheduledWorker.Library
{
    using Contracts.Schedule;

    public interface IScheduleManager
    {
        /// <summary>
        /// Gets or sets the schedule configuration.
        /// </summary>
        ISchedule Schedule { get; }

        /// <summary>
        /// This initializes the schedule and loads the details from the application's configuration.
        /// </summary>
        void Initialize();

        /// <summary>
        /// This will run the specified task and return whether or not it completed successfully. Any exceptions
        /// thrown by the worker task are logged and thrown up to the caller if <paramref name="throwExceptions"/> is
        /// set to true, otherwise they are just logged and false is returned. Null tasks always complete with
        /// a success [true].
        /// </summary>
        /// <param name="scheduledItem">The scheduled item with the worker task to execute.</param>
        /// <param name="throwExceptions">Flags if exceptions should be thrown up to the caller if they occur.</param>
        /// <returns>True if the task ran successfully, false otherwise.</returns>
        bool RunTask(IScheduleItem scheduledItem, bool throwExceptions = false);

        /// <summary>
        /// This will determine each if each task is scheduled to run and kick it off accordingly. This will keep running
        /// on the current thread unless <see cref="IScheduleManager.Stop"/> is called.
        /// </summary>
        void Start();

        /// <summary>
        /// This will flag the loop to stop running if it is. Does nothing otherwise.
        /// </summary>
        void Stop();
    }
}