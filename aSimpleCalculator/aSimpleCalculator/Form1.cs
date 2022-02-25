using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aSimpleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] choice = new[] { "+", "-", "*", "/" };
            comboBox1.Items.AddRange(choice);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("=");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private int ifReasonable(ref double num,TextBox t,int count,int already)
        {
            try
            {
                num = double.Parse(t.Text);
                return already;
            }
            catch
            {
                if(already!=0)
                    label3.Text += "\n";
                label3.Text += "第" + count + "个操作数非数字，请输入合法值";
                already++;
                return already;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int already = 0;
            label3.Text = "";
            double num1=0;
            double num2=0;
            already = ifReasonable(ref num1, textBox1, 1, already);
            already = ifReasonable(ref num2, textBox2, 2, already);
            string numOperator = comboBox1.Text;
            if (already==0)
            {
                label3.Text = "";
                switch (numOperator)
                {
                    case "+":
                        label1.Text = Convert.ToString(num1 + num2);
                        break;
                    case "-":
                        label1.Text = Convert.ToString(num1 - num2);
                        break;
                    case "*":
                        label1.Text = Convert.ToString(num1 * num2);
                        break;
                    case "/":
                        label1.Text = Convert.ToString(num1 / num2);
                        break;
                    default:
                        label3.Text = "请选择运算符";
                        break;
                }
            }
        }
    }
}
