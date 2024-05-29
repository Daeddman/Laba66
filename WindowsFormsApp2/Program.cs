using System;
using System.Drawing;
using System.Windows.Forms;

namespace FaceDrawing
{
    public class MainForm : Form
    {
        public MainForm()
        {
            this.Text = "Face Drawing";
            this.Size = new Size(400, 400);
            this.Paint += new PaintEventHandler(this.OnPaint);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Малюємо обличчя
            Pen pen = new Pen(Color.Black, 2);
            Brush brush = new SolidBrush(Color.Yellow);
            g.FillEllipse(brush, 100, 50, 200, 200); // Обличчя
            g.DrawEllipse(pen, 100, 50, 200, 200); // Контур обличчя

            // Очі
            brush = new SolidBrush(Color.White);
            g.FillEllipse(brush, 150, 100, 30, 30); // Ліве око
            g.FillEllipse(brush, 220, 100, 30, 30); // Праве око
            pen = new Pen(Color.Black, 2);
            g.DrawEllipse(pen, 150, 100, 30, 30); // Контур лівого ока
            g.DrawEllipse(pen, 220, 100, 30, 30); // Контур правого ока

            // Зіниці
            brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, 160, 110, 10, 10); // Ліва зіниця
            g.FillEllipse(brush, 230, 110, 10, 10); // Права зіниця

            // Рот
            brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, 170, 170, 60, 30); // Рот
            pen = new Pen(Color.Black, 2);
            g.DrawEllipse(pen, 170, 170, 60, 30); // Контур рота

            // Стираємо верхню частину рота, щоб створити посмішку
            brush = new SolidBrush(Color.Yellow);
            g.FillRectangle(brush, 170, 170, 60, 15);
            g.DrawArc(pen, 170, 170, 60, 30, 0, -180);
        }

        [STAThread]
        public static void Main()
        {
            Application.Run(new MainForm());
        }
    }
}
