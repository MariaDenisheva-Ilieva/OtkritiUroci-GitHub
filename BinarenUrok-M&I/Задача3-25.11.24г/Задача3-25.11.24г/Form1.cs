using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задача3_25._11._24г
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Задаване на координати на точките
            double ax = 1, ay = 3;
            double bx = 3, by = -1;
            double cx = 5, cy = 0;

            // Изчисляване на детерминанти за центъра на окръжността
            double d = 2 * (ax * (by - cy) + bx * (cy - ay) + cx * (ay - by));
            double ux = ((Math.Pow(ax, 2) + Math.Pow(ay, 2)) * (by - cy) +
                         (Math.Pow(bx, 2) + Math.Pow(by, 2)) * (cy - ay) +
                         (Math.Pow(cx, 2) + Math.Pow(cy, 2)) * (ay - by)) / d;
            double uy = ((Math.Pow(ax, 2) + Math.Pow(ay, 2)) * (cx - bx) +
                         (Math.Pow(bx, 2) + Math.Pow(by, 2)) * (ax - cx) +
                         (Math.Pow(cx, 2) + Math.Pow(cy, 2)) * (bx - ax)) / d;

            // Изчисляване на радиуса на окръжността
            double radius = Math.Sqrt(Math.Pow(ux - ax, 2) + Math.Pow(uy - ay, 2));

            // Показване на уравнението на окръжността
            label4.Text = $"Уравнение на окръжността:\n(x - {ux})² + (y - {uy})² = {Math.Pow(radius, 2)}";

            // Рисуване на окръжността в PictureBox
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Центриране на координатната система в средата на PictureBox
                g.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
                g.ScaleTransform(1, -1); // Обръщане на Y оста

                int scale = 10; // мащаб

                // Рисуване на оси
                g.DrawLine(Pens.Black, -pictureBox1.Width / 2, 0, pictureBox1.Width / 2, 0);
                g.DrawLine(Pens.Black, 0, -pictureBox1.Height / 2, 0, pictureBox1.Height / 2);

                // Рисуване на окръжността
                int drawX = (int)((ux - radius) * scale);
                int drawY = (int)((uy - radius) * scale);
                int diameter = (int)(2 * radius * scale);
                g.DrawEllipse(Pens.Blue, drawX, drawY, diameter, diameter);
            }

            // Задаване на изображението в PictureBox
            pictureBox1.Image = bmp;
        }

    }
}

