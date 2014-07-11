using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using CollectionsTest.Interfaces;
using CollectionsTest.TestProcessors;

namespace CollectionsTest
{
    class CollectionTestRunner<T> where T : IEnumerable, new()
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
            AddItems(TestConstants.IterationCount);
            RemoveItems(TestConstants.IterationCount);

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

        private void RemoveItems(int removeItemCount)
        {
            StartTimer();
            _testRunner.RemoveItemsFromCollection(removeItemCount);
            _testResults.DelTimeMs = StopTimerAndGetTime();
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



            if (collection is Stack<int>)
            {
                _testRunner = new StackProcessor(collection as Stack<int>);
                return;
            }

            if (collection is IDictionary)
            {
                _testRunner = new DictionaryProcessor(collection as IDictionary);
                return;
            }

            if (collection is IList<int>)
            {
                _testRunner = new CollectionProcessor(collection as IList<int>); 
                return;
            }

            if (collection is HashSet<int>)
            {
                _testRunner = new HashSetProcessor(collection as HashSet<int>);
                return;
            }
            if (collection is Queue<int>)
            {
                _testRunner = new QueueProcessor(collection as Queue<int>);
                return;
            }

            throw new ArgumentException("Argument doesn't match to any from existing");
        } 

        #endregion

    }
}
