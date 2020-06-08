using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NuGet.Frameworks;
using System;
using Xunit;


namespace gradebook.Test
{
    public class TypeTests
    {

        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Book 1 Name");

            Assert.Equal("New Book 1 Name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }


        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Book 1 Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book  = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Book 1 Name");

            Assert.Equal("New Book 1 Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            //act

            //assert
            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
        }

        [Fact]
        public void TwoVarsReferencesameObject()
        {
            //arrange
            var book1 = GetBook("Book1");
            var book2 = book1;

            //act

            //assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }


        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
