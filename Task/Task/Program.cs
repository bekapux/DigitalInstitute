using System;
using System.Collections.Generic;
using System.Data;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Pair<int, string> pair1 = new Pair<int, string>();
            pair1.SetValues(10, "Apple");
            var values1 = pair1.GetValues();
            Console.WriteLine($"First: {values1.Item1}, Second: {values1.Item2}");

            Pair<float, string> pair2 = new Pair<float, string>();
            pair2.SetValues(3.14f, "World");
            var values2 = pair2.GetValues();
            Console.WriteLine($"First: {values2.Item1}, Second: {values2.Item2}");


            int num1 = 5, num2 = 10;
            Console.WriteLine($"Before swap: num1 = {num1}, num2 = {num2}");
            SwapUtility.Swap(ref num1, ref num2);
            Console.WriteLine($"After swap: num1 = {num1}, num2 = {num2}");

            string str1 = "Welcome", str2 = "Home";
            Console.WriteLine($"Before swap: str1 = {str1}, str2 = {str2}");
            SwapUtility.Swap(ref str1, ref str2);
            Console.WriteLine($"After swap: str1 = {str1}, str2 = {str2}");

            SortedCollection<int> sortedInts = new SortedCollection<int>();
            sortedInts.Add(5);
            sortedInts.Add(2);
            sortedInts.Add(8);
            Console.WriteLine("Sorted Integers:");
            sortedInts.PrintItems();

            SortedCollection<string> sortedStrings = new SortedCollection<string>();
            sortedStrings.Add("banana");
            sortedStrings.Add("apple");
            sortedStrings.Add("orange");
            Console.WriteLine("Sorted Strings:");
            sortedStrings.PrintItems();
        }
        class Pair<T, U>
        {
            public T First { get; private set; }
            public U Second { get; private set; }

            public void SetValues(T first, U second)
            {
                First = first;
                Second = second;
            }

            public (T, U) GetValues()
            {
                return (First, Second);
            }
        }
        public class SwapUtility
        {
            public static void Swap<T>(ref T first, ref T second)
            {
                T temp = first;
                first = second;
                second = temp;
            }
        }
        public class SortedCollection<T> where T : IComparable<T>
        {
            private List<T> items;

            public SortedCollection()
            {
                items = new List<T>();
            }
            public void Add(T item)
            {
                items.Add(item);
                items.Sort();
            }
            public T GetItem(int index)
            {
                if (index >= 0 && index < items.Count)
                    return items[index];
                throw new IndexOutOfRangeException();
            }
            public void PrintItems()
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
//Task 1
//Generic Classes:
//Create a generic class named Pair<T, U>.This class should represent a pair of two different types.
//It should have two properties - First and Second - to hold the pair of items.

//Include methods in the class:

//SetValues(T first, U second): This method should set the values of First and Second.
//GetValues(): This method should return a tuple of First and Second.
//Test the Pair<T, U> class using different pair of data types(like integer and string, float and string etc.)
//and demonstrate its functionality.


//Task 2
//Generic Methods:
//Define a generic method Swap<T> within a non-generic class SwapUtility.
//This method should take two references(ref parameters) to variables of a generic type and swap their values.
//Create a test program which demonstrates swapping values of different types (like integer, string, etc.).

//Task 3
//Constraints in Generics:
//Create a generic class SortedCollection<T> that maintains a sorted collection of items.
//Use the constraint on T such that T implements IComparable<T>.
//This is needed so that the items can be sorted.

//The class should have the following methods:
//AddItem(T item) : This method should add a new item to the collection and then ensure the collection remains sorted.
//GetItem(int index): This method should return the item at the given index.
//Test the SortedCollection<T> class with a simple custom class that implements IComparable<T>,
//and show how the items are always sorted when added to the collection.

//Task 4 do as much practice as you can with generics
//I think you liked the previous assignment. try to appy generics to the previous RPG game ;)