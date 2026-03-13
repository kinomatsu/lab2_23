using System;
using System.Linq;

namespace lab2_23
{
    public class MarksCalculator
    {
        public static int[] ParseMarks(string text)
        {
            int[] marks = text
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (int m in marks)
            {
                if (m < 2 || m > 5)
                    throw new Exception("Оценки должны быть от 2 до 5");
            }

            return marks;
        }

        public static double Average(int[] marks)
        {
            return marks.Average();
        }

        public static int CountMark(int[] marks, int mark)
        {
            return marks.Count(x => x == mark);
        }

        public static double SuccessPercent(int[] marks)
        {
            int passed = marks.Count(x => x >= 3);
            return (double)passed / marks.Length * 100;
        }
    }
}