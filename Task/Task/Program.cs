﻿using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bird bird = new Bird();
            Console.WriteLine(bird.GetDetails());
            Bird bird1 = new Bird("coco");
            Console.WriteLine(bird1.ToString());
            Bird bird2 = new Bird("loco", 2, "white");
            Console.WriteLine(bird2.GetDetails());
            Cat cat = new Cat();
            cat.Move();
            Fish fish = new Fish();
            fish.Move();
        }
    }
    // 1) Creating a Base Class and Derived Classes

    //Create an abstract base class called 'Animal' with properties like 'Name', 'Age' and 'Color'.
    //Implement a virtual method 'Move' which just outputs a default moving behavior(e.g., "The animal moves").
    //Now, create three derived classes 'Bird', 'Cat', and 'Fish'.
    //Override the 'Move' method in each derived class to output a specific moving behavior(e.g., "The bird flies", "The cat runs", "The fish swims").

    abstract class Animal
    {
        public string Name { 
            get => Name;
            set {
                if (String.IsNullOrWhiteSpace(value)){
                    throw new ArgumentNullException("Empty value");
                }
            } 
        }
        public int Age {
            get => Age;
            set
            {
                if (Age<0)
                {
                    throw new ArgumentOutOfRangeException("Age can't be less than 0");
                }
            }
        }
        public string Color {
            get => Color;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Empty value");
                }
            }
        }

        public virtual void Move() => Console.WriteLine("The animal moves");
    }

    class Bird : Animal
    {
        public Bird():base()
        {
            Name = "Chico";
            Age = 1;
            Color = "Gray";
        }
        public Bird(string name, int age=0, string color="Black") : this()
        {
            Name = name;
            Age = age;
            Color = color;
        }
        public override void Move()
        {
            base.Move();
            Console.WriteLine("The bird flies");
        }

        public string GetDetails()
        {
            return $"{nameof(Name)}: {base.Name}, {nameof(Age)}: {base.Age}, {nameof(Color)}: {base.Color}";
        }
        //override ToString
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name},\n{nameof(Age)}: {Age},\n{nameof(Color)}: {Color}";
        }
    }
    sealed class Cat : Animal
    {
        public override void Move()
        {
            base.Move();
            Console.WriteLine("The Cat runs");
        }
    }
    //class Lion : Cat() // class of Cat can't be inherited
    //{

    //}

    class Fish : Animal
    {
        public Fish() : base()
        {
            Name = "Nemo";
            Age = 2;
            Color = "Colorful";
        }

        public Fish(string name) : this()
        {
            Name = name;
        }

        public Fish(string name, int age) : this(name)
        {
            Age = age;
        }
        public Fish(string name, int age, string color):this(name, age)
        {
            Color = color;
        }


        public override void Move()
        {
            base.Move();
            Console.WriteLine("The fish swims");
        }


        
    }

    // 2) Using 'sealed' Keyword
    //Extend the above task.Make the 'Cat' class sealed.
    //Then try to inherit from 'Cat' and create another class 'Lion'.
    //The code should produce a compile-time error because a sealed class can't be inherited.


    // 3) Using 'base' Keyword

    //Extend the first task even further.
    //In the 'Bird', 'Cat', and 'Fish' classes, besides overriding the 'Move' method,
    //also create another method called 'GetDetails'.
    //This method should output the details of the animal(name, age, and color).
    //In this 'GetDetails' method, use the base keyword to access properties of the base class.

    // 4) Try modeling other stuff with your knowledge (as much as you can!
}