using System;
using System.Collections.Generic;
using CollectionsTest.Interfaces;

namespace CollectionsTest
{
    public class CollectionProcessor : ITestProcessor
    {
        #region Private members

        private IList<int> _collection;

        #endregion

        #region Constructor

        public CollectionProcessor(IList<int> collection)
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
            for (int i = 0; i < itemCount; i++)
            {
                _collection.Remove(i);
            }
        }

        #endregion
    }
}
