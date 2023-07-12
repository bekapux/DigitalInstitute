using System;

namespace task23
{
    class Program
    {
        static void Main(string[] args)
        {
            AddNumbers add = Add;
            AddNumbers substruct = Substract;
            AddIntNumbers multiplication = Addition;
            MyDelegate myDelegate = (message) =>
            {
                Console.WriteLine("Nameless function called with message: " + message);
            };

            Action<int, int> del = (a, b) =>
            {
                int sum = a + b;
                Console.WriteLine("sum: " + sum);
            };

            double result = add(a: 2.4, b: 4.5);
            double result2 = substruct(4.4, 2.2);
            int result3 = multiplication(10, 20);
            del(10, 20);

            Func<int, int, int> Task5 = FirstPart;

            Func<Func<int, int, int>, int, int, int> sa = SecondPart;


            Console.WriteLine("result of the addition is: " + result);
            Console.WriteLine("Result of the substraction is: " + result2);
            Console.WriteLine("Result of the multiplication of integers: " + result3);
        }
        public delegate double AddNumbers(double a, double b);
        public delegate int AddIntNumbers(int a, int b);
        public delegate void MyDelegate(string messae);

        static double Add(double a, double b)
        {
            return a + b;
        }
        static double Substract(double a, double b)
        {
            return a - b;
        }

        static int Addition(int a, int b)
        {
            return a * b;
        }
        static int FirstPart(int firstNum, int secondNum) => firstNum + secondNum;

        static int SecondPart(Func<int, int, int> meth, int firstNum, int secondNum) => meth(firstNum, secondNum) * (firstNum + secondNum);

    }
}

//    Task 1: Use a Delegate to Add Numbers
//Make a delegate that can represent a method.
//This method should take in two numbers, add them together, and give back the result.
//Then, create this method and show how you can use the delegate to "point" to this method and use it.

//Task 2: Make a Delegate Do Multiple Things
//Take the delegate from Task 1, and show how you can make it do more than one thing.
//Make a few more methods that can also add two numbers together.
//Then, make the delegate use all these methods one after the other.

//Task 3: Make a Delegate Use a 'Nameless' Function
//Show how to use a delegate with a function that doesn't have a name.
//This is called an "anonymous function" or a "lambda".
//This function should also be able to add two numbers and give back the result.

//Task 4: Use an Action Delegate
//Action is a type of delegate that takes in parameters but does not return anything.
//Create an Action delegate that takes in two integer parameters and prints their sum to the console.
//Call this Action and verify that it works correctly.

//Task 5: Use a Func Delegate(More challenging)
//Func is a type of delegate that takes in parameters and returns a value.
//Create a Func delegate that takes in two integer parameters and returns their sum.
//Then, create another Func delegate that takes in three parameters: two integers and the previous Func delegate.
//This Func should use the delegate to add the two integers and then multiply the result by 2.
//Call this Func and verify that it works correctly.
