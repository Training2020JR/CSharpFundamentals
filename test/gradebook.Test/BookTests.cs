using System;
using Xunit;


namespace gradebook.Test
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(1);
            book.AddGrade(2);
            book.AddGrade(3);
            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(2, result.Average);
            Assert.Equal(3, result.Highest);
            Assert.Equal(1, result.Lowest);
        }
    }
}

