namespace ScheduledWorker.Library.Configuration
{
    using System.Configuration;

    /// <summary>
    /// Holds details about a monthly schedule.
    /// </summary>
    [ConfigurationCollection(typeof(MonthlyScheduleItem),
                             AddItemName = "task",
                             CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class MonthlyScheduleCollection : BaseScheduleCollection<MonthlyScheduleItem>
    {
        /// <summary>
        /// Gets the key to use for the element to ensure uniqueness.
        /// </summary>
        /// <param name="element">The element to get the key for.</param>
        /// <returns>The key to use.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            MonthlyScheduleItem item = element as MonthlyScheduleItem;
            return string.Format("{0}.{1}.{2}.{3}",
                                 item.Month, item.Day, item.Time, item.Task
                                );
        }
    }
}
