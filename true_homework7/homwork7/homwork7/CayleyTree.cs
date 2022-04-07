using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

public class Form1 : Form
{
	public Form1()
	{
		this.AutoScaleBaseSize = new Size(6, 14);
		this.ClientSize = new Size(400, 300);
		this.Paint += new PaintEventHandler(this.Form1_Paint);
	}
	static void Main() 
	{
		Application.Run(new Form1());
	}
	private void Form1_Paint(object sender, PaintEventArgs e)
	{
		graphics = e.Graphics ;
		drawCayleyTree( 10, 200, 310, 100, -Math.PI/2 );
	}

	private Graphics graphics;
	readonly double th1 = 30 * Math.PI / 180;
	readonly double th2 = 20 * Math.PI / 180;
	readonly double per1 = 0.6;
	readonly double per2 = 0.7;

	void drawCayleyTree(int n, 
			double x0, double y0, double leng, double th)
	{
		if( n==0 ) return;

		double x1 = x0 + leng * Math.Cos(th);
		double y1 = y0 + leng * Math.Sin(th);
		
		drawLine(x0, y0, x1, y1);
		
		drawCayleyTree( n - 1, x1, y1, per1 * leng, th + th1 );
		drawCayleyTree( n - 1, x1, y1, per2 * leng, th - th2 );
	}
	void drawLine( double x0, double y0, double x1, double y1 ){
		graphics.DrawLine( 
			Pens.Blue,
			(int)x0, (int)y0, (int)x1, (int)y1 );
	}

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1829, 1070);
            this.Name = "Form1";
            this.ResumeLayout(false);

    }
}
