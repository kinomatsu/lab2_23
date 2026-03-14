using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab2_23;

namespace lab2Utests
{
    [TestClass]
    public class MarksCalculatorAdvancedTests
    {
        // =============================
        // Тест с пробелами
        // =============================
        [TestMethod]
        public void ParseMarks_InputWithExtraSpaces_ReturnsArray()
        {
            string input = " 5  4 3  2  ";
            int[] expected = { 5, 4, 3, 2 };

            int[] result = MarksCalculator.ParseMarks(input);

            CollectionAssert.AreEqual(expected, result);
        }

        // =============================
        // Проверка среднего для одинаковых оценок
        // =============================
        [TestMethod]
        public void Average_AllSameMarks_ReturnsSameValue()
        {
            int[] marks = { 4, 4, 4, 4 };
            double result = MarksCalculator.Average(marks);

            Assert.AreEqual(4.0, result, 0.01);
        }

        // =============================
        // Проверка CountMark для нуля
        // =============================
        [TestMethod]
        public void CountMark_NoSuchMark_ReturnsZero()
        {
            int[] marks = { 5, 5, 4 };
            int count = MarksCalculator.CountMark(marks, 3);

            Assert.AreEqual(0, count);
        }

        // =============================
        // Проверка SuccessPercent для всех двойок
        // =============================
        [TestMethod]
        public void SuccessPercent_AllFail_ReturnsZero()
        {
            int[] marks = { 2, 2, 2, 2 };
            double result = MarksCalculator.SuccessPercent(marks);

            Assert.AreEqual(0.0, result, 0.01);
        }

        // =============================
        // Проверка SuccessPercent для всех сдали
        // =============================
        [TestMethod]
        public void SuccessPercent_AllPass_Returns100()
        {
            int[] marks = { 3, 4, 5, 5, 4 };
            double result = MarksCalculator.SuccessPercent(marks);

            Assert.AreEqual(100.0, result, 0.01);
        }

        // =============================
        // Большой набор оценок
        // =============================
        [TestMethod]
        public void Average_LargeArray_CalculatesCorrectly()
        {
            int[] marks = new int[1000];
            for (int i = 0; i < marks.Length; i++)
                marks[i] = (i % 4) + 2; // 2,3,4,5 повторяются

            double expected = (2 + 3 + 4 + 5) / 4.0; // среднее одной группы
            double result = MarksCalculator.Average(marks);

            Assert.AreEqual(expected, result, 0.01);
        }
    }
}