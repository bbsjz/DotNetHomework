using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class DrawTree
    {
        public Graphics graphics { get; set; }
        public double th1 { get; set; }
        public double th2 { get; set; }
        public double per1 { get; set; }
        public double per2 { get; set; }
        public double leng { get; set; }
        public int n { get; set; }
        public int red { get; set; }
        public int blue { get; set; }
        public int green { get; set; }
        public void drawCayleyTree(int n,
        double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1, red, blue, green);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1, int red, int blue, int green)
        {
            graphics.DrawLine(
                new Pen(Color.FromArgb(red,blue,green)),
                (int)x0, (int)y0, (int)x1, (int)y1);
        }
    }
}
