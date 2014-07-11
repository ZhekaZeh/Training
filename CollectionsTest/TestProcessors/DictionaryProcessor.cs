using System.Collections;
using CollectionsTest.Interfaces;

namespace CollectionsTest.TestProcessors
{
    public class DictionaryProcessor : ITestProcessor 
    {
        #region Private members

        private IDictionary _dictionary;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryProcessor"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public DictionaryProcessor(IDictionary dictionary)
        {
            _dictionary = dictionary;
        }

        #endregion

        #region ITestProcessor implementation

        /// <summary>
        /// Fills the collection.
        /// </summary>
        /// <param name="itemCount">The item count.</param>
        public void FillCollection(int itemCount)
        {
            for (int i = 0; i < itemCount + 1; i++)
            {
                _dictionary.Add(i, i);
            }
        }

        /// <summary>
        /// Adds the items to collection.
        /// </summary>
        /// <param name="itemCount">The item count.</param>
        public void AddItemsToCollection(int itemCount)
        {
            for (int i = 1; i < itemCount+1; i++)
            {
                _dictionary.Add(-1*i, i);
            }
        }

        public void RemoveItemsFromCollection(int itemCount)
        {
            for (int i = 0; i < itemCount; i++)
            {
                _dictionary.Remove(i);
            }
        }

        #endregion 
    

    }
}
