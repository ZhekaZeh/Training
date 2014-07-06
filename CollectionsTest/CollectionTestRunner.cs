using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using CollectionsTest.Interfaces;
using CollectionsTest.TestProcessors;

namespace CollectionsTest
{
    //comment CT(1)
    class CollectionTestRunner<T> where T : new()
    {
        #region Private members

        private readonly Stopwatch _stopwatch;
        private readonly TestResults _testResults;
        private ITestProcessor _testRunner;

        #endregion        
        
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionTestRunner{T}"/> class.
        /// </summary>
        public CollectionTestRunner()
        {
            _stopwatch = new Stopwatch();
            _testResults = new TestResults();

            InitializeTestRunner();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Runs the tests.
        /// </summary>
        /// <returns></returns>
        public TestResults RunTests()
        {
            FillCollection(TestConstants.CollectionSize);
            AddItems(TestConstants.AddCount);

            return _testResults;
        }

        #endregion

        #region Private methods

        private void FillCollection(int itemCount)
        {
            StartTimer();
            
            _testRunner.FillCollection(itemCount);

            _testResults.PopulationTimeMs = StopTimerAndGetTime();
        }

        private void AddItems(int addItemCount)
        {
            StartTimer();

            _testRunner.AddItemsToCollection(addItemCount);

            _testResults.AddTimeMs = StopTimerAndGetTime();
        }
        
        private void StartTimer()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
        }

        private int StopTimerAndGetTime()
        {
            _stopwatch.Stop();
            return (int) _stopwatch.ElapsedMilliseconds;
        }

        private void InitializeTestRunner()
        {
            var collection = new T();
            //a little reflection here. It is needed because many types are both ICollection and IDictionary, so that the compiler cannot choose
            //the type and therefore the code is not compiled
            if (collection is IDictionary)
            {
                _testRunner = new DictionaryProcessor(collection as IDictionary);
                return;
            }

            if (collection is ICollection<int>)
            {
                _testRunner = new CollectionProcessor(collection as ICollection<int>);
                return;
            }

            throw new ArgumentException("Argument is neither of IDictionary nor of IList");
        } 

        #endregion

    }
}
