﻿using CollectionsTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTest.TestProcessors
{
    class StackProcessor : ITestProcessor
    {
        #region Private members

        private Stack<int> _collection;

        #endregion

        #region Constructor

        public StackProcessor(Stack<int> collection)
        {
            _collection = collection;
        }

        #endregion

        #region ITestProcessor implementation

        /// <summary>
        /// Adds the items to Stack.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="addItemCount">The add item count.</param>
        public void AddItemsToCollection(int itemCount)
        {
            for (int i = 0; i < itemCount; i++)
            {
                _collection.Push(i);
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
                _collection.Pop();
            }
        }


        #endregion



    }
}
