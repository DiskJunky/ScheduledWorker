// <copyright company="Eric O'Sullivan">
// Copyright (c) 2016 All Right Reserved
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// </copyright>

namespace ScheduledWorker.Library.Configuration
{
    using System.Configuration;

    /// <summary>
    /// Holds details about a weekly schedule.
    /// </summary>
    [ConfigurationCollection(typeof(WeeklyScheduleItem), 
                             AddItemName = "task",
                             CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class WeeklyScheduleCollection : BaseScheduleCollection<WeeklyScheduleItem>
    {
        /// <summary>
        /// Gets the key to use for the element to ensure uniqueness.
        /// </summary>
        /// <param name="element">The element to get the key for.</param>
        /// <returns>The key to use.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            // the key comprises of all the properties.
            WeeklyScheduleItem item = element as WeeklyScheduleItem;
            return string.Format("{0}.{1}.{2}", item.Day, item.SerializedTime, item.Task);
        }
    }
}
