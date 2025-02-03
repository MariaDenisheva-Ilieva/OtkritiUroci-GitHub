using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задача4___11._11._24
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Прочитане на входните данни за окръжността
            double h = double.Parse(textBox1.Text);
            double k = double.Parse(textBox2.Text);
            double R = double.Parse(textBox3.Text);

            // Прочитане на входните данни за правата
            double a = double.Parse(textBox4.Text);
            double b = double.Parse(textBox5.Text);
            double c = double.Parse(textBox6.Text);

            // Решаване на системата
            double A = a * a + b * b;
            double B = 2 * (a * c + a * b * k - b * b * h);
            double C = c * c + 2 * b * c * k + b * b * (h * h + k * k - R * R);

            double discriminant = B * B - 4 * A * C;

            // Показване на резултата
            if (discriminant < 0)
            {
                label10.Text = "Няма общи точки.";
            }
            else if (discriminant == 0)
            {
                double x = -B / (2 * A);
                double y = (-a * x - c) / b;
                label10.Text = $"Една пресечна точка:\n({x:F2}, {y:F2})";
            }
            else
            {
                double x1 = (-B + Math.Sqrt(discriminant)) / (2 * A);
                double x2 = (-B - Math.Sqrt(discriminant)) / (2 * A);
                double y1 = (-a * x1 - c) / b;
                double y2 = (-a * x2 - c) / b;
                label10.Text = $"Две пресечни точки:\n({x1:F2}, {y1:F2})\n({x2:F2}, {y2:F2})";
            }

            // Рисуване на графиката
            DrawGraph(h, k, R, a, b, c);
        }

        private void DrawGraph(double h, double k, double R, double a, double b, double c)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                int centerX = pictureBox1.Width / 2;
                int centerY = pictureBox1.Height / 2;
                int scale = 50; // 1 единица = 50 пиксела

                // Рисуване на координатни оси
                Pen axisPen = new Pen(Color.Gray, 1);
                g.DrawLine(axisPen, 0, centerY, pictureBox1.Width, centerY); // X ос
                g.DrawLine(axisPen, centerX, 0, centerX, pictureBox1.Height); // Y ос

                // Рисуване на решетка
                Pen gridPen = new Pen(Color.LightGray, 1);
                for (int x = centerX; x < pictureBox1.Width; x += scale)
                    g.DrawLine(gridPen, x, 0, x, pictureBox1.Height);
                for (int x = centerX; x > 0; x -= scale)
                    g.DrawLine(gridPen, x, 0, x, pictureBox1.Height);
                for (int y = centerY; y < pictureBox1.Height; y += scale)
                    g.DrawLine(gridPen, 0, y, pictureBox1.Width, y);
                for (int y = centerY; y > 0; y -= scale)
                    g.DrawLine(gridPen, 0, y, pictureBox1.Width, y);

                // Рисуване на окръжността
                int radius = (int)(R * scale);
                int circleX = centerX + (int)(h * scale) - radius;
                int circleY = centerY - (int)(k * scale) - radius;
                g.DrawEllipse(Pens.Blue, circleX, circleY, 2 * radius, 2 * radius);

                // Рисуване на правата
                if (b != 0)
                {
                    float slope = (float)(-a / b);
                    float intercept = (float)(-c / b);

                    PointF p1 = new PointF(0, centerY - intercept * scale);
                    PointF p2 = new PointF(pictureBox1.Width, centerY - (slope * (pictureBox1.Width - centerX) / scale + intercept) * scale);
                    g.DrawLine(Pens.Red, p1, p2);
                }
                else
                {
                    int x = centerX + (int)(-c / a * scale);
                    g.DrawLine(Pens.Red, x, 0, x, pictureBox1.Height);
                }

                // Намиране и маркиране на пресечните точки
                DrawIntersectionPoints(g, h, k, R, a, b, c, centerX, centerY, scale);
            }

            pictureBox1.Image = bmp;
        }

        private void DrawIntersectionPoints(Graphics g, double h, double k, double R, double a, double b, double c, int centerX, int centerY, int scale)
        {
            double A = a * a + b * b;
            double B = 2 * (a * c + a * b * k - b * b * h);
            double C = c * c + 2 * b * c * k + b * b * (h * h + k * k - R * R);

            double discriminant = B * B - 4 * A * C;

            if (discriminant < 0)
            {
                label10.Text = "Няма общи точки.";
                return;
            }

            Pen pointPen = new Pen(Color.Green, 3);
            Brush labelBrush = Brushes.Black;

            if (discriminant == 0)
            {
                double x = -B / (2 * A);
                double y = (-a * x - c) / b;

                // Преобразуване към пиксели
                int px = centerX + (int)(x * scale);
                int py = centerY - (int)(y * scale);

                g.DrawEllipse(pointPen, px - 3, py - 3, 6, 6);
                g.DrawString($"({x:F2}, {y:F2})", new Font("Arial", 10), labelBrush, px + 5, py - 15);
                label10.Text = $"Една пресечна точка: ({x:F2}, {y:F2})";
            }
            else
            {
                double x1 = (-B + Math.Sqrt(discriminant)) / (2 * A);
                double x2 = (-B - Math.Sqrt(discriminant)) / (2 * A);
                double y1 = (-a * x1 - c) / b;
                double y2 = (-a * x2 - c) / b;

                // Преобразуване към пиксели
                int px1 = centerX + (int)(x1 * scale);
                int py1 = centerY - (int)(y1 * scale);
                int px2 = centerX + (int)(x2 * scale);
                int py2 = centerY - (int)(y2 * scale);

                g.DrawEllipse(pointPen, px1 - 3, py1 - 3, 6, 6);
                g.DrawString($"({x1:F2}, {y1:F2})", new Font("Arial", 10), labelBrush, px1 + 5, py1 - 15);

                g.DrawEllipse(pointPen, px2 - 3, py2 - 3, 6, 6);
                g.DrawString($"({x2:F2}, {y2:F2})", new Font("Arial", 10), labelBrush, px2 + 5, py2 - 15);

                label10.Text = $"Две пресечни точки:\n({x1:F2}, {y1:F2})\n({x2:F2}, {y2:F2})";
            }
        

           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
