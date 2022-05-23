using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    public class Order : IComparable
    {
        //账单上的商品列表
        public List<OrderDetail> list { get; } = new List<OrderDetail>();
        //账单ID
        public int OrderID { get; set; }
        //账单总金额
        public double sum { get => list.Sum(l => l.goods.unitValue * l.number); }
        //账单用户
        public Customer customer { get; set; }

        public DateTime dateTime { get; set; }

        public Order() { }
        //构造函数：获取账单列表，ID,用户信息，并计算商品总金额
        public Order(List<OrderDetail> list, int ID, Customer customer)
        {
            this.list = list;
            this.OrderID = ID;
            this.customer = customer;
            this.dateTime = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return order != null && order.OrderID == OrderID;
        }

        public override int GetHashCode()
        {
            return OrderID.GetHashCode();
        }
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append($"订单流水号为：{OrderID}，此订单的用户信息：{customer}，此订单金额为：{sum}\n以下为订单明细：\n");
            list.ForEach(detail => buffer.Append(detail).Append('\n'));
            buffer.Append($"订单创建时间：{dateTime.ToString("yyyy/MM/dd HH:mm:ss")}\n");
            return buffer.ToString();
        }

        public int CompareTo(Object obj)
        {
            var compare = obj as Order;
            return  OrderID - compare.OrderID ;
        }
    }
}
