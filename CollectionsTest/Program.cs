using System;
using System.Collections.Generic;

namespace CollectionsTest
{
    //changed from site(1)
    //changed from VS2013
    //changed(2)
    //test3 from VS
    class Program
    {
        static void Main()
        {
            var testRestults = new Dictionary<string, TestResults>();
            
            var listTester = new CollectionTestRunner<List<int>>();
            var dictionaryTester = new CollectionTestRunner<Dictionary<int,int>>();
            var hashSetTester = new CollectionTestRunner<HashSet<int>>();
            var sortedListTester = new CollectionTestRunner<SortedList<int,int>>();
            
            testRestults.Add("List" , listTester.RunTests());
            testRestults.Add("Dictionary", dictionaryTester.RunTests());
            testRestults.Add("HashSet", hashSetTester.RunTests());
            testRestults.Add("SortedList", sortedListTester.RunTests());

            OutputTestResults(testRestults);

            Console.ReadLine();
        }

        private static void OutputTestResults(Dictionary<string, TestResults> results)
        {
            foreach (var testResult in results)
            {
                Console.WriteLine("==={0}===", testResult.Key);

                Console.WriteLine("Fill time of {0} items is {1} ms", TestConstants.CollectionSize, testResult.Value.PopulationTimeMs);
                Console.WriteLine("Add {0} items time is {1} ms", TestConstants.AddCount, testResult.Value.AddTimeMs);
            }
        }
    }
}
