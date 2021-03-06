using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact] //Attribute
        public void BookCaculatesAnAverageGrade()
        {
            //Arrange Section
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            
            //Act Section
            var result = book.GetStatistics();

            //Assert Section
            Assert.Equal(85.6,result.Average, 1);
            Assert.Equal(90.5,result.High, 1);
            Assert.Equal(77.3,result.Low, 1);
            Assert.Equal('B',result.Letter);
        }

        public void AddHigherGrade()
        {
            var book = new Book("");
            book.AddGrade(50);
            book.AddGrade(150);

            //idk what assert to test
        }
    }
}
