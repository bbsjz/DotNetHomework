using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpHomeworkProject1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            foreach(Order o in Form1.orders)
            {
                comboBox1.Items.Add(o.Id);
            }
            comboBox1.Text = comboBox1.Items[0].ToString();   //旧的处理方案，现已启用
        }

        public Form4(int num) : this()  //通过传入选择的行，自动显示修改的订单ID，不做大的修改了
        {
            comboBox1.Text = comboBox1.Items[num].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedItem.ToString())
            {
                case "订单ID":
                    textBox1.Text = Form1.orders[comboBox1.SelectedIndex].Id.ToString();
                    break;
                case "客户ID":
                    textBox1.Text = Form1.orders[comboBox1.SelectedIndex].Customer.Id.ToString();
                    break;
                case "客户名":
                    textBox1.Text = Form1.orders[comboBox1.SelectedIndex].Customer.Name;
                    break;
                case "订单明细":
                    new Form3(comboBox1.SelectedIndex).ShowDialog();
                    break;
            }

            new Form5().ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedItem.ToString())
            {
                case "订单ID":
                    textBox1.Text = Form1.orders[comboBox1.SelectedIndex].Id.ToString();
                    break;
                case "客户ID":
                    textBox1.Text = Form1.orders[comboBox1.SelectedIndex].Customer.Id.ToString();
                    break;
                case "客户名":
                    textBox1.Text = Form1.orders[comboBox1.SelectedIndex].Customer.Name;
                    break;
                case "订单明细":
                    new Form3(comboBox1.SelectedIndex).ShowDialog();
                    break;
            }
        }
    }
}
