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
    using Worker;

    /// <summary>
    /// This outlines the methods for a <see cref="IWorkerTask"/> scheduled to run all the time.
    /// </summary>
    public interface IRunNowScheduleItem : IScheduleItem
    {
    }
}
