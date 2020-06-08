using System;
using System.Collections.Generic;
using System.Globalization;
using System.Transactions;

namespace gradebook
{


    class Program
    {
        static void Main(string[] args)
        {
            var x = 4.3;
            double y = 3.2;
            var result = x + y;
            Console.WriteLine($"1) Result:{result}");

            double[] numbers=new double[3];
            numbers[0] = 2.3;
            numbers[1] = 4.3;
            numbers[2] = 6.3;
            var result2 = numbers[0] + numbers[1] + numbers[2];
            Console.WriteLine($"2) Result:{result2}");

            double[] numbers2 = new double[3] { 1.2, 3.1, 5.6 };
            result2 = numbers2[0] + numbers2[1] + numbers2[2];
            Console.WriteLine($"3) Result:{result2}");

            result2 = 0;
            foreach (double number in numbers2)
            {
                result2 += number;
            }
            Console.WriteLine($"4) Result:{result2}");

            List<double> grades= new List<double>();
            grades.Add(1.2);
            grades.Add(3.2);
            grades.Add(10.2);
            result2 = 0;
            foreach (double number in grades)
            {
                result2 += number;
            }
            Console.WriteLine($"5) Avg Result:{result2/grades.Count:N3}");


            var book = new InMemoryBook("Book ABC");
            book.AddGrade(45.2);
            book.AddGrade(15.2);
            book.AddGrade(25.2);
            book.ShowStatistics();

            Statistic x1 = book.GetStatistics();

            Console.WriteLine($"A) Average: {x1.Average:N1}");
            Console.WriteLine($"B) Highest: {x1.Highest}");
            Console.WriteLine($"C) Lowest: {x1.Lowest}");
            Console.WriteLine($"D) Letter: {x1.letter}");


            if (args.Length > 0)
            {
                Console.WriteLine($"Hello World {args[0]}!");
            }
            else
            {
                Console.WriteLine("Needs to have an argument");
            }
        }
    }
}
