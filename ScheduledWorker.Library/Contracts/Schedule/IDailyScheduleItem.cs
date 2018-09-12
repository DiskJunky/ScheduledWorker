// <copyright company="DiskJunky">
// Copyright (c) 2016 All Right Reserved
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// </copyright>

using System;

namespace ScheduledWorker.Library.Contracts.Schedule
{
    /// <summary>
    /// This outlines the fields and methods for a daily scheduled item.
    /// </summary>
    public interface IDailyScheduleItem : IScheduleItem
    {
        /// <summary>
        /// Gets the time that the schedule should kick off at. Only the time component is used.
        /// </summary>
        DateTime Time { get; }
    }
}
