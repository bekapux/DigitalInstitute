﻿using System;
using System.Collections.Generic;
using System.Data;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // test Pair class for <int, string>
            Pair<int, string> pair = new Pair<int, string>();
            pair.SetValues(3, "Orange");
            (int, string) tuplePair = pair.GetValues();
            Console.WriteLine(tuplePair);

            // test Pair class for types <DateTime, decimal>
            Pair<DateTime, decimal> pair2 = new Pair<DateTime, decimal>();
            pair2.SetValues(DateTime.Now, 34);
            Console.WriteLine(pair2.GetValues());
        }
    }


    public class Pair<T, U>
    {
        private T? First { get; set; }
        private U? Second { get; set; }

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
}