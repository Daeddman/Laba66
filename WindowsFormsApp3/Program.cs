using System;
using System.Drawing;
using System.Windows.Forms;

public class ClockForm : Form
{
    private Timer timer;
    private PictureBox pictureBox;
   
    public ClockForm()
    {
        this.Text = "Clock";
        this.Width = 400;
        this.Height = 400;

       

        pictureBox = new PictureBox();
        pictureBox.Dock = DockStyle.Fill;
        pictureBox.Paint += new PaintEventHandler(this.PictureBox_Paint);
        this.Controls.Add(pictureBox);

        timer = new Timer();
        timer.Interval = 1000; // 1 second
        timer.Tick += new EventHandler(this.Timer_Tick);
        timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        pictureBox.Invalidate();
    }

    private void PictureBox_Paint(object sender, PaintEventArgs e)
    {
        DrawClock(e.Graphics);
    }

    private void DrawClock(Graphics g)
    {
        int centerX = pictureBox.Width / 2;
        int centerY = pictureBox.Height / 2;
        int radius = Math.Min(centerX, centerY) - 10;

        g.Clear(Color.White);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // Draw clock face
        g.DrawEllipse(Pens.Black, centerX - radius, centerY - radius, radius * 2, radius * 2);

        // Draw clock ticks
        DrawClockTicks(g, centerX, centerY, radius);

        // Draw clock numbers
        DrawClockNumbers(g, centerX, centerY, radius);

        // Get current time
        DateTime now = DateTime.Now;
        float hour = now.Hour % 12 + now.Minute / 60f;
        float minute = now.Minute + now.Second / 60f;
        float second = now.Second;

        // Draw hour hand
        DrawHand(g, centerX, centerY, hour / 12f * 360 - 90, radius * 0.5f, Pens.Black, 8);

        // Draw minute hand
        DrawHand(g, centerX, centerY, minute / 60f * 360 - 90, radius * 0.7f, Pens.Black, 6);

        // Draw second hand
        DrawHand(g, centerX, centerY, second / 60f * 360 - 90, radius * 0.9f, Pens.Red, 2);
    }

    private void DrawClockTicks(Graphics g, int centerX, int centerY, int radius)
    {
        for (int i = 0; i < 60; i++)
        {
            float angle = i * 6; // Each tick mark is 6 degrees apart
            float innerRadius = (i % 5 == 0) ? radius * 0.85f : radius * 0.9f; // Longer tick for hours, shorter for minutes
            float outerRadius = radius;
            float x1 = centerX + (float)(innerRadius * Math.Cos(Math.PI * angle / 180 - Math.PI / 2));
            float y1 = centerY + (float)(innerRadius * Math.Sin(Math.PI * angle / 180 - Math.PI / 2));
            float x2 = centerX + (float)(outerRadius * Math.Cos(Math.PI * angle / 180 - Math.PI / 2));
            float y2 = centerY + (float)(outerRadius * Math.Sin(Math.PI * angle / 180 - Math.PI / 2));
            g.DrawLine(Pens.Black, x1, y1, x2, y2);
        }
    }

    private void DrawClockNumbers(Graphics g, int centerX, int centerY, int radius)
    {
        Font font = new Font("Arial", 14);
        Brush brush = Brushes.Black;

        for (int i = 1; i <= 12; i++)
        {
            float angle = i * 30; // Each hour mark is 30 degrees apart
            float x = centerX + (float)(radius * 0.75 * Math.Cos(Math.PI * angle / 180 - Math.PI / 2));
            float y = centerY + (float)(radius * 0.75 * Math.Sin(Math.PI * angle / 180 - Math.PI / 2));
            SizeF size = g.MeasureString(i.ToString(), font);
            g.DrawString(i.ToString(), font, brush, x - size.Width / 2, y - size.Height / 2);
        }
    }

    private void DrawHand(Graphics g, int centerX, int centerY, float angle, float length, Pen pen, int thickness)
    {
        g.TranslateTransform(centerX, centerY);
        g.RotateTransform(angle);
        g.DrawLine(new Pen(pen.Color, thickness), 0, 0, length, 0);
        g.ResetTransform();
    }

    [STAThread]
    static void Main()
    {
        Application.Run(new ClockForm());
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // ClockForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ClockForm";
            this.Load += new System.EventHandler(this.ClockForm_Load);
            this.ResumeLayout(false);

    }

    private void ClockForm_Load(object sender, EventArgs e)
    {

    }
}
