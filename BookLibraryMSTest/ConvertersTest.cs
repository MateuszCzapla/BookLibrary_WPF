using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLibrary.Views.Converters;

namespace BookLibraryMSTest
{
    [TestClass]
    public class ConvertersTest
    {
        [TestMethod]
        public void IntToStringConverterTest()
        {
            //Arrange
            IntToStringConverter converter = new IntToStringConverter();
            int val1 = 1;
            string val2 = "1";

            //Act
            object obj = converter.Convert(val1, typeof(int), null, System.Globalization.CultureInfo.CurrentCulture);
            string str = val1.ToString();

            //Assert
            Assert.IsInstanceOfType(obj, typeof(string));
            Assert.AreEqual(val2, str);
        }
    }
}
