using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Linq;
using System.Xml;
using System;
using System.Drawing;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EasyMethods();
            //MediumMethods();
            //HardMethods();
            CrazyMethods();
        }

        public static void EasyMethods()
        {
            //Max
            List<int> ints = new List<int>() {-5, 2, 3, 80, 31, -18, 99, 25 };
            Console.WriteLine($"Max: {ints.Max()}");

            //OrderBy
            List<string> words = new List<string>() {"dog", "bag", "apple", "cat", "elephant"};
            var orderedWords = words.OrderBy(x => x).ToList();
            PrintList(orderedWords);

            //Count
            List<int> ints2 = new List<int>() { 10, 20, 30, 40, 50, 60, 70, 80 };
            Console.WriteLine($"Count: {ints2.Count(x=> x>50)}");

            //First
            List<string> words2 = new List<string>() { "mouse", "keyboard", "flower", "cat", "sky" };
            Console.WriteLine($"First word: {words2.First(x=> x.Length == 3)}");

            //Any
            List<int> ints3 = new List<int>() { 5, 8, 17, 24, 37, 48, 64, 82 };
            Console.WriteLine($"Result: {ints3.Any(x=> Math.Sqrt(x)%1 == 0)}");
        }

        public static void MediumMethods()
        {
            //Where and Sum
            List<int> ints = new List<int>() { -1, 12, 3, 0, 75, -18, 15, 38 };
            Console.WriteLine($"Sum: {ints.Where(x => x > 10).Sum(x => x)}");

            //Select and Average
            List<string> words = new List<string>() { "mouse", "keyboard", "flower", "cat", "sky" };
            Console.WriteLine($"Average: {words.Select(x=> x.Length).Average()}");

            //OrderByDescending and First
            List<string> words2 = new List<string>() { "dog", "bag", "apple", "cat", "elephant" };
            Console.WriteLine($"Longest: {words2.OrderByDescending(x => x.Length).First()}");

            //Where and Count
            List<string> words3 = new List<string>() { "mouse", "keyboard", "flower", "cat", "sky" };
            Console.WriteLine($"Count: {words3.Where(x=> x.Length > 5).Count()}");

            //Skip and Take
            List<int> ints2 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var secondHalf = ints2.Skip(ints2.Count/2).Take(ints2.Count / 2).ToList();
            PrintList(secondHalf);
        }

        public static void HardMethods()
        {
            //Where, Select, and Average
            List<int> ints = new List<int>() { 3, 4, 5, 6, 7, 8, 9, 12, 15 };
            double average = ints.Select(x=> x).Where(x=> x%3 ==0).Average();
            Console.WriteLine($"Average: {average}");

            //OrderBy, Reverse, and First
            List<int> ints2 = new List<int>() { 5, 2, 7, 1, 3, 10, 9, 4, 8, 6 };
            int secondSmallest = ints2.OrderBy(x=> x).Reverse().Reverse().Skip(1).First();
            Console.WriteLine($"Second smallest: {secondSmallest}");

            //Where, GroupBy, and Count
            List<int> ints3 = new List<int>() { 22, 54, 17, 22, 74, 8, 74, 3, 86 };
            int count = ints3.Where(x=> x > 20).GroupBy(x=>x).Count();
            Console.WriteLine($"Count: {count}");

            //Select, Concat, and ToArray
            List<string> firstNames = new List<string>() { "firstName1", "firstName2",  "firstName3", "firstName4" };
            List<string> lastNames = new List<string>() { "lastName1", "lastName2", "lastName3", "lastName4" };
            var fullNames = firstNames.Select((name, index) => $"{name}_{lastNames[index]}").ToArray();
            PrintList(fullNames);

            //Where, OrderByDescending, and First
            List<int> ints4 = new List<int>() { 127, 54, 49, 115, 74, 91, 102, 66, 38 };
            int largestNum = ints4.Where(x=> x<100).OrderByDescending(x => x).First();
            Console.WriteLine($"Largest: {largestNum}");
        }

        public static void CrazyMethods()
        {
            //Task1
            List<int> ints = new List<int>() { 5, 9, 17, 24, 36, 48, 64, 82, 100, 122, 144 };
            int number = ints.Where(x=> x>50 && Math.Sqrt(x)%1==0).Min();
            Console.WriteLine($"Min: {number}");

            //Task2
            List<string> words = new List<string>() { "a", "b", "c", "d", "b", "a", "c", "a", "b", "d", "b" };
            IGrouping<string, string> frequent = words.GroupBy(x => x).OrderBy(x=> x.Count()).Last();
            Console.WriteLine($"Frequent: {frequent.Key}");

            //Task3
            string sentence = "asd huhqw ajlf hkdmfls hjb Ayyoukj bnmb";
            List<string> words1 = sentence.Split(" ").ToList();
            int count = words1.Where(x=> x.StartsWith('a') || x.StartsWith('A')).Select(x=> x.Length).Sum();
            Console.WriteLine($"Count: {count}");

            //Task4
            List<int> ints2 = new List<int>() { 7, 9, 3, 6, 8, 5, 4, 1, 2};
            var array = ints2.SkipWhile(x => x >= 5).Skip(1).TakeWhile(x => x >= 5).ToArray();
            PrintList(array);

            //Task5
            List<string> words2 = new List<string>() { "aaa", "bb", "c", "ddd", "aa", "cccc", "aa", "bbb", "dd", "bbbb" };
            IGrouping<int, string> element = words2.GroupBy(x => x.Length).OrderBy(x => x.Count()).Last();
            Console.WriteLine($"Length: {element.Key}");
        }


        public static void PrintList<T>(IEnumerable<T> list)
        {
            Console.Write(nameof(list)+" = {");
            foreach( var item in list )
            {
                Console.Write(item+", ");
            }
            Console.Write("\b\b}");
            Console.WriteLine();
        }
    }
    // Use only LINQ!!! in som ecases you will have to create some classes on your own!
    // easy
    //Use the Max method to find the highest number in a list of integers.
    //Use the OrderBy method to sort a list of words alphabetically.
    //Use the Count method to find out how many numbers in a list are greater than 50.
    //Use the First method to get the first word in a list of strings that has a length of 3 letters.
    //Use the Any method to check if any number in a list is a perfect square (the square of an integer).
    //Tasks with two LINQ methods:

    // medium
    //Use the Where and Sum methods to add up all the numbers in a list that are greater than 10.
    //Use the Select and Average methods to find the average length of words in a list of strings.
    //Use the OrderByDescending and First methods to find the longest word in a list of strings.
    //Use the Where and Count methods to find out how many words in a list have more than 5 letters.
    //Use the Skip and Take methods to get the second half of a list (assume the list length is an even number).
    //Tasks with three LINQ methods:

    // hard
    //Use the Where, Select, and Average methods to find the average value of numbers in a list that are divisible by 3.
    //Use the OrderBy, Reverse, and First methods to find the second smallest number in a list of integers.
    //Use the Where, GroupBy, and Count methods to find out how many unique numbers in a list are greater than 20.
    //Use the Select, Concat, and ToArray methods to merge a list of first names and a list of last names into a single array, with each element being "firstname_lastname".
    //Use the Where, OrderByDescending, and First methods to find the largest number in a list that is less than 100.
    //Tasks with four LINQ methods:

    // crazy asian :D (without hints!) ]:)
    //Use LINQ to find the smallest number that is greater than 50 and its square root is a whole number.
    //Use LINQ to find the most frequent word in a list of strings.
    //Use LINQ to count the total number of letters in the words of a sentence that start with 'A'.
    //Use LINQ to sort the numbers in an array after the first number less than 5 and until the next number less than 5, and return the result as an array.
    //Use LINQ to find the most common length of words in an array of strings.
}