using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderApp
{
    public partial class Form2 : Form
    {

        public Order order = new Order();
        public OrderItem item = new OrderItem();
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Order order, OrderItem item)
        {
            InitializeComponent();
            orderIDTextBox.DataBindings.Add("Text", order, "OrderId");
            customerTextBox.DataBindings.Add("Text", order, "Customer");
            indexTextBox.DataBindings.Add("Text", item, "index");
            GoodsNameTextBox.DataBindings.Add("Text", item, "GoodsName");
            PriceTextBox.DataBindings.Add("Text", item, "Price");
            QuantityTextBox.DataBindings.Add("Text", item, "Quantity");
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)this.Owner;
            Order order1 = new Order(order.OrderId, order.Customer, new List<OrderItem> { item });

            
            if (form1.os.Orders.Contains(order1))
            {
                Order order2 = form1.os.GetOrder(order.OrderId);

                
                if (order2.Items.Contains(item))
                {
                    OrderItem item2 = order2.GetItem(item.Index);
                    order2.RemoveItem(item2);
                    order2.Items.Add(item);
                }
                else
                {
                    order2.Items.Add(item);
                }
            }
            else
            {
                form1.os.AddOrder(order1);
            }

            form1.orderBindingSource.ResetBindings(false);
            this.Close();
        }

        private void PriceTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
