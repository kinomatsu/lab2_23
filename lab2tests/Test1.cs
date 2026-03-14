using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab2_23;

namespace lab2Tests
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void ParseMarks_ValidInput_ReturnsArray()
        {
            // Arrange
            string input = "5 4 3 2 5";
            int[] expected = { 5, 4, 3, 2, 5 };

            // Act
            int[] result = MarksCalculator.ParseMarks(input);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseMarks_InvalidInput_LessThan2_ThrowsException()
        {
            string input = "1 2 3";
            MarksCalculator.ParseMarks(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseMarks_InvalidInput_GreaterThan5_ThrowsException()
        {
            string input = "2 3 6";
            MarksCalculator.ParseMarks(input);
        }

        [TestMethod]
        public void Average_CalculatesCorrectly()
        {
            int[] marks = { 5, 4, 3, 2, 5 };
            double expected = (5 + 4 + 3 + 2 + 5) / 5.0;

            double result = MarksCalculator.Average(marks);

            Assert.AreEqual(expected, result, 0.01);
        }

        [TestMethod]
        public void CountMark_CountsCorrectly()
        {
            int[] marks = { 5, 4, 3, 2, 5 };
            Assert.AreEqual(2, MarksCalculator.CountMark(marks, 5));
            Assert.AreEqual(1, MarksCalculator.CountMark(marks, 4));
        }

        [TestMethod]
        public void SuccessPercent_CalculatesCorrectly()
        {
            int[] marks = { 5, 4, 3, 2, 5 };
            double expected = 4.0 / 5 * 100;

            double result = MarksCalculator.SuccessPercent(marks);

            Assert.AreEqual(expected, result, 0.01);
        }
    }
}