using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задача1___Windows_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Създаване на Bitmap за рисуване
            // Прочитане на координатите на центъра и радиуса
            int centerX = int.Parse(textBox1.Text);
            int centerY = int.Parse(textBox2.Text);
            int radius = int.Parse(textBox3.Text);

            // Показване на уравнението на окръжността в Label
            label7.Text = $"Уравнение на окръжността: \n (x - {centerX})² + (y - {centerY})² = {radius}²";

            // Създаване на Bitmap за рисуване
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Преместване на началната точка (0,0) в центъра на PictureBox
                g.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);

                // Обръщане на оста Y така, че положителната Y ос да сочи нагоре
                g.ScaleTransform(1, -1);

                // Задаване на мащаб - всяко деление е 10 пиксела
                int scale = 10;

                // Рисуване на оси X и Y
                g.DrawLine(Pens.Black, -pictureBox1.Width / 2, 0, pictureBox1.Width / 2, 0);  // X ос
                g.DrawLine(Pens.Black, 0, -pictureBox1.Height / 2, 0, pictureBox1.Height / 2); // Y ос

                // Рисуване на деления по X оста
                for (int i = -pictureBox1.Width / 2; i <= pictureBox1.Width / 2; i += scale)
                {
                    g.DrawLine(Pens.Gray, i, -5, i, 5); // Малки вертикални линии за деленията по X оста
                }

                // Рисуване на деления по Y оста
                for (int i = -pictureBox1.Height / 2; i <= pictureBox1.Height / 2; i += scale)
                {
                    g.DrawLine(Pens.Gray, -5, i, 5, i); // Малки хоризонтални линии за деленията по Y оста
                }

                // Преобразуване на координатите на центъра и радиуса спрямо мащаба
                int drawX = centerX * scale - radius * scale;
                int drawY = centerY * scale - radius * scale;
                int diameter = radius * 2 * scale;

                // Рисуване на окръжността
                g.DrawEllipse(Pens.Maroon, drawX, drawY, diameter, diameter);
            }

            // Задаване на изображението в PictureBox
            pictureBox1.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

