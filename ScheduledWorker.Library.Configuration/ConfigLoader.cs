namespace ScheduledWorker.Library.Configuration
{
    using System.Configuration;
    using Contracts.Schedule;

    /// <summary>
    /// This class loads the schedule details from a .NET config file (if correctly set up).
    /// </summary>
    public class ConfigLoader
    {
        /// <summary>
        /// Loads the schedule from the application's default configuration file.
        /// </summary>
        /// <returns>The schedule details loaded.</returns>
        public ScheduleSection LoadDefault()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return (ScheduleSection)config.Sections[ScheduleSection.ScheduleSectionKey];
        }
    }
}
