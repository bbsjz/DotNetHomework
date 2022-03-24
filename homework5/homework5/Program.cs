using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace homework5
{
    class Order:IComparable
    {
        //账单上的商品列表
        public List<OrderDetail> list = new List<OrderDetail>();
        //账单ID
        public String OrderID;
        //账单总金额
        public int sum;
        //账单用户
        public String customer;

        //构造函数：获取账单列表，ID,用户信息，并计算商品总金额
        public Order(List<OrderDetail> list,String ID,String customer)
        {
            this.list = list;
            this.OrderID = ID;
            this.customer = customer;
            sum = 0;
            Action<OrderDetail> getSum = (x=> sum+=x.unitValue*x.number);
            list.ForEach(getSum);
        }

        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            if(this.list.Count()!=order.list.Count())
            {
                return false;
            }
            bool ifEqual = true;
            for (int i = 0; i < this.list.Count(); i++)
            {
                if(!this.list[i].Equals(order.list[i]))
                {
                    ifEqual = false;
                    break;
                }
            }
            return ifEqual && this.OrderID == order.OrderID && this.customer == order.customer;
        }

        public override int GetHashCode()
        {
            return sum*list[0].unitValue*list[0].number;
        }
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append($"订单流水号为：{OrderID}，此订单的用户为：{customer}，此订单金额为：{sum}\n以下为订单明细：\n");
            int length = list.Count();
            for (int i = 0; i < length; i++)
            {
                buffer.Append($"商品{i}的名称：" + list[i]);
                buffer.Append("\n");
            }
            buffer.Append("\n");
            return buffer.ToString();
        }

        public int CompareTo(Object obj)
        {
            if (!(obj is Order))
                throw new ArgumentException("比较对象不一致");
            Order compare = (Order)obj;
            if (Convert.ToInt64(this.OrderID) > Convert.ToInt64(compare.OrderID))
                return -1;
            else
                return 1;
        }
    }

    class OrderDetail
    {
        //商品名
        public String name { get; set; }
        //商品单价
        public int unitValue { get; set; }
        //商品数量
        public int number { get; set; }
        public OrderDetail(String name,int unitValue,int number)
        {
            this.name = name;
            this.unitValue = unitValue;
            this.number = number;
        }

        public override bool Equals(object obj)
        {
            OrderDetail detail = obj as OrderDetail;
            return this.name == detail.name && this.unitValue == detail.unitValue && this.number == detail.number;
        }
        public override int GetHashCode()
        {
            return unitValue * number;
        }
        public override string ToString()
        {
            return $"{ name}，购入数量：{ number}，商品单价：{ unitValue}，此类商品总价：{ number* unitValue}";
        }
    }

    class OrderService
    {
        //<summery>
        //订单列表
        //</summery>
        public static List<Order> list = new List<Order>();
        
        //<summery>
        //增加订单
        //</summery>
        public static void Add(List<OrderDetail> list,String customer)
        {
            StringBuilder buffer = new StringBuilder();
            //以时间作为ID
            buffer.Append(Convert.ToString(DateTime.Now.Year)).Append(Convert.ToString(DateTime.Now.Month)).Append(Convert.ToString(DateTime.Now.Day))
                .Append(Convert.ToString(DateTime.Now.Hour)).Append(Convert.ToString(DateTime.Now.Minute)).Append(Convert.ToString(DateTime.Now.Second));
            Order newOrder = new Order(list, buffer.ToString(), customer);
            if (!OrderService.list.Exists(item=>item.Equals(newOrder)))
                OrderService.list.Add(newOrder);
            else
                throw new ArgumentException("订单已存在，不能重复添加");
        }

        //<summery>
        //删除订单
        //</summery>
        public static void Delete(infoStruct info)
        {
            List<Order> toDelete= Query(info).ToList();
            if (toDelete.Count() != 0)
                foreach (Order order in toDelete)
                    OrderService.list.Remove(order);
            else
                throw new ArgumentException("无此订单，无法删除");
        }

        //<summery>
        //修改订单
        //</summery>
        public static void Change(infoStruct toBeChanged,infoStruct changeTo)
        {
            List<Order> toChange = Query(toBeChanged).ToList();
            if (toChange.Count() == 0)
            {
                throw new ArgumentException("无此订单，无法修改");
            } 
            List<int> changeIndex = new List<int>();
            
            //<summery>
            //找到数组下标
            //</summery>
            foreach (Order current in toChange)
            {
                int tmpIndex = OrderService.list.FindIndex(item => item.Equals(current));
                if (tmpIndex != -1)
                    changeIndex.Add(tmpIndex);
            }
            foreach(int index in changeIndex)
            {
                //ID无法更改，是唯一标识
                //更改购买顾客
                if (changeTo.customer != null)
                    OrderService.list[index].customer = changeTo.customer;
                //更改详细订单信息，并更新属性sum
                if(toBeChanged.name!=null)
                {
                    int goodIndex = OrderService.list[index].list.FindIndex(goods => goods.name == toBeChanged.name);
                    if(changeTo.name!=null)
                        OrderService.list[index].list[goodIndex].name = changeTo.name;
                    if (changeTo.number != -1)
                        OrderService.list[index].list[goodIndex].number = changeTo.number;
                    if (changeTo.unitValue != -1)
                        OrderService.list[index].list[goodIndex].unitValue = changeTo.unitValue;
                    int newSum = 0;
                    OrderService.list[index].list.ForEach(item => newSum += item.unitValue * item.number);
                    OrderService.list[index].sum = newSum;
                }
            }
        }

        //<summery>
        //查询订单
        //</summery>
        public static IEnumerable<Order> Query(infoStruct info)
        {
            if (info.ID != null)
                return  list.Where(s => s.OrderID == info.ID);
            IEnumerable<Order> resualt = list;
            if (info.name != null)
            resualt = resualt.Where(s => s.list.Where(x=>x.name==info.name).Count()!=0);
            if (info.unitValue != -1)
                resualt = resualt.Where(s => s.list.Where(x => x.unitValue == info.unitValue).Count() != 0);
            if (info.number != -1)
                resualt = resualt.Where(s => s.list.Where(x => x.number == info.number).Count() != 0);
            if (info.customer != null)
                resualt = resualt.Where(s => s.customer == info.customer);
            if (info.sum != -1)
                resualt = resualt.Where(s => s.sum == info.sum);
            return resualt.OrderByDescending(s=>s.sum);
        }

        public static void sort()
        {
            OrderService.list.Sort();
        }
    }
    //查询结构体
    class infoStruct
    {
        public String ID { get; set; }
        public String name { get; set; }
        public int unitValue { get; set; }
        public int number { get; set; }
        public String customer { get; set; }
        public int sum { get; set; }

        //<summery>
        //生成查询语句
        //</summery>
        public infoStruct(String ID=null,String name=null,int unitValue =-1,int number=-1, String customer=null,int sum=-1)
        {
            this.ID = ID;
            this.name = name;
            this.unitValue = unitValue;
            this.number = number;
            this.customer = customer;
            this.sum = sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<OrderDetail> list1=new List<OrderDetail>();
            OrderDetail detail1 = new OrderDetail("胡萝卜", 2, 10);
            OrderDetail detail2 = new OrderDetail("骨头", 5, 10);
            OrderDetail detail3 = new OrderDetail("牛奶", 3, 10);
            list1.Add(detail1);list1.Add(detail2);list1.Add(detail3);
            List<OrderDetail> list2 = new List<OrderDetail>();
            OrderDetail detail4 = new OrderDetail("胡萝卜", 2, 5);
            OrderDetail detail5 = new OrderDetail("小鱼", 3, 20);
            OrderDetail detail6 = new OrderDetail("大鱼", 5, 20);
            list2.Add(detail4);list2.Add(detail5);list2.Add(detail6);
            List<OrderDetail> list3 = new List<OrderDetail>();
            OrderDetail detail7 = new OrderDetail("水草", 1, 6);
            OrderDetail detail8 = new OrderDetail("小鱼", 3, 7);
            list3.Add(detail7); list3.Add(detail8);
            try
            {
                OrderService.Add(list3, "鸭嘴兽");
                OrderService.Add(list1, "柯基");
                OrderService.Add(list2, "大老鼠");
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("==========================================Query================================================");
            infoStruct info4 = new infoStruct(null,null, -1, -1, null, -1);
            List<Order> resualt1 = OrderService.Query(info4).ToList();
            foreach (Order order in resualt1)
                Console.WriteLine(order);
            infoStruct info1 = new infoStruct(null,"鱼",-1,-1,null,-1);
            Console.WriteLine("==========================================Delete===============================================");
            try
            {
                OrderService.Delete(info1);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            resualt1 = OrderService.Query(info4).ToList();
            foreach (Order order in OrderService.list)
                Console.WriteLine(order);
            Console.WriteLine("==========================================Change===============================================");
            infoStruct info2 = new infoStruct(null, null, 20, 3, null, -1);
            infoStruct info3 = new infoStruct(null, "骨头", -1, -1, null, -1);
            OrderService.Change(info3,info2);
            resualt1 = OrderService.Query(info4).ToList();
            foreach (Order order in OrderService.list)
                Console.WriteLine(order);
            Console.WriteLine("==========================================Sort==================================================");
            OrderService.sort();
            foreach (Order order in OrderService.list)
                Console.WriteLine(order);
        }
    }
}
