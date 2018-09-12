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
    /// This contains the properties and methods for a weekly schedule item.
    /// </summary>
    public interface IWeeklyScheduleItem : IDailyScheduleItem
    {
        /// <summary>
        /// Gets the day that the scheduled item triggers on.
        /// </summary>
        DayOfWeek Day { get; }
    }
}
