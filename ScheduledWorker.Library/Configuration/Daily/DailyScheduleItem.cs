namespace ScheduledWorker.Library.Configuration
{
    using System;
    using System.Configuration;
    using System.Xml.Serialization;
    using Contracts;
    using Contracts.Schedule;

    /// <summary>
    /// Holds the details for a single item in a daily schedule.
    /// </summary>
    public class DailyScheduleItem : BaseScheduleItem, IDailyScheduleItem
    {
        #region Internal Constants
        /// <summary>
        /// Holds the key to use when referencing the 'time' configuration property.
        /// </summary>
        internal const string TimePropertyKey = "time";
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the time that the schedule should kick off at. Only the time component is used.
        /// </summary>
        [XmlIgnore]
        public DateTime Time => DateTime.Parse(SerializedTime);

        /// <summary>
        /// Gets or sets the serialized form of the time.
        /// </summary>
        [XmlElement(ElementName = TimePropertyKey)]
        [ConfigurationProperty(TimePropertyKey, IsRequired = true)]
        public string SerializedTime => base[TimePropertyKey] as string;

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
            int timeSeconds = (int)Time.TimeOfDay.TotalSeconds;
            int triggerStartSeconds = (int)checkTime.TimeOfDay.TotalSeconds;
            int triggerEndSeconds = triggerStartSeconds + tickerIntervalSeconds;
            
            bool timeTriggered = timeSeconds >= triggerStartSeconds
                                    && timeSeconds <= triggerEndSeconds;
            return timeTriggered && LastRun.AddSeconds(tickerIntervalSeconds) < checkTime;
        }
        #endregion
    }
}
