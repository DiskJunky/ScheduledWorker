// <copyright company="DiskJunky">
// Copyright (c) 2016 All Right Reserved
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// </copyright>

namespace ScheduledWorker.Library.Contracts.Schedule
{
    using System.Collections.Generic;

    /// <summary>
    /// This outlines the methods and properties for a schedule.
    /// </summary>
    public interface ISchedule
    {
        /// <summary>
        /// Gets the items scheduled to run.
        /// </summary>
        ICollection<IScheduleItem> Items { get; }
    }
}
