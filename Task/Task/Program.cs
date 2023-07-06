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
using System.Net.NetworkInformation;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
                                           //EASY

            //1 Use the Max method to find the highest number in a list of integers
            List<int> numbers = new List<int> { 10, 25, 15, 30, 20 };

            int highestnumber = numbers.Max();

            //2 Use the OrderBy method to sort a list of words alphabetically
            List<string> words1 = new List<string> {  "cat", "dog", "apple", "banana" };

            List<string> sortedWords = words1.OrderBy(word => word).ToList();

            //3 Use the Count method to find out how many numbers in a list are greater than 50
            List<int> nums = new List<int> { 10, 25, 60, 40, 70 };

            int count = nums.Count(number => number > 50);

            //4 Use the First method to get the first word in a list of strings that has a length of 3 letters
            List<string> words2 = new List<string> { "cat", "dog", "apple", "banana" };

            string firstThreeLetterWord = words2.First(word => word.Length == 3);

            //5 Use the Any method to check if any number in a list is a perfect square (the square of an integer)
            List<int> numbers3 = new List<int> { 16, 25, 30, 40, 50 };

            bool hasPerfectSquare = numbers3.Any(number => Math.Sqrt(number) % 1 == 0);


                                                //MEDIUM

            //1 Use the Where and Sum methods to add up all the numbers in a list that are greater than 10
            List<int> numbers4 = new List<int> { 5, 15, 20, 8, 12 };

            int sum = numbers4.Where(number => number > 10).Sum();

            //2 Use the Select and Average methods to find the average length of words in a list of strings
            List<string> words = new List<string> { "cat", "dog", "apple", "banana" };

            double averageLength = words.Select(word => word.Length).Average();

            //3 Use the OrderByDescending and First methods to find the longest word in a list of strings
            List<string> words3 = new List<string> { "cat", "dog", "apple", "banana" };

            string longestWord = words3.OrderByDescending(word => word.Length).First();

            //4 Use the Where and Count methods to find out how many words in a list have more than 5 letters
            List<string> words4 = new List<string> { "cat", "dog", "apple", "banana" };

            int count1 = words4.Where(word => word.Length > 5).Count();

            //5 Use the Skip and Take methods to get the second half of a list (assume the list length is an even number)
            List<int> numbers5 = new List<int> { 1, 2, 3, 4, 5, 6 };

            List<int> secondHalf = numbers5.Skip(numbers.Count / 2).Take(numbers.Count / 2).ToList();


            //HARD

           //1 Use the Where, Select, and Average methods to find the average value of numbers in a list that are divisible by 3

           List<int> numbers6 = new List<int> { 9, 12, 5, 18, 21 };

           double average = numbers6.Where(number => number % 3 == 0).Select(number => (double)number).Average();

           //2 Use the OrderBy, Reverse, and First methods to find the second smallest number in a list of integers:

           List<int> numbers7 = new List<int> { 10, 5, 8, 3, 7 };

           int secondSmallest = numbers7.OrderBy(number => number).Reverse().Skip(1).First();

           //3 Use the Where, GroupBy, and Count methods to find out how many unique numbers in a list are greater than 20:

           List<int> numbers8 = new List<int> { 10, 25, 30, 15, 40, 25 };

           int uniqueCount = numbers8.Where(number => number > 20).GroupBy(number => number).Count();

           //4 Use the Select, Concat, and ToArray methods to merge a list of first names and a list of last names into a single array, with each element being "firstname_lastname"

           List<string> firstNames = new List<string> { "John", "Jane", "Michael" };

           List<string> lastNames = new List<string> { "Doe", "Smith", "Johnson" };

           string[] fullNames = firstNames.SelectMany(firstName => lastNames, (firstName, lastName) => $"{firstName}_{lastName}").ToArray();

           //5 Use the Where, OrderByDescending, and First methods to find the largest number in a list that is less than 100

            List<int> numbers9 = new List<int> { 75, 110, 90, 60, 85 };

            int largestNumber = numbers9.Where(number => number < 100).OrderByDescending(number => number).First();

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