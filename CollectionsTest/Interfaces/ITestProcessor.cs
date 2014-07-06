namespace CollectionsTest.Interfaces
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
    }
}
