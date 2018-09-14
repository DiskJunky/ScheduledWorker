namespace ScheduledWorker.Library.Configuration
{
    using System;
    using System.Configuration;
    using System.Xml.Serialization;
    using Contracts;
    using Contracts.Schedule;

    /// <summary>
    /// Holds the details for a single monthly item in a daily schedule.
    /// </summary>
    public class MonthlyScheduleItem : WeeklyScheduleItem, IMonthlyScheduleItem
    {
        #region Configuration Keys
        /// <summary>
        /// Holds the key to use when referencing the 'month' configuration property.
        /// </summary>
        internal const string MonthKey = "month";
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the strongly typed month that the task is configured to run on.
        /// </summary>
        [XmlIgnore]
        public Months Month 
        { 
            get
            {
                // build a date string from the loaded configuration and attempt to parse it.
                DateTime now = DateTime.Now;
                string dateString = string.Format("{0} {1} {2}", Day, SerializedMonth, now.Year);
                return (Months)DateTime.Parse(dateString).Month;
            }
        }

        /// <summary>
        /// Gets the serialized, raw form of the month.
        /// </summary>
        [XmlElement(ElementName = MonthKey)]
        [ConfigurationProperty(MonthKey, IsRequired = true)]
        public string SerializedMonth => base[MonthKey] as string;

        #endregion

        #region Public Methods
        /// <summary>
        /// This will check to see if the schedule item should kick off at the time specified.
        /// </summary>
        /// <param name="checkTime">The date/time to check if the task should kick off at.</param>
        /// <param name="tickerIntervalSeconds">The ticker interval. This is the window in which
        /// the task can kick off only once.</param>
        /// <returns>
        /// True if the task should kick off, false otherwise.
        /// </returns>
        public override bool ShouldRun(DateTime checkTime, int tickerIntervalSeconds)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
