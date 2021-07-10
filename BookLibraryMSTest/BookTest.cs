using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BookLibrary.Models;

namespace BookLibraryMSTest
{
    [TestClass]
    public class BookTest
    {
        private const int repeatsNumber = 100000;
        private Random rndID = new Random();
        private Random rndShort = new Random();

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

        [TestMethod]
        public void ConstructorAndPropertiesTest_RandomNumericalValues()
        {
            int[] randomIDValues = new int[repeatsNumber];
            short[] randomYearValues = new short[repeatsNumber];

            for (int i = 0; i < repeatsNumber; i++)
            {
                randomIDValues[i] = rndID.Next(int.MinValue, int.MaxValue);
                randomYearValues[i] = Convert.ToInt16(rndShort.Next(short.MinValue, short.MaxValue));
            }

            for (int i = 0; i < repeatsNumber; i++)
            {
                //Arrange
                int id = randomIDValues[i];
                string title = "TestBook";
                short year = randomYearValues[i];
                DateTime timestamp = DateTime.Now;

                //Act
                Book book = new Book(id, title, year, timestamp);

                //Assert
                Assert.AreEqual(id, book.ID, "Property mismatch for ID");
                Assert.AreEqual(year, book.Year, "Property mismatch for Year");
            }
        }
    }
}
