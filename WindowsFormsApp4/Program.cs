using System;
using System.Drawing;
using System.Windows.Forms;

public class BulldozerForm : Form
{
    private Timer timer;
    private int bulldozerX;
    private bool shovelUp;
    private int shovelMovementCounter;

    public BulldozerForm()
    {
        this.Text = "Bulldozer Animation";
        this.DoubleBuffered = true;
        this.ClientSize = new Size(800, 600);

        timer = new Timer();
        timer.Interval = 50; // таймер спрацьовує кожні 50 мс
        timer.Tick += new EventHandler(OnTimerTick);
        timer.Start();

        bulldozerX = 0;
        shovelUp = true;
        shovelMovementCounter = 0;
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        bulldozerX += 5; // рухаємо бульдозер вправо
        if (bulldozerX > this.ClientSize.Width)
        {
            bulldozerX = -100; // повертаємо бульдозер вліво за межі екрану
        }

        shovelMovementCounter++;
        if (shovelMovementCounter % 50 == 0) // кожні 50 тік змінюємо стан лопати
        {
            shovelUp = !shovelUp;
        }

        this.Invalidate(); // перерисовуємо форму
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;

        DrawBulldozer(g, bulldozerX, this.ClientSize.Height - 100, shovelUp);
    }

    private void DrawBulldozer(Graphics g, int x, int y, bool shovelUp)
    {
        // малюємо кузов бульдозера
        g.FillRectangle(Brushes.Yellow, x, y - 40, 100, 40);
        g.FillRectangle(Brushes.Yellow, x + 20, y - 60, 60, 20);

        // малюємо колеса бульдозера
        g.FillEllipse(Brushes.Black, x + 10, y - 20, 20, 20);
        g.FillEllipse(Brushes.Black, x + 70, y - 20, 20, 20);

        // малюємо лопату бульдозера
        int shovelY = shovelUp ? y - 70 : y - 30;
        Point[] shovelPoints =
        {
            new Point(x, y - 40),
            new Point(x - 30, shovelY),
            new Point(x, shovelY)
        };
        g.FillPolygon(Brushes.Gray, shovelPoints);
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new BulldozerForm());
    }
}
