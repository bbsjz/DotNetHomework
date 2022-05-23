using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework5;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;

namespace unitTest
{
    [TestClass]
    public class OrderServiceTest
    {
        //产生所需要的数据
        void generateData(out Order[] orderList,out Customer[] customersList)
        {
            {
                Goods[] goodsList = { new Goods("牛奶", 1, 2.5), new Goods("芒果", 2, 3), new Goods("小鱼", 3, 5), new Goods("大鱼", 4, 15), new Goods("薯条", 5, 7) };
                Customer[] customerList = { new Customer(1, "柯基"), new Customer(2, "鸭嘴兽"), new Customer(3, "柴犬"), new Customer(4, "萨摩耶"), new Customer(5, "大老鼠") };
                OrderDetail[] detailList = { new OrderDetail(goodsList[0], 5), new OrderDetail(goodsList[1], 3), new OrderDetail(goodsList[2], 10), new OrderDetail(goodsList[3], 2), new OrderDetail(goodsList[4], 5) };
                List<OrderDetail> list1 = new List<OrderDetail>();
                List<OrderDetail> list2 = new List<OrderDetail>();
                List<OrderDetail> list3 = new List<OrderDetail>();
                List<OrderDetail> list4 = new List<OrderDetail>();
                list1.Add(detailList[0]);
                list1.Add(detailList[1]);
                list1.Add(detailList[2]);
                list2.Add(detailList[3]);
                list2.Add(detailList[4]);
                list3.Add(detailList[1]);
                list3.Add(detailList[4]);
                list3.Add(detailList[0]);
                list3.Add(detailList[3]);
                list4.Add(detailList[1]);
                list4.Add(detailList[0]);
                list4.Add(detailList[2]);
                list4.Add(detailList[3]);
                Order[] generateOrder = { new Order(list1, 1, customerList[0]), new Order(list2, 2, customerList[1]), new Order(list3, 3, customerList[2]), new Order(list4, 4, customerList[0]) };
                orderList = generateOrder;
                customersList = customerList;
            }
        }

        //添加
        [TestMethod]
        public void AddTest1()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList,out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[0]);
            compareList.Add(orderList[1]);
            compareList.Add(orderList[2]);
            compareList.Add(orderList[3]);
            CollectionAssert.AreEqual(orderService.list, compareList);
        }

        //添加-空数据
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddTest2()
        {
            OrderService orderService = new OrderService();
            orderService.Add(null);
        }

        //添加-重复添加
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddTest3()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList,out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[1]);
        }

        //查询-按照ID
        [TestMethod]
        public void QueryTest1()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            List<Order> resualts = orderService.Query(new InfoStruct(1, null, -1, -1, null, -1)).ToList();
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[0]);
            CollectionAssert.AreEqual(resualts, compareList);
        }
        //查询-按照商品名
        [TestMethod]
        public void QueryTest2()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            var resualts = orderService.Query(new InfoStruct(-1,"牛奶", -1, -1, null, -1)).ToList();
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[3]);
            compareList.Add(orderList[2]);
            compareList.Add(orderList[0]);
            CollectionAssert.AreEqual(resualts, compareList);
        }

        //查询-按照商品的单价
        [TestMethod]
        public void QueryTest3()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            var resualts = orderService.Query(new InfoStruct(-1, null, 3, -1, null, -1)).ToList();
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[3]);
            compareList.Add(orderList[2]);
            compareList.Add(orderList[0]);
            CollectionAssert.AreEqual(resualts, compareList);
        }

        //查询-按照购买数量
        [TestMethod]
        public void QueryTest4()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            var resualts = orderService.Query(new InfoStruct(-1, null, -1, 2, null, -1)).ToList();
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[3]);
            compareList.Add(orderList[2]);
            compareList.Add(orderList[1]);
            CollectionAssert.AreEqual(resualts, compareList);
        }

        //查询-按照用户
        [TestMethod]
        public void QueryTest5()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            var resualts = orderService.Query(new InfoStruct(-1, null, -1, -1, customersList[0], -1)).ToList();
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[3]);
            compareList.Add(orderList[0]);
            CollectionAssert.AreEqual(resualts, compareList);
        }

        //查询-按照总价格
        [TestMethod]
        public void QueryTest6()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            var resualts = orderService.Query(new InfoStruct(-1, null, -1, -1, null, 65)).ToList();
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[1]);
            CollectionAssert.AreEqual(resualts, compareList);
        }

        //查询-按照客户和商品名
        [TestMethod]
        public void QueryTest7()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            var resualts = orderService.Query(new InfoStruct(-1, "大鱼", -1, -1, customersList[0], -1)).ToList();
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[3]);
            CollectionAssert.AreEqual(resualts, compareList);
        }

        //删除所有柯基的订单
        [TestMethod]
        public void DeleteTest1()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList,out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            var toDelete = orderService.Query(new InfoStruct(-1, null, -1, -1, customersList[0], -1));
            foreach(Order order in toDelete)
            {
                orderService.Delete(order);
            }
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[1]);
            compareList.Add(orderList[2]);
            CollectionAssert.AreEqual(orderService.list, compareList);
        }

        //删除-空订单
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteTest2()
        {
            OrderService orderService = new OrderService();
            orderService.Delete(null);
        }

        //删除-不存在的订单
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteTest3()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Delete(orderList[0]);
        }

        //更新
        [TestMethod]
        public void ChangeTest1()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            Order changeOrder = new Order(new List<OrderDetail> {new OrderDetail(new Goods("芝士",6,10),10)}, 1, customersList[1]);
            orderService.Change(changeOrder);
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[1]);
            compareList.Add(orderList[2]);
            compareList.Add(orderList[3]);
            compareList.Add(changeOrder);
            CollectionAssert.AreEqual(orderService.list, compareList);
        }

        //更新-空订单
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeTest2()
        {
            OrderService orderService = new OrderService();
            orderService.Change(null);
        }

        //更新-不存在的订单
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeTest3()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            orderService.Delete(orderList[0]);
        }

        //排序
        [TestMethod]
        public void SortTest()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Add(orderList[3]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[0]);
            orderService.sort();
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[0]);
            compareList.Add(orderList[1]);
            compareList.Add(orderList[2]);
            compareList.Add(orderList[3]);
            CollectionAssert.AreEqual(orderService.list, compareList);
        }

        //导出xml
        [TestMethod]
        public void ExportTest()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            orderService.Export("o");
            bool exsit = File.Exists("o.xml");
            Assert.AreEqual(exsit, true);
        }

        //导入xml
        [TestMethod]
        public void ImportTest()
        {
            OrderService orderService = new OrderService();
            orderService.Import("order");
            generateData(out Order[] orderList, out Customer[] customersList);
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[0]);
            compareList.Add(orderList[1]);
            compareList.Add(orderList[2]);
            compareList.Add(orderList[3]);
            CollectionAssert.AreEqual(orderService.list, compareList);
        }
    }
}
