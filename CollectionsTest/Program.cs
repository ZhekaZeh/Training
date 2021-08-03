using System;
using System.Collections.Generic;

namespace CollectionsTest
{
    class Program
    {
        static void Main()
        {
            var testResults = new Dictionary<string, TestResults>();
            
            var listTester = new CollectionTestRunner<List<int>>();
            var dictionaryTester = new CollectionTestRunner<Dictionary<int, int>>();
            var hashSetTester = new CollectionTestRunner<HashSet<int>>();
            var sortedListTester = new CollectionTestRunner<SortedList<int, int>>();
            var stackTester = new CollectionTestRunner<Stack<int>>();
            var queueTester = new CollectionTestRunner<Queue<int>>();

            testResults.Add("List", listTester.RunTests());
            testResults.Add("Dictionary", dictionaryTester.RunTests());
            testResults.Add("HashSet", hashSetTester.RunTests());
            testResults.Add("SortedList", sortedListTester.RunTests());
            testResults.Add("Stack", stackTester.RunTests());
            testResults.Add("Queue", queueTester.RunTests());

            OutputTestResults(testResults);

            Console.ReadLine();
            //first change
        }

        private static void OutputTestResults(Dictionary<string, TestResults> results)
        {
            foreach (var testResult in results)
            {
                Console.WriteLine("==={0}===", testResult.Key);

                Console.WriteLine("Fill time of {0} items is {1} ms", TestConstants.CollectionSize, testResult.Value.PopulationTimeMs);
                Console.WriteLine("Add {0} items time is {1} ms", TestConstants.IterationCount, testResult.Value.AddTimeMs);
                Console.WriteLine("Remove {0} items time is {1} ms", TestConstants.IterationCount, testResult.Value.DelTimeMs);
                Console.WriteLine("Read {0} items time is {1} ms", TestConstants.IterationCount, testResult.Value.ReadTimeMs);
                Console.WriteLine("Record values to {0} items time is {1} ms", TestConstants.IterationCount, testResult.Value.WriteTimeMs);
            }
        }
    }
}
