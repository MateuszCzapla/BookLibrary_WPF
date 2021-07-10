using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BookLibrary.Models;

namespace BookLibraryMSTest
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        public void ConstructorAndPropertiesTest()
        {
            //Arrange
            int id = 1;
            string title = "TestBook";
            short year = 1989;
            DateTime timestamp = DateTime.Now;

            //Act
            Book book = new Book(id, title, year, timestamp);

            //Assert
            Assert.AreEqual(id, book.ID, "Property mismatch for ID");
            Assert.AreEqual(title, book.Title, "Property mismatch for Title");
            Assert.AreEqual(year, book.Year, "Property mismatch for Year");
            Assert.AreEqual(timestamp, book.Timestamp, "Property mismatch for Timestamp");
        }
    }
}
