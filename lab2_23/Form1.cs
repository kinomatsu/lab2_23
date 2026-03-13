using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace lab2_23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // =========================
        // Метод получения оценок
        // =========================
        private int[] GetMarks(string text)
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

        // =========================
        // 1. Средний балл
        // =========================
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int[] marks = GetMarks(textBox1.Text);

                double avg = marks.Average();

                label2.Text = "Средний балл: " + avg.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =========================
        // 2. Анализ оценок
        // =========================
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();

                int[] marks = GetMarks(textBox2.Text);

                int count5 = marks.Count(x => x == 5);
                int count4 = marks.Count(x => x == 4);
                int count3 = marks.Count(x => x == 3);
                int count2 = marks.Count(x => x == 2);

                listBox1.Items.Add("5 - " + count5);
                listBox1.Items.Add("4 - " + count4);
                listBox1.Items.Add("3 - " + count3);
                listBox1.Items.Add("2 - " + count2);

                int total = marks.Length;
                int passed = marks.Count(x => x >= 3);

                double percent = (double)passed / total * 100;

                listBox1.Items.Add("");
                listBox1.Items.Add("Успеваемость: " + percent.ToString("F1") + "%");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =========================
        // 3. Диаграмма
        // =========================
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int[] marks = GetMarks(textBox3.Text);

                int count5 = marks.Count(x => x == 5);
                int count4 = marks.Count(x => x == 4);
                int count3 = marks.Count(x => x == 3);
                int count2 = marks.Count(x => x == 2);

                int total = marks.Length;

                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics g = Graphics.FromImage(bmp);

                g.Clear(Color.White);

                float startAngle = 0;

                DrawSector(g, count5, total, ref startAngle, Brushes.Green);
                DrawSector(g, count4, total, ref startAngle, Brushes.Blue);
                DrawSector(g, count3, total, ref startAngle, Brushes.Orange);
                DrawSector(g, count2, total, ref startAngle, Brushes.Red);

                // легенда
                Font font = new Font("Arial", 10);

                g.FillRectangle(Brushes.Green, 10, 10, 15, 15);
                g.DrawString("5", font, Brushes.Black, 30, 10);

                g.FillRectangle(Brushes.Blue, 10, 30, 15, 15);
                g.DrawString("4", font, Brushes.Black, 30, 30);

                g.FillRectangle(Brushes.Orange, 10, 50, 15, 15);
                g.DrawString("3", font, Brushes.Black, 30, 50);

                g.FillRectangle(Brushes.Red, 10, 70, 15, 15);
                g.DrawString("2", font, Brushes.Black, 30, 70);

                pictureBox1.Image = bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =========================
        // Рисование сектора
        // =========================
        private void DrawSector(Graphics g, int value, int total, ref float startAngle, Brush brush)
        {
            if (value == 0) return;

            float sweep = (float)value / total * 360;

            g.FillPie(
                brush,
                60,
                40,
                150,
                150,
                startAngle,
                sweep);

            startAngle += sweep;
        }
    }
}