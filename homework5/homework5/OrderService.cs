using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace homework5
{
    [Serializable]
    public class OrderService
    {
        ///<summary>
        ///订单列表
        ///</summary>
        public List<Order> list { get; set; } = new List<Order>();

        public OrderService() { }

        ///<summary>
        ///增加订单
        ///</summary>
        public void Add(Order newOrder)
        {
            if (newOrder == null)
            {
                throw new ArgumentException("无效空订单");
            }
            if (list.Exists(item => item.Equals(newOrder)))
            {
                throw new ArgumentException("订单已存在，不能重复添加");
            }
            list.Add(newOrder);
        }

        ///<summary>
        ///删除订单
        ///</summary>
        public void Delete(Order delete)
        {
            if(delete==null)
            {
                throw new ArgumentException("无效空订单，删除失败");
            }
            if(!list.Contains(delete))
            {
                throw new ArgumentException("无此订单，删除失败");
            }
            list.Remove(delete);   
        }

        ///<summary>
        ///修改订单
        ///</summary>
        public void Change(Order change)
        {
            if(change==null)
            {
                throw new ArgumentException("无效空订单，更新失败");
            }
            IEnumerable<Order> changeList = Query(new InfoStruct(change.OrderID, null, -1, -1, null, -1));
            if (!changeList.Any())
            {
                throw new ArgumentException("无此订单，更新失败");
            }
            list.RemoveAll(o=>o.OrderID==change.OrderID);
            list.Add(change);
        }

        ///<summary>
        ///查询订单
        ///</summary>
        public IEnumerable<Order> Query(InfoStruct info)
        {
            if (info.ID != -1)
                return list.Where(s => s.OrderID == info.ID);
            IEnumerable<Order> resualt = list;
            if (info.name != null)
                resualt = resualt.Where(s => s.list.Where(x => x.goods.name == info.name).Count() != 0);
            if (info.unitValue != -1)
                resualt = resualt.Where(s => s.list.Where(x => x.goods.unitValue == info.unitValue).Count() != 0);
            if (info.number != -1)
                resualt = resualt.Where(s => s.list.Where(x => x.number == info.number).Count() != 0);
            if (info.customer != null)
                resualt = resualt.Where(s => s.customer == info.customer);
            if (info.sum != -1)
                resualt = resualt.Where(s => s.sum == info.sum);
            return resualt.OrderByDescending(s => s.sum);
        }

        public void sort()
        {
            list.Sort();
        }

        public void Export(String fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName+".xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, list);
            }
        }

        public void Import(String fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName+".xml", FileMode.Open))
            {
                list = (List<Order>)xmlSerializer.Deserialize(fs);
            }
        }
    }
}
