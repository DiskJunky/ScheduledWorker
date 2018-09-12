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
    /// This outlines the tasks that a worker task must have in order to be processed
    /// </summary>
    public interface IWorkerTask
    {
        /// <summary>
        /// This performs the actual work for the task.
        /// </summary>
        /// <returns>True if the task succeeded, false otherwise.</returns>
        bool DoWork();
    }
}
