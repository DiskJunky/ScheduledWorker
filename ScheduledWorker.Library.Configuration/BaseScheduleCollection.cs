namespace ScheduledWorker.Library.Configuration
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;

    /// <summary>
    /// This manages a collection of schedule items.
    /// </summary>
    /// <typeparam name="TSchedule">The type of schedule items to manage.</typeparam>
    public abstract class BaseScheduleCollection<TSchedule> : ConfigurationElementCollection, IList<TSchedule>
        where TSchedule : BaseScheduleItem
    {
        #region ConfigurationElementCollection Overrides
        /// <summary>
        /// This returns a new instance of the <see cref="WeeklyScheduleItem"/>.
        /// </summary>
        /// <returns>A new instance of <see cref="WeeklyScheduleItem"/>.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return Activator.CreateInstance<TSchedule>();
        }
        #endregion

        #region IList<T> Implementation
        /// <summary>
        /// Returns a strongly typed enumerator.
        /// </summary>
        /// <typeparam name="T">The type to cast the elements as.</typeparam>
        /// <param name="iterator">The iterator to use to over the collection.</param>
        /// <returns>The strongly typed version of the collection.</returns>
        public IEnumerator<T> Cast<T>(IEnumerator iterator)
        {
            while (iterator.MoveNext())
            {
                yield return (T)iterator.Current;
            }
        }

        /// <summary>
        /// Gets the enumerator for the collection.
        /// </summary>
        /// <typeparam name="T">The type to cast to.</typeparam>
        /// <returns>The enumerator for the collection.</returns>
        public IEnumerator<T> GetEnumerator<T>()
        {
            return this.Cast<T>(base.GetEnumerator());
        }

        /// <summary>
        /// Gets the numerator for the collection.
        /// </summary>
        /// <returns>The strongly typed enumerator for the collection.</returns>
        public new IEnumerator<TSchedule> GetEnumerator()
        {
            return GetEnumerator<TSchedule>();
        }

        /// <summary>
        /// Gets the enumerator for the collection.
        /// </summary>
        /// <returns>The enumerator for the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds the specified item to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(TSchedule item)
        {
            BaseAdd(item);
        }

        /// <summary>
        /// Clears the collection of all elements.
        /// </summary>
        public void Clear()
        {
            BaseClear();
        }

        /// <summary>
        /// Returns whether or not the specified item exists in the collection.
        /// </summary>
        /// <param name="item">The item to look for.</param>
        /// <returns>True if found, false otherwise.</returns>
        public bool Contains(TSchedule item)
        {
            // look for the item in the collection
            foreach (TSchedule checkItem in this)
            {
                if (checkItem.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// This will copy the collection to the specified array.
        /// </summary>
        /// <param name="array">The array to copy to.</param>
        /// <param name="arrayIndex">The array index to start copying at.</param>
        public void CopyTo(TSchedule[] array, int arrayIndex)
        {
            base.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the item from the collection if it exists.
        /// </summary>
        /// <param name="item">The item to return.</param>
        /// <returns>True if the item was removed, false otherwise.</returns>
        public bool Remove(TSchedule item)
        {
            BaseRemove(item);
            return true;
        }

        /// <summary>
        /// Gets whether or not the list is read only.
        /// </summary>
        public new bool IsReadOnly => false;

        /// <summary>
        /// Gets the index of the specified item in the collection.
        /// </summary>
        /// <param name="item">The item to look for.</param>
        /// <returns>The index of the item, if found.</returns>
        public int IndexOf(TSchedule item)
        {
            return BaseIndexOf(item);
        }

        /// <summary>
        /// This will insert the item at the specified index.
        /// </summary>
        /// <param name="index">Ignored. Insertion not supported except at end of collection.</param>
        /// <param name="item">The item to insert at the specified index.</param>
        public void Insert(int index, TSchedule item)
        {
            BaseAdd(item);
        }

        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <param name="index">The index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        /// <summary>
        /// Gets or sets the specified item. Any item set is automatically added
        /// to the end of the array. It does NOT maintain its position!
        /// </summary>
        /// <param name="index">The index of the item to get/set.</param>
        /// <returns>The item at the specified index.</returns>
        public TSchedule this[int index]
        {
            get => (TSchedule)BaseGet(index);
            set
            {
                // replace if it already exists
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                BaseAdd(index, value);
            }
        }
        #endregion
    }
}