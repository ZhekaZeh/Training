using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionsTest.Interfaces;

namespace CollectionsTest.TestProcessors
{
    class QueueProcessor : ITestProcessor
    {
        #region Private members

        private Queue<int> _collection;

        #endregion

        #region Constructor

        public QueueProcessor(Queue<int> collection)
        {
            _collection = collection;
        }

        #endregion

        #region ITestProcessor implementation

        /// <summary>
        /// Adds the items to Queue.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="addItemCount">The add item count.</param>
        public void AddItemsToCollection(int itemCount)
        {
            for (int i = 0; i < itemCount; i++)
            {
                _collection.Enqueue(i);
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
                _collection.Dequeue();
            }
        }


        #endregion
    }
}
