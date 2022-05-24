using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace OrderApp
{
    public class OrderService
    {
        //the order list
        private List<Order> orders;


        public OrderService()
        {
            orders = new List<Order>();
        }

        public List<Order> Orders
        {
            get {
               using(var ctx = new OrderContext()){
                  return ctx.Orders.Include(0 = >0.Items.Select(d = >OrderItems)).ToList<Order>();
                  }
             }
        }

        public Order GetOrder(uint id)
        {
            using(var ctx = new OrderContext()){
              return ctx.Orders.Include(o.Items.Selecr(d = >d.OrderItem))
                 .SingleOrDefault(o => o.OrderId == id);
             }
        }

        public void AddOrder(Order order)
        {
            FixOrder(order);
            using (var ctx = new OrderContext()){
                ctx.Enttry(order).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public void RemoveOrder(uint orderId)
        {
            using (var ctx = new OrderContext()){
               var order = ctx.Orders.Include("Details").SingleOrDefault(o => o.OrderId == orderId);
               if (order ==null) return;
               ctx.OrderItems.RemoveRange(order.Items);
               ctx.Orders.Remove(order);
               ctx.SaveChange();
            }
        }

        public void UpdateOrder(Order newOrder)
        {
            RemoveOrder(newOrder.OrderId);
            AddOrder(newOrder);
        }

        public List<Order> QueryOrdersByGoodsName(string goodsName)
        {
            using (var ctx = new OrderContext()){
            var query = ctx.Orders.Include(o.Items.Select(d = d.OrderItem))
                    .Where(order => order.Items.Exists(item => item.GoodsName == goodsName))
                    .OrderBy(o => o.TotalPrice);
            return query.ToList();
            }
        }

        public List<Order> QueryOrdersByCustomerName(string customerName)
        {
            using (var ctx = new OrderContext()){
            return ctx.Orders.Include(o => o.Items.Selecte(d => d.OrderItems))
                .Where(order => order.Customer == customerName)
                .ToList();
            }
        }

        /*
        public void Sort()
        {
            orders.Sort();
        }

        public void Sort(Func<Order, Order, int> func)
        {
            Orders.Sort((o1, o2) => func(o1, o2));
        }
        */
 
        public void Export(String fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, Orders);
            }
        }

        public void Import(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (var ctx = new OrderContext()){
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order => {
                    if (ctx.Orders.SingleOrDefault(o => o.OrderId==order.OrderId)==null)
                    {
                        ctx.Orders.Add(order);
                    }
                });
                ctx.SaveChages();
                }
            }
        }
    }
}

