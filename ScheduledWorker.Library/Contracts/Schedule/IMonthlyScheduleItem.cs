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
    /// <summary>
    /// This outlines the properties and methods for a monthly schedule item.
    /// </summary>
    public interface IMonthlyScheduleItem : IWeeklyScheduleItem
    {
        /// <summary>
        /// Gets the month the task is to be triggered at.
        /// </summary>
        Month Month { get; }
    }
}
