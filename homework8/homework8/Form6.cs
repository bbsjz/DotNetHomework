using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpHomeworkProject1;

namespace CSharpHomeworkProject1
{
    public partial class Form6 : Form2
    {
        public int Num { get; }
        public int Type { get; }
        public int DetailNum { get; }
        public Form6()
        {
            InitializeComponent();
            label1.Text = "物品ID:";
            label2.Text = "物品名:";
            label3.Text = "单价:";
            label4.Text = "数量:";
            textBox2.Text = "";
            textBox2.Enabled = true;

            Type = 1;
            DetailNum = 0;
        }

        public Form6(int num):this()
        {
            Num = num;
            this.Text = "增加订单明细";
           
        }

        public Form6(int num, int type, int detailNum) : this(num)
        {
            this.Text = "修改订单明细";
            Type = type;
            DetailNum = detailNum;

            OrderDetail orderDetail = Form1.orders[Num].Details[DetailNum];
            textBox1.Text = orderDetail.Goods.Id.ToString();
            textBox2.Text = orderDetail.Goods.Name;
            textBox3.Text = orderDetail.Goods.Price.ToString();
            textBox4.Text = orderDetail.Quantity.ToString();
        }

        public override void button1_Click(object sender, EventArgs e)
        {
            
            uint id = (uint)Form1.orders[Num].Details.Count + 1;
            Goods goods = new Goods(uint.Parse(textBox1.Text), textBox2.Text, double.Parse(textBox3.Text));
            OrderDetail orderDetail = new OrderDetail(id, goods, uint.Parse(textBox4.Text));

            if (Type == 1)
            {
                Form1.orders[Num].AddDetails(orderDetail);
            }
            else
            {
                Form1.orders[Num].Details[DetailNum] = orderDetail;
            }

            this.Close();
        }
    }
}
