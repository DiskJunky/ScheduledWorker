namespace ScheduledWorker.Library
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Contracts.Logging;
    using Contracts.Schedule;
    using Contracts.Worker;
    using Logging;

    /// <summary>
    /// This class loads the schedule and configured tasks and makes them available
    /// for running.
    /// </summary>
    public class ScheduleManager : IScheduleManager
    {
        #region Private Variables
        /// <summary>
        /// This contains a map of the various Activities (Actions) we carry out on a scheduled basis 
        /// and the date time that they were last completely checked/executed. A complete execution is
        /// considered to have occurred when either a) No cases exist to be timed out or b) All cases
        /// that exist were timed out, with no truncation of cases to satisfy max batch size criteria.
        /// </summary>
        private Dictionary<string, DateTime> _lastCompletedRunDateTime = new Dictionary<string, DateTime>();

        /// <summary>
        /// Holds whether or not the schedule manager should be running.
        /// </summary>
        private bool _canRun = true;

        /// <summary>
        /// The logger instance to use for logging anything.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Holds a reference to the component that will return particular moments in time to check
        /// against the schedule.
        /// </summary>
        private readonly IMomentProvider _momentProvider;
        #endregion

        #region Lifetime Management        
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleManager"/> class.
        /// </summary>
        /// <param name="schedule">The instance of the schedule on which to run tasks.</param>
        /// <param name="momentProvider">The component use to return the current moment in time.</param>
        public ScheduleManager(ISchedule schedule, IMomentProvider momentProvider)
        {
            _logger = new NoLogger();
            Schedule = schedule;
            _momentProvider = momentProvider;
        }

        /// <summary>
        /// This instantiates the object.
        /// </summary>
        /// <param name="logger">The logging instance to use for logging.</param>
        /// <param name="schedule">The instance of the schedule on which to run tasks.</param>
        /// <param name="momentProvider">The component use to return the current moment in time.</param>
        public ScheduleManager(ILogger logger, ISchedule schedule, IMomentProvider momentProvider)
            : this(schedule, momentProvider)
        {
            _logger = logger;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the schedule configuration.
        /// </summary>
        public ISchedule Schedule
        { get; protected set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// This initializes the schedule and loads the details from the application's configuration.
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        /// This will run the specified task and return whether or not it completed successfully. Any exceptions
        /// thrown by the worker task are logged and thrown up to the caller if <see cref="throwExceptions"/> is
        /// set to true, otherwise they are just logged and false is returned. Null tasks always complete with
        /// a success [true].
        /// </summary>
        /// <param name="scheduledItem">The scheduled item with the worker task to execute.</param>
        /// <param name="throwExceptions">Flags if exceptions should be thrown up to the caller if they occur.</param>
        /// <returns>True if the task ran successfully, false otherwise.</returns>
        public bool RunTask(IScheduleItem scheduledItem, bool throwExceptions = false)
        {
            // if we didn't get anything then this counts as a success as we checked it
            if (scheduledItem == null)
            {
                _logger.Warn("Null scheduled item found.");
                return false;
            }
            if (scheduledItem.Task == null)
            {
                _logger.Warn("Null task found. ");
                return false;
            }

            // run the task and check if there was an issue
            bool success = false;
            string taskName = scheduledItem.GetType().FullName;
            try
            {
                _logger.Trace("Executing RunNow task [{0}]...", taskName);

                // this is deliberately broken to highlight attention. The line below
                // is invalid because the LastRun time should be managed by the scheduler.
                scheduledItem.LastRun = _momentProvider.GetCurrent();
                success = ((IWorkerTask) scheduledItem.Task).DoWork();
            }
            catch (Exception ex)
            {
                // log and determine if we need to rethrow.
                _logger.Error(ex, "Task [{0}] threw an exception.", taskName);
                if (throwExceptions)
                {
                    throw;
                }
            }
            finally
            {
                _logger.Trace("[{0}] task completed with a result of [{1}].", taskName, success);
            }

            return success;
        }

        /// <summary>
        /// This will determine each if each task is scheduled to run and kick it off accordingly. This will keep running
        /// on the current thread unless <see cref="Stop"/> is called.
        /// </summary>
        public void Start()
        {
            _logger.Info("Scheduled tasks are starting...");
            _canRun = true;
            while (_canRun)
            {
                _logger.Debug("Starting scheduled task check...");
                DateTime loopStartTick = DateTime.UtcNow;

                // TODO: code seem to be an out of date copy... need to investigate correct classes that
                //       should be referenced to get this working...
                //// do all runNow tasks on each tick
                //CheckScheduledItems(Schedule.RunNow);
                //CheckScheduledItems(Schedule.Daily);
                //CheckScheduledItems(Schedule.Weekly);
                //CheckScheduledItems(Schedule.Monthly);

                //// any action may have taken longer than the interval to run. Calculate how long
                //// in milliseconds we need to sleep the current thread for
                //_logger.Debug("Finished scheduled task check.");
                //TimeSpan executeTime = DateTime.UtcNow.Subtract(loopStartTick);
                //if (executeTime.Seconds < Schedule.Interval)
                //{
                //    int sleepMilliseconds = (Schedule.Interval*1000) - executeTime.Milliseconds;
                //    _logger.Trace("Scheduled task loop took [{0:F3}] seconds. Sleeping until next interval...",
                //                  ((float)executeTime.Milliseconds / 1000));
                //    Thread.Sleep(sleepMilliseconds);
                //}
            }
            
            _logger.Info("Scheduled tasks have finished running.");
        }

        /// <summary>
        /// This will flag the loop to stop running if it is. Does nothing otherwise.
        /// </summary>
        public void Stop()
        {
            _canRun = false;
        }
        #endregion

        #region Private Methods        
        /// <summary>
        /// Checks the scheduled items should be run and runs them if so.
        /// </summary>
        /// <param name="scheduledItems">The scheduled items to check.</param>
        private void CheckScheduledItems(/*IEnumerable<BaseScheduleItem> scheduledItems*/)
        {
            //string typeName = scheduledItems.GetType().Name;
            //_logger.Trace("Checking scheduled items in [{0}]...", typeName);
            //foreach (BaseScheduleItem item in scheduledItems)
            //{
            //    RunIfTriggered(item);
            //}
            //_logger.Trace("Check for [{0}] scheduled items complete.", typeName);
        }

        /// <summary>
        /// Runs the specified scheduled item if it's due to be triggered.
        /// </summary>
        /// <param name="scheduledItem">The scheduled item.</param>
        private void RunIfTriggered(IScheduleItem scheduledItem)
        {
            // TODO: locate correct code for identifying the interval...
            DateTime moment = _momentProvider.GetCurrent();
            //if (scheduledItem.ShouldRun(moment, Schedule.Interval))
            //{
            //    RunTask(scheduledItem);
            //}
        }
        #endregion
    }
}
