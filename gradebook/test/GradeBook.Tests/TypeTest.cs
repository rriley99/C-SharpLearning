using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact] //Attribute
        public void ValueTyoeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);
            
            Assert.Equal(42,x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }
        [Fact] //Attribute
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");  
                                
            Assert.Equal("New Name",book1.Name);
        }
        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact] //Attribute
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");  
                                
            Assert.Equal("Book 1",book1.Name);
        }

        [Fact] //Attribute
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");  
                                
            Assert.NotEqual("Book 1",book1.Name);
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }
        [Fact] //Attribute
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");    
            var book2 = GetBook("Book 2");                       
           
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact] //Attribute
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");    
            var book2 = book1;
           
            Assert.Same(book1, book2);
            
        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
        private void SetName(Book book, string name)
        {
            book.Name=name;
        }
    }
}
