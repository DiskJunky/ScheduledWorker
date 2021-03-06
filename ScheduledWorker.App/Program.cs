namespace ScheduledWorker.App
{
    using System;
    using System.Collections.Generic;
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
        #region Private Static Variables
        /// <summary>
        /// This contains a map of the various Activities (Actions) we carry out on a scheduled basis 
        /// and the date time that they were last completely checked/executed. A complete execution is
        /// considered to have occurred when either a) No cases exist to be timed out or b) All cases
        /// that exist were timed out, with no truncation of cases to satisfy max batch size criteria.
        /// </summary>
        private static Dictionary<string, DateTime> _lastCompletedRunDateTime = new Dictionary<string, DateTime>();
        #endregion

        #region Program Entry Point
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


                // load the custom configuration
                //var configLoader = new ConfigLoader();
                //var scheduleConfig = configLoader.LoadDefault();
                //var schedule = scheduleConfig.ToSchedule();
                ISchedule schedule = (ISchedule) null;
                var momentProvider = new UtcMomentProvider();
                ScheduleManager scheduleManager = new ScheduleManager(logger, schedule, momentProvider);
                scheduleManager.Start();

                if (Environment.UserInteractive)
                {
                    Console.WriteLine("\r\nPress any key to exit");
                    Console.ReadKey();
                }

                // try and load the settings and schedule configuration
                //Settings settings = Settings.Default;
                // Set up user account
                //ConfigureBDFScheduledWorkerUserAccount(settings);

                //// start performing each action
                //bool firstTimeThrough = true;
                //while (true)
                //{
                //    _logger.Info("Checking for actions that are scheduled at {0}...", DateTime.Now);
                //    scheduleManager.Start();

                //    // record that we made it through our first pass of all operations
                //    if (firstTimeThrough)
                //    {
                //        firstTimeThrough = false;
                //        Settings.Default.ErrorOccurred = false;
                //        Settings.Default.Save();
                //    }

                //    Thread.Sleep(1000);
                //}
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "There was an unexpected problem while running the Scheduled Worker process");
                if (Environment.UserInteractive)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        #endregion
    }
}
