namespace ScheduledWorker.Library.Configuration
{
    using System.Configuration;
    using Contracts;

    /// <summary>
    /// Holds details about a daily schedule.
    /// </summary>
    [ConfigurationCollection(typeof(DailyScheduleItem), 
                             AddItemName = "task", 
                             CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class DailyScheduleCollection : BaseScheduleCollection<DailyScheduleItem>
    {
        /// <summary>
        /// Gets the key to use for the element to ensure uniqueness.
        /// </summary>
        /// <param name="element">The element to get the key for.</param>
        /// <returns>The key to use.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DailyScheduleItem)element).SerializedTime;
        }
    }
}
