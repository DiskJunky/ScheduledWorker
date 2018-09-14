namespace ScheduledWorker.App
{
    using System;
    using Library;
    using Library.Contracts.Logging;
    using Library.Contracts.Schedule;
    using Library.Core.Schedule;
    using Library.Logging;

    /// <summary>
    /// This class is the program's entry point into the system and loads and kicks off the configured schedules.
    /// </summary>
    class Program
    {
        /// <summary>
        /// This sets up the program by loading the configured scheduled items and kicking them off 
        /// according to their schedule.
        /// </summary>
        /// <param name="args">Not used. Could be null</param>
        static void Main(string[] args)
        {
            ILogger logger = LogManager.Default;
            try
            {

                logger.Info("Starting main");
                logger.Debug("Exe located at '{0}'", AppDomain.CurrentDomain.BaseDirectory);

                // roadmap;
                // * Create object POCO models to allow programmatic scheule specification (rather than loading from config only)
                // * Create component to determine if a schedule has been triggered
                // * Unit test the hell out of everything
                // * Verify that the scheduler is working end-to-end
                // * Create object instantiation mechanism (currently limited to blank constructors only)
                // * Unit test the above and retest


                // load the custom configuration....
                ISchedule schedule = (ISchedule) null;

                var momentProvider = new UtcMomentProvider();
                ScheduleManager scheduleManager = new ScheduleManager(logger, schedule, momentProvider);
                scheduleManager.Start();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "There was an unexpected problem while running the Scheduled Worker process");
            }
            finally
            {
                AwaitResponse($"{Environment.NewLine}Press any key to exit");
            }
        }

        /// <summary>
        /// Displays a message and waits on any user response before returning.
        /// </summary>
        /// <param name="message">The message to display.</param>
        private static void AwaitResponse(string message)
        {
            if (!Environment.UserInteractive) return;

            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
