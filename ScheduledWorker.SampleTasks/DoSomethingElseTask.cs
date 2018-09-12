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
    /// This class writes out a basic message to the console.
    /// </summary>
    public class DoSomethingElseTask : BaseWorkerTask
    {
        /// <summary>
        /// Perform the task and write out a message to the window.
        /// </summary>
        /// <returns>The successful result of the task.</returns>
        public override bool DoWork()
        {
            _logger.Info("I'm doing something else!");
            return true;
        }
    }
}
