using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {   
            var book = new Book("Robert's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            var stats = book.GetStatistics();
            System.Console.WriteLine($"The max grade is: {stats.High}");
            System.Console.WriteLine($"The min grade is: {stats.Low}");
            System.Console.WriteLine($"The avg grade is: {stats.Average}");
        }       
    }
}
