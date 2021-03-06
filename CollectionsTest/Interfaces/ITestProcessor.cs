﻿namespace CollectionsTest.Interfaces
{
    public interface ITestProcessor
    {
        /// <summary>
        /// Fills the collection.
        /// </summary>
        /// <param name="itemCount">The item count.</param>
        void FillCollection(int itemCount);

        /// <summary>
        /// Adds the items to collection.
        /// </summary>
        /// <param name="itemCount">The item count.</param>
        void AddItemsToCollection(int itemCount);

        void RemoveItemsFromCollection(int itemCount);

        void ReadValueFromItems(int itemCount);

        void RecordValueToItems(int itemCount);

    }
}
