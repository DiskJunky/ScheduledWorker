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
    /// This contains base details about a scheduled item.
    /// </summary>
    public interface IScheduleItem
    {
        /// <summary>
        /// Gets or sets the type of task that is scheduled. Must implement <see cref="IWorkerTask"/>.
        /// </summary>
        Type Task { get; }

        /// <summary>
        /// Gets or sets the UTC date/time that the task was last run.
        /// </summary>
        DateTime LastRunUtc { get; set; }
    }
}
