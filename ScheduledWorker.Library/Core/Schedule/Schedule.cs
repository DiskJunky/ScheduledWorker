namespace ScheduledWorker.Library.Core.Schedule
{
    using System.Collections.Generic;
    using Contracts.Schedule;

    /// <summary>
    /// This class holds a schedule at it's most basic.
    /// </summary>
    public class Schedule : ISchedule
    {
        #region Private Memebers
        /// <summary>
        /// Holds a reference to the items that are scheduled.
        /// </summary>
        private readonly ICollection<IScheduleItem> _items;
        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="Schedule"/> class.
        /// </summary>
        public Schedule()
        {
            _items = new List<IScheduleItem>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Schedule"/> class.
        /// </summary>
        /// <param name="collections">A set of collections to be added into a single set.</param>
        public Schedule(params ICollection<IScheduleItem>[] collections)
        {
            _items = new List<IScheduleItem>();
            foreach (ICollection<IScheduleItem> collection in collections)
            {
                AddRange(collection);
            }
        }
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets the items scheduled to run.
        /// </summary>
        ICollection<IScheduleItem> ISchedule.Items => _items;
        #endregion

        #region Private Methods        
        /// <summary>
        /// Adds the collection to the existing set.
        /// </summary>
        /// <param name="toBeAdded">The items to be added.</param>
        private void AddRange(ICollection<IScheduleItem> toBeAdded)
        {
            foreach (IScheduleItem item in toBeAdded)
            {
                _items.Add(item);
            }
        }
        #endregion
    }
}
