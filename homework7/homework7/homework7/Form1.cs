using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private DrawTree drawTree;
        public Form1()
        {
            InitializeComponent();
            drawTree = new DrawTree();
            graphics = panelTree.CreateGraphics();
            drawTree.graphics = graphics;
        }
        private void Form1_Paint()
        {
            Size changeSize = new Size(this.Width, this.Height);
            panelTree.Size = changeSize;
            graphics = panelTree.CreateGraphics();
            drawTree.graphics = graphics;
            drawTree.drawCayleyTree(drawTree.n, this.Width*0.6, this.Height*0.75, drawTree.leng, -Math.PI / 2);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            drawTree.n = recursionDepth.Value;
            depthLabel.Text = "递归深度" + drawTree.n;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphics.Clear(this.BackColor);
            Form1_Paint();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            drawTree.leng = length.Value;
            lengthLabel.Text = "主干长度" + drawTree.leng;
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            drawTree.per2 = per2Bar.Value/100.0;
            per1Label.Text = "左分支长度比" + drawTree.per2;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            drawTree.per1 = per1Bar.Value/100.0;
            per2Label.Text = "右分支长度比" + drawTree.per1;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            drawTree.th2 = th2Bar.Value*Math.PI/180;
            th2Label.Text = "左分支角度" + Math.Round((double)drawTree.th2, 2);
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            drawTree.th1 = th1Bar.Value*Math.PI/180;
            th1Label.Text = "右分支角度" + Math.Round((double)drawTree.th1, 2);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(redBox.Text);
                if (value > 255 || value < 0)
                {
                    redWarning.Text = "请输入正确的red值，取值0-255";
                }
                else
                {
                    redWarning.Text = "";
                    drawTree.red = value;
                }
            }
            catch
            {
                redWarning.Text = "请输入合法的数字，取值0-255";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(blueBox.Text);
                if(value>255||value<0)
                {
                    blueWarning.Text = "请输入正确的blue值，取值0-255";
                }
                else
                {
                    blueWarning.Text = "";
                    drawTree.blue = value;
                }
            }
            catch
            {
                blueWarning.Text = "请输入合法的数字，取值0-255";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(greenBox.Text);
                if (value > 255 || value < 0)
                {
                    greenWarning.Text = "请输入正确的green值，取值0-255";
                }
                else
                {
                    greenWarning.Text = "";
                    drawTree.green = value;
                }
            }
            catch
            {
                greenWarning.Text = "请输入合法的数字，取值0-255";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
