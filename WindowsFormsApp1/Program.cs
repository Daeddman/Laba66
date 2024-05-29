using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    public Form1()
    {
        this.Text = "Drawing Shapes";
        this.Size = new Size(800, 600);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;

        // Draw a filled segment of a circle
        Rectangle circleRect = new Rectangle(50, 50, 100, 100);
        Brush circleBrush = Brushes.Red;
        g.FillPie(circleBrush, circleRect, 0, 90);

        // Draw a regular hexagon
        PointF[] hexagonPoints = CalculatePolygonPoints(6, 100, new Point(300, 100));
        Pen hexagonPen = new Pen(Color.Blue, 2);
        g.DrawPolygon(hexagonPen, hexagonPoints);

        // Draw a filled regular triangle
        PointF[] trianglePoints = CalculatePolygonPoints(3, 100, new Point(500, 100));
        Brush triangleBrush = Brushes.Green;
        g.FillPolygon(triangleBrush, trianglePoints);

        // Draw an elliptical arc
        Rectangle ellipseRect = new Rectangle(200, 300, 200, 100);
        Pen ellipsePen = new Pen(Color.Black, 2);
        g.DrawArc(ellipsePen, ellipseRect, 0, 180);

       
    }

    private PointF[] CalculatePolygonPoints(int sides, float radius, Point center)
    {
        PointF[] points = new PointF[sides];
        float angle = (float)(2 * Math.PI / sides);
        for (int i = 0; i < sides; i++)
        {
            float x = center.X + radius * (float)Math.Cos(i * angle);
            float y = center.Y + radius * (float)Math.Sin(i * angle);
            points[i] = new PointF(x, y);
        }
        return points;
    }

    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
}
