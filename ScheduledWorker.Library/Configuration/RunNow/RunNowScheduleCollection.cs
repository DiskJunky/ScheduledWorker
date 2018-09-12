namespace ScheduledWorker.Library.Configuration
{
    using System.Configuration;

    /// <summary>
    /// Holds details about a schedule of items to run immediately.
    /// </summary>
    [ConfigurationCollection(typeof(RunNowScheduleItem),
                             CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class RunNowScheduleCollection : BaseScheduleCollection<RunNowScheduleItem>
    {
        /// <summary>
        /// Gets the key to use for the element to ensure uniqueness.
        /// </summary>
        /// <param name="element">The element to get the key for.</param>
        /// <returns>The key to use.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RunNowScheduleItem)element).Task;
        }
    }
}
