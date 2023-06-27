using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Task1();

            //Task2();

            //Task3();
         
            //Task4();
        }


        public static void Task1()
        {
            List<int> nums = new List<int> { 1, 2, 4, 5, 6, 15, 23, 31, 40, 97, 99 };

            List<int> primes = nums.Where(isPrimeNumber).ToList();

            foreach (int x in primes)
            {
                Console.WriteLine(x);
            }
        }

        public static Func<int, bool> isPrimeNumber = x =>
        {
            if (x <= 0) return false;
            if (x == 1) return false;
            if (x == 2) return true;

            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        };



        public static void Task2()
        {
            List<string> list = new List<string>() { "cat", "dog", "air", "pee" };

            List<string> results = list.Where(hasMoreConsonants).ToList();

            foreach (string result in results)
            {
                Console.WriteLine(result);
            }
        }

        public static Func<string, bool> hasMoreConsonants = x =>
        {
            char[] vowels = { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u'};
            int vowelCount = 0;

            int length = x.Length;

            for(int i=0; i < length; i++)
            {
                if (vowels.Contains(x[i]))
                {
                    vowelCount++;
                }
            }
            return vowelCount <= length/2;
        };



        public static void Task3()
        {
            List<Student> students = new List<Student>
            {
                new Student("First",new List<decimal>{ 50, 70, 30, 66, 75 }),
                new Student("Second", new List<decimal> { 42, 51, 86, 97, 35, 48, 100 }),
                new Student("Third", new List<decimal> { 75, 85, 96 }),
                new Student("Fourth", new List<decimal> { 76, 74, 85, 89, 93, 81, 98, 85 })
            };

            List<Student> result = students.Where(hasGreatAverage).ToList();

            foreach (Student student in result)
            {
                Console.WriteLine(student.Name);
            }
        }

        public class Student
        {
            public string Name { get; set; }
            public List<decimal> Grades { get; set; }

            public Student(string name, List<decimal> grades)
            {
                Name = name;
                Grades = grades;
            }
        }

        public static Func<Student, bool> hasGreatAverage = student =>
        {
            decimal total = 0;
            int count = student.Grades.Count;
            for (int i = 0; i < count; i++)
            {
                total += student.Grades[i];
            }

            //Console.WriteLine(total / count);
            return total / count > 85;

        };



        public static void Task4()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee("First","HR",4000),
                new Employee("Second","Sales",4500),
                new Employee("Third","IT",6000),
                new Employee("Fourth","HR",6500),
                new Employee("Fifth","Sales",5500),
                new Employee("Sixth","Sales",3500),
                new Employee("Seventh","IT",7000),
            };

            List<Employee> result = employees.Where(satisfiesBothConditions).ToList();

            foreach (Employee employee in result)
            {
                Console.WriteLine(employee.Name);
            }

        }

        public class Employee
        {
            public string Name { get; set; }
            public string Department { get; set; }
            public decimal Salary { get; set; }

            public Employee(string name, string department, decimal salary)
            {
                Name = name;
                Department = department;
                Salary = salary;
            }
        }

        public static Func<Employee, bool> worksInSales = employee => employee.Department == "Sales";

        public static Func<Employee, bool> earns5kSalary = employee => employee.Salary > 5000;

        public static Func<Employee, bool> satisfiesBothConditions = employee =>
        {
            return worksInSales(employee) && earns5kSalary(employee);
        };
           
    }

    // Before you start!!!!!!!!!!!!
    // you don't need to use the keyword "delegate" in any of these tasks (use FUNC!).
    // do a little reasearch about LINQ and "Where" method in LINQ
    // you will have to create 3 functions, that will be passed to the WHERE method.

    //  Task 1: Filtering Prime Numbers
    //  You have a list of numbers from 1 to 1000.
    //  You need to create a new list that only includes the prime numbers from the original list.
    //  Use a delegate to decide if a number is prime or not.
    //  This will involve checking every number from 2 to the square root of the number you're checking to see if it divides evenly.

    //  Task 2: Filtering Words Based on Consonant Count
    //  You have a list of different words.
    //  You need to make a new list that only includes the words where the count of consonants is greater than the count of vowels.
    //  In English, the vowels are A, E, I, O, U and sometimes Y. All the other letters are consonants.
    //  Use a delegate to decide if a word has more consonants than vowels.

    //  Task 3: Filtering Students Based on Average Grades
    //  You have a list of students, and each student has a name and a list of grades.
    //  You need to make a new list that only includes the students whose average grade is greater than 85.
    //  This will involve adding up all of a student's grades and dividing by the total number of grades to find the average.
    //  Use a delegate to decide if a student's average grade is greater than 85.


    //  Task 4: Filtering Employees by Department and Salary (Hard one)
    //  You have a list of workers.
    //  Each worker has a name, a department where they work, and a salary.
    //  You need to create a new list.
    //  This list should only have workers who work in the "Sales" department and earn more than $5000.
    //  To do this, you will create three functions:
    //  1) The first function will check if a worker is in the "Sales" department.
    //  2) The second function will check if a worker earns more than $5000.
    //  3)  After you create these two functions, you will create a third function.
    //      This function will combine the first two functions.
    //      If a worker passes both checks, they should be added to the new list.
    //  Use this THIRD(!!) function with the Where method to create your new list.
    //  This task will help you understand how to use multiple functions together to filter a list.
}