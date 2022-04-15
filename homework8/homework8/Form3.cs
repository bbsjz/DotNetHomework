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
    public partial class Form3 : Form
    {
        public int Num { get; }
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(int num) : this()
        {
            Num = num;
            this.Text = "订单编号为" + Form1.orders[num].Id + "的订单明细";
            bindingSource1.DataSource = Form1.orders[num].Details;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            new Form6(Num).ShowDialog();
            bindingSource1.ResetBindings(true);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            new Form6(Num, 2, e.RowIndex).ShowDialog();
            bindingSource1.ResetBindings(true);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new Form6(Num,2,dataGridView1.SelectedRows[0].Index).ShowDialog();
            bindingSource1.ResetBindings(true);
        }
    }
}
