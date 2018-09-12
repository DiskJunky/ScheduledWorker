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
