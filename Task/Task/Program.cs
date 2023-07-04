using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // algorithms

            // Task 1
            // create random class with seed for example 10 (seeds are important to generate same values) var rand = new Random(10);
            // generate list with 10000 random integer
            // use different algorithm to find Max Value
            //     1) use Sort method and then First to get max value
            //     2) use prebuilt Max Method
            //     3) use your own algorithm -> create function that takes list as parameter and returns maximum value. Do not use any prebuilt functions.
            //     4) use Stopwatch class to get required time for each algorithm

            Stopwatch stopwatch = new Stopwatch();
            var ran = new Random(10);

            List<int> RandomInts = Task1.GenerateList(ran,10_000);

            stopwatch.Start();
            int result1 = Task1.SortAndFirst(RandomInts);
            stopwatch.Stop();
            Console.WriteLine($"First algorithm result: {result1}\n time: {stopwatch.ElapsedTicks}");

            stopwatch.Start();
            int result2 = Task1.PrebuildMax(RandomInts);
            stopwatch.Stop();
            Console.WriteLine($"Second algorithm result: {result2}\n time: {stopwatch.ElapsedTicks}");

            stopwatch.Start();
            int result3 = Task1.CustomSort(RandomInts);
            stopwatch.Stop();
            Console.WriteLine($"Third algorithm result: {result3}\n time: {stopwatch.ElapsedTicks}");





            // Task 2
            // you have list that contains 50_000 integers from 1 to 1000
            // write function that finds number that is repeated most times in list
            // use stopwatch to calculate time took to complete task


            List<int> list = new List<int>(50_000);
            for(int i = 1; i <= 1_000; i++)
            {
                list.Add(i);
            }
            list.Add(5);

            stopwatch.Start();
            int b = CustomMostRepeated(list);
            stopwatch.Stop();
            Console.WriteLine($"Most repeated element: {b}\nTime: {stopwatch.ElapsedTicks}");

            stopwatch.Start();
            int a = MostRepeatedWithLinq(list);
            stopwatch.Stop();
            Console.WriteLine($"Most repeated element: {a}\nTime: {stopwatch.ElapsedTicks}");

        }

        public static int CustomMostRepeated(List<int> list)
        {
            Dictionary<int, int> listOfIntegersWithCount = new Dictionary<int, int>();
            foreach(var l in list)
            {
                if (listOfIntegersWithCount.ContainsKey(l))
                {
                    listOfIntegersWithCount[l]++;
                }
                else
                {
                    listOfIntegersWithCount[l] = 1;
                }
            }

            int mostRepeated=0;
            int count = 0;
            foreach(var l in listOfIntegersWithCount)
            {
                if (l.Value > count)
                {
                    count = l.Value;
                    mostRepeated = l.Key;
                }
                   
            }

            return mostRepeated;
        }

        public static int MostRepeatedWithLinq(List<int> list)
        {
            var groupedNumbers = list.GroupBy(l => l);
            int mostRepeated = groupedNumbers.OrderByDescending(l => l.Count()).First().Key;
            return mostRepeated;
        }

    }
}
