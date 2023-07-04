using System;
using System.Collections.Generic;
using System.Data;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

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


        class Pair<T, U>
        {
            public T First { get; set; }
            public U Second { get; set; }

            public void SetValues(T first , U second) 
            {
                First = first; Second = second;
            }

            public (T,U) GetValues(T first , U second)
            {
                return (first, second);
            }
        }

        //Task 2
        //Generic Methods:
        //Define a generic method Swap<T> within a non-generic class SwapUtility.
        //This method should take two references(ref parameters) to variables of a generic type and swap their values.
        //Create a test program which demonstrates swapping values of different types (like integer, string, etc.).

        class SwapUtility
        {
            public void Swap<T>(ref T value1, ref T value2)
            {
                T temp = value1;
                value1 = value2;
                value2 = temp;
                Console.WriteLine("2 data types are swapped");
            }
        }

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


        class SortedCollection<T> : IComparable<SortedCollection<T>> where T : IComparable<T>
        {
            

        }



    }



}