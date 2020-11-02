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

            while (true)
            {   
                Console.WriteLine("Please enter a grade (or type complete to finish adding grades).");
                var input = Console.ReadLine();

                if(input == "complete")
                {
                   break;
                }
                
                var grade = double.Parse(input);
                book.AddGrade(grade);
            }
            
            var stats = book.GetStatistics();
            System.Console.WriteLine($"The max grade is: {stats.High}");
            System.Console.WriteLine($"The min grade is: {stats.Low}");
            System.Console.WriteLine($"The avg grade is: {stats.Average}");
            System.Console.WriteLine($"The letter grade is: {stats.Letter}");
        }       
    }
}
