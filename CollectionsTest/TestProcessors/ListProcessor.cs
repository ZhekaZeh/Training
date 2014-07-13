using System;
using System.Collections.Generic;
using CollectionsTest.Interfaces;

namespace CollectionsTest
{
    public class ListProcessor : ITestProcessor
    {
        #region Private members

        private IList<int> _collection;

        #endregion

        #region Constructor

        public ListProcessor(IList<int> collection)
        {
            _collection = collection;
        }

        #endregion

        #region ITestProcessor implementation

        /// <summary>
        /// Adds the items to collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="addItemCount">The add item count.</param>
        public void AddItemsToCollection(int itemCount)
        {
            for (int i = 0; i < itemCount; i++)
            {
                _collection.Add(i);
            }
        }

        /// <summary>
        /// Fills the collection.
        /// </summary>
        /// <param name="itemCount">The item count.</param>
        public void FillCollection(int itemCount)
        {
            AddItemsToCollection(itemCount);
        }

        public void RemoveItemsFromCollection(int itemCount)
        {
            for (int i = itemCount; i < 0; i--)
            {
                _collection.RemoveAt(i);
            }
        }

        public void ReadValueFromItems(int itemCount)
        {
            object _temp;
            for (int i = 0; i < itemCount; i++)
            {
                _temp = _collection[i];
            }
        }

        public void RecordValueToItems(int itemCount)
        {
            for (int i = 0; i < itemCount; i++)
            {
                _collection[i] = i++;
            }
        }

        #endregion

    }
}
