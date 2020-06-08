using System;
using Xunit;


namespace gradebook.Test
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAverageGrades()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(1);
            book.AddGrade(2);
            book.AddGrade(3);
            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(2, result.Average,1);
            Assert.Equal(3, result.Highest,1);
            Assert.Equal(1, result.Lowest,1);
        }
    }
}

