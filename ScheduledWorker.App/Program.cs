namespace ScheduledWorker.App
{
    using System;
    using System.Collections.Generic;
    using Library.Contracts.Logging;
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
            ILogger logger = new NoLogger();
            try
            {

                logger.Info("Starting main at {0}", DateTime.Now);
                logger.Debug("Exe located at '{0}'", AppDomain.CurrentDomain.BaseDirectory);

                // load the custom configuration
                //ScheduleManager scheduleManager = new ScheduleManager();
                //scheduleManager.Initialize();
                //scheduleManager.Start();

                Console.WriteLine("\r\nPress any key to exit");
                Console.ReadKey();

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
                // log and exit the program
                string message =
                    string.Format("There was an unexpected problem while running the Scheduled Worker process.\r\nError: {0}",
                                  ex.Message);
                logger.Fatal(ex, message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        #endregion
    }
}
