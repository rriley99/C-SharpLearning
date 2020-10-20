using System.Collections.Generic;
using System;

namespace GradeBook
{
    class Book 
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {   
            grades.Add(grade);
        }
        public void ShowStatistics()
        {
            var result = 0.0;
            var highgrade = double.MinValue;
            var lowgrade = double.MaxValue;
            foreach(var number in grades)
            {
                highgrade = Math.Max(number, highgrade);
                lowgrade = Math.Min(number, lowgrade);
                result += number;    
                
            }
            result /= grades.Count;
            System.Console.WriteLine($"The max grade is: {highgrade:N1}");
            System.Console.WriteLine($"The min grade is: {lowgrade:N1}");
            System.Console.WriteLine($"The avg grade is: {result:N1}");
        }
        private List<double> grades;
        private string name;
    }
}