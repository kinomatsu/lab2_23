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
        // 1. Средний балл
        // =========================

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int[] marks = textBox1.Text
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                double avg = marks.Average();

                label2.Text = "Средний балл: " + avg.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Введите оценки через пробел!");
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

                int[] marks = textBox2.Text
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

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
            catch
            {
                MessageBox.Show("Ошибка ввода!");
            }
        }

        // =========================
        // 3. Диаграмма
        // =========================

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int[] marks = textBox3.Text
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

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

                pictureBox1.Image = bmp;
            }
            catch
            {
                MessageBox.Show("Ошибка ввода!");
            }
        }

        private void DrawSector(Graphics g, int value, int total, ref float startAngle, Brush brush)
        {
            if (value == 0) return;

            float sweep = (float)value / total * 360;

            g.FillPie(
                brush,
                10,
                10,
                200,
                200,
                startAngle,
                sweep);

            startAngle += sweep;
        }
    }
}