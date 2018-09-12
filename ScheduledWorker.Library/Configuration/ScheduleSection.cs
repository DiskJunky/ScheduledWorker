namespace ScheduledWorker.Library.Configuration
{
    using System.Collections.Generic;
    using System.Configuration;
    using Contracts;
    using Contracts.Schedule;

    /// <summary>
    /// This class determines the configuration section for a schedule.
    /// </summary>
    public class ScheduleSection : ConfigurationSection//, IScheduleConfigurationSection
    {
        #region Configuration Section Keys
        /// <summary>
        /// Holds the key to use for serializing/extracting the schedule section.
        /// </summary>
        internal const string ScheduleSectionKey = "schedule";

        /// <summary>
        /// Holds the key to use for serializing/extracting the daily section.
        /// </summary>
        internal const string DailyScheduleSectionKey = "daily";

        /// <summary>
        /// Holds the key to use for serializing/extracting the weekly section.
        /// </summary>
        internal const string WeelkyScheduleSectionKey = "weekly";

        /// <summary>
        /// Holds the key to use for serializing/extracting the monthly section.
        /// </summary>
        internal const string MonthlyScheduleSectionKey = "monthly";

        /// <summary>
        /// Holds the key to use for serializing/extracting the runNow section.
        /// </summary>
        internal const string RunNowScheduleSectionKey = "runNow";

        /// <summary>
        /// Holds the key to use for serializing/extracting the interval setting.
        /// </summary>
        internal const string IntervalKey = "interval";
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the interval in seconds to wait between checking if any schedule should activate.
        /// </summary>
        [ConfigurationProperty(IntervalKey, IsRequired = false, DefaultValue = 1 /*second*/)]
        public int Interval => (int) base[IntervalKey];

        /// <summary>
        /// Gets the daily schedule.
        /// </summary>
        [ConfigurationProperty(DailyScheduleSectionKey)]
        public DailyScheduleCollection Daily => (DailyScheduleCollection)base[DailyScheduleSectionKey];

        /// <summary>
        /// Gets the weekly schedule.
        /// </summary>
        [ConfigurationProperty(WeelkyScheduleSectionKey)]
        public WeeklyScheduleCollection Weekly => (WeeklyScheduleCollection)base[WeelkyScheduleSectionKey];

        /// <summary>
        /// Gets the monthly schedule.
        /// </summary>
        [ConfigurationProperty(MonthlyScheduleSectionKey)]
        public MonthlyScheduleCollection Monthly => (MonthlyScheduleCollection)base[MonthlyScheduleSectionKey];

        /// <summary>
        /// Gets the collection of items to run immediately.
        /// </summary>
        [ConfigurationProperty(RunNowScheduleSectionKey)]
        public RunNowScheduleCollection RunNow => (RunNowScheduleCollection)base[RunNowScheduleSectionKey];

        //IList<IScheduleItem> IScheduleConfigurationSection.Daily => throw new System.NotImplementedException();
        #endregion
    }
}
