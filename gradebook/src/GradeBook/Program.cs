using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {   
            var numbers = new[] {12.7, 13.1, 7.3};
            var grades = new List<double>() {12.7, 13.1, 7.3};
            grades.Add(56.1);
            
            var result = 0.0;
            foreach(double number in numbers)
            {
                result += number;
            }
            result /= grades.Count;
            var avg = grades.Average();
            System.Console.WriteLine(avg);
            System.Console.WriteLine(result);

            if(args.Length > 0)
            {
                Console.WriteLine($"Hello, {args[0]}!");
            }
            else 
            {
                Console.WriteLine("Hello!");
            }
        }
    }
}
