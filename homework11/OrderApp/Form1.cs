using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace OrderApp
{
    public partial class Form1 : Form
    {
        public string KeyWord { get; set; }
        public OrderItem goods1;
        public OrderItem goods2;
        public OrderItem goods3;


        public Order order1;
        public Order order2;
        public Order order3;

        public OrderService os = new OrderService();

        string fileName = @"./orders.xml";

        public Form1()
        {
            InitializeComponent();
            goods1 = new OrderItem(1, "goods1", 10.0, 80);
            goods2 = new OrderItem(2, "goods2", 1.2, 200);
            goods3 = new OrderItem(3, "goods3", 50, 10);

            order1 = new Order(1, "Customer1", new List<OrderItem> { goods1, goods2, goods3 });
            order2 = new Order(2, "Customer2", new List<OrderItem> { goods2, goods3 });
            order3 = new Order(3, "Customer2", new List<OrderItem> { goods1, goods3 });

            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);

            orderBindingSource.DataSource = os.Orders;

            queryInputTextBox.DataBindings.Add("Text", this, "KeyWord");
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            OrderItem orderItem = new OrderItem();
            order.AddItem(orderItem);
            os.AddOrder(order);
            Form2 form2 = new Form2(order, orderItem);
            form2.Show(this);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            uint orderID = (uint)orderDataGridView.CurrentRow.Cells[0].Value;
            Order order = os.GetOrder(orderID);
            uint index = (uint)itemDataGridView.CurrentRow.Cells[0].Value;
            OrderItem orderItem = order.GetItem(index);
            Form2 form2 = new Form2(order, orderItem);
            form2.Show(this);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            uint orderID = (uint)orderDataGridView.CurrentRow.Cells[0].Value;
            Order order = os.GetOrder(orderID);
            if (order != null)
            {
                os.Orders.Remove(order);
            }
            orderBindingSource.ResetBindings(false);
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order => {
                    if (!os.Orders.Contains(order))
                    {
                        os.Orders.Add(order);
                    }
                });
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, os.Orders);
            }
        }

        private void searchByCustomerButton1_Click(object sender, EventArgs e)
        {
            if (KeyWord == null || KeyWord == "")
            {
                orderBindingSource.DataSource = os.Orders;
            }
            else
            {
                orderBindingSource.DataSource = os.Orders.Where(s => s.Customer == KeyWord);
            }
        }

        private void searchByGoodsNameButto_Click(object sender, EventArgs e)
        {
            if (KeyWord == null || KeyWord == "")
            {
                orderBindingSource.DataSource = os.Orders;
            }
            else
            {
                orderBindingSource.DataSource =
                    os.Orders.Where(s => s.Items.Exists(item => item.GoodsName == KeyWord));
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void orderBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
