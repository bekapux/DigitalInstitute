using System.Diagnostics;

namespace Task
{
    internal class Program
    {
        public static List<int> RandomIntsList()
        {
            List<int> list = new List<int>();
            Random random = new Random();

            for (int i = 0; i < 50_000; i++)
                list.Add(random.Next(0, 1000));

            return list;
        }

        public static void MaxValue1()
        {
            Stopwatch sw = Stopwatch.StartNew();

            List<int> ints = RandomIntsList();
            ints.Sort();

            int MaxValue = ints[^1];
            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds);

        }

        public static void MaxValue2()
        {
            Stopwatch sw = Stopwatch.StartNew();

            List<int> ints = RandomIntsList();
            int MaxValue = int.MinValue;

            foreach (int i in ints)
                if (i > MaxValue)
                    MaxValue = i;

            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        public static void MaxValue3()
        {
            Stopwatch sw = Stopwatch.StartNew();
            List<int> ints = RandomIntsList();

            int MaxValue = ints[0];

            for (int i = 0; i < ints.Count; i++)
                if (ints[i] > MaxValue)
                    MaxValue = ints[i];

            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds);

        }

        public static void MaxValue4()
        {
            Stopwatch sw = Stopwatch.StartNew();

            List<int> ints = RandomIntsList();
            int MaxValue = ints[0];

            foreach (int i in ints)
                MaxValue = Math.Max(MaxValue, i);

            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds);

        }

        public static void Task2()
        {
            Stopwatch sw = Stopwatch.StartNew();

            List<int> list = RandomIntsList();

            int mostRepideNumber = 0;
            int count = 0;

            foreach (int number in list)
            {
                int maxCount = list.Count(x => x == number);

                if (maxCount > count)
                {
                    count = maxCount;
                    mostRepideNumber = number;
                }
            }

            Console.WriteLine(mostRepideNumber + " most repideNumber");

            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds + " millseconds");

        }


        public static void Main()
        {
            // Task 1 
            MaxValue1();
            MaxValue2();
            MaxValue3();
            MaxValue4();

            Console.WriteLine();
            Console.WriteLine();

            // Task 2 
            Task2();  // It's too slow


            // algorithms

            // Task 1
            // create random class with seed for example 10 (seeds are important to generate same values) var rand = new Random(10);
            // generate list with 10000 random integer
            // use different algorithm to find Max Value
            //     1) use Sort method and then First to get max value
            //     2) use prebuilt Max Method
            //     3) use your own algorithm -> create function that takes list as parameter and returns maximum value. Do not use any prebuilt functions.
            //     4) use Stopwatch class to get required time for each algorithm


            // Task 2
            // you have list that contains 50_000 integers from 1 to 1000
            // write function that finds number that is repeated most times in list
            // use stopwatch to calculate time took to complete task

        }
    }
}