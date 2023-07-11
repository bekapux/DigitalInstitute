using System;
using System.Collections;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        public class MyIntegerRange : IEnumerable<int>
        {
            private int start;
            private int end;

            public MyIntegerRange(int start, int end)
            {
                if (start > end)
                {
                    throw new ArgumentException("Invalid range: start value must be less than or equal to the end value.");
                }

                this.start = start;
                this.end = end;
            }

            public IEnumerator<int> GetEnumerator()
            {
                return new IntegerRangeEnumerator(start, end);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private class IntegerRangeEnumerator : IEnumerator<int>
            {
                private int current;
                private int end;

                public IntegerRangeEnumerator(int start, int end)
                {
                    current = start - 1;
                    this.end = end;
                }

                public int Current => current;

                public int start { get; private set; }

                object IEnumerator.Current => Current;

                public void Dispose()
                {
                    // No resources to dispose
                }

                public bool MoveNext()
                {
                    if (current < end)
                    {
                        current++;
                        return true;
                    }

                    return false;
                }

                public void Reset()
                {
                    current = start - 1;
                }
            }
        }

    }
}
//Task 1: Simple IEnumerable and IEnumerator Implementation
//Create a simple class MyIntegerRange that represents a range of integers and implements IEnumerable<int>.
//It should have two private fields for the start and end of the range.
//It should use IEnumerator to iterate from the start to the end of the range.

//Task 2: Using the 'yield' Keyword
//Modify the MyIntegerRange class from the first task to use the yield keyword in its GetEnumerator() method instead of manually implementing an IEnumerator.

//Task 3: Fibonacci Sequence with 'yield' (It's not that easy :P)
//Create a method IEnumerable<int> Fibonacci(int n) that returns an IEnumerable sequence of the first n numbers in the Fibonacci series using the 'yield' keyword.