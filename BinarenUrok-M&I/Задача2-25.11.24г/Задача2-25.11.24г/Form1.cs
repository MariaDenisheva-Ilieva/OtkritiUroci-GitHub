using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задача2_25._11._24г
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Дефинирано уравнение: x^2 + y^2 - 2x + 6y - 6 = 0
            // Статично зададени коефициенти
            int D = -2; // Коэффициент пред x
            int E = 6;  // Коэффициент пред y
            int F = -6; // Свободен член

            // Изчисляване на координатите на центъра
            double centerX = -D / 2.0;
            double centerY = -E / 2.0;

            // Изчисляване на радиуса
            double radius = Math.Sqrt((D / 2.0) * (D / 2.0) + (E / 2.0) * (E / 2.0) - F);

            // Показване на резултатите в етикетите
            label3.Text = $"Център: ({centerX}, {centerY})";
            label4.Text = $"Радиус: {radius:F2}";

            // Рисуване на окръжността
            DrawCircle(centerX, centerY, radius);
        }

        private void DrawCircle(double centerX, double centerY, double radius)
        {
            // Създаване на Bitmap за рисуване
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Центриране на координатната система в PictureBox
                g.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
                g.ScaleTransform(1, -1); // Обръщане на оста Y

                // Рисуване на оси
                g.DrawLine(Pens.Gray, -pictureBox1.Width / 2, 0, pictureBox1.Width / 2, 0); // X ос
                g.DrawLine(Pens.Gray, 0, -pictureBox1.Height / 2, 0, pictureBox1.Height / 2); // Y ос

                // Рисуване на окръжността
                int scale = 20; // Мащаб: 1 единица = 20 пиксела
                int drawX = (int)(centerX * scale - radius * scale);
                int drawY = (int)(centerY * scale - radius * scale);
                int diameter = (int)(radius * 2 * scale);

                g.DrawEllipse(Pens.Maroon, drawX, drawY, diameter, diameter);
            }

            // Задаване на изображението в PictureBox
            pictureBox1.Image = bmp;
        }
    }       
}
