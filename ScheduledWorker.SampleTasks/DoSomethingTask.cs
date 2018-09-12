// <copyright company="Eric O'Sullivan">
// Copyright (c) 2016 All Right Reserved
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// </copyright>

namespace ScheduledWorker.SampleTasks
{
    using Library.Worker;

    /// <summary>
    /// This class demonstrates what's required for a task.
    /// </summary>
    public class DoSomethingTask : BaseWorkerTask
    {
        /// <summary>
        /// This will perform the actual task
        /// </summary>
        /// <returns>True if the task succeeded, false otherwise.</returns>
        public override bool DoWork()
        {
            // write out something to the log
            _logger.Info("This task did something!");
            return true;
        }
    }
}
