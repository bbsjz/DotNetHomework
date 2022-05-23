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
        //��������Ҫ������
        void generateData(out Order[] orderList,out Customer[] customersList)
        {
            {
                Goods[] goodsList = { new Goods("ţ��", 1, 2.5), new Goods("â��", 2, 3), new Goods("С��", 3, 5), new Goods("����", 4, 15), new Goods("����", 5, 7) };
                Customer[] customerList = { new Customer(1, "�»�"), new Customer(2, "Ѽ����"), new Customer(3, "��Ȯ"), new Customer(4, "��ĦҮ"), new Customer(5, "������") };
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

        //���
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

        //���-������
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddTest2()
        {
            OrderService orderService = new OrderService();
            orderService.Add(null);
        }

        //���-�ظ����
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

        //��ѯ-����ID
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
        //��ѯ-������Ʒ��
        [TestMethod]
        public void QueryTest2()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            var resualts = orderService.Query(new InfoStruct(-1,"ţ��", -1, -1, null, -1)).ToList();
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[3]);
            compareList.Add(orderList[2]);
            compareList.Add(orderList[0]);
            CollectionAssert.AreEqual(resualts, compareList);
        }

        //��ѯ-������Ʒ�ĵ���
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

        //��ѯ-���չ�������
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

        //��ѯ-�����û�
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

        //��ѯ-�����ܼ۸�
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

        //��ѯ-���տͻ�����Ʒ��
        [TestMethod]
        public void QueryTest7()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            var resualts = orderService.Query(new InfoStruct(-1, "����", -1, -1, customersList[0], -1)).ToList();
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[3]);
            CollectionAssert.AreEqual(resualts, compareList);
        }

        //ɾ�����п»��Ķ���
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

        //ɾ��-�ն���
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteTest2()
        {
            OrderService orderService = new OrderService();
            orderService.Delete(null);
        }

        //ɾ��-�����ڵĶ���
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteTest3()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Delete(orderList[0]);
        }

        //����
        [TestMethod]
        public void ChangeTest1()
        {
            OrderService orderService = new OrderService();
            generateData(out Order[] orderList, out Customer[] customersList);
            orderService.Add(orderList[0]);
            orderService.Add(orderList[1]);
            orderService.Add(orderList[2]);
            orderService.Add(orderList[3]);
            Order changeOrder = new Order(new List<OrderDetail> {new OrderDetail(new Goods("֥ʿ",6,10),10)}, 1, customersList[1]);
            orderService.Change(changeOrder);
            List<Order> compareList = new List<Order>();
            compareList.Add(orderList[1]);
            compareList.Add(orderList[2]);
            compareList.Add(orderList[3]);
            compareList.Add(changeOrder);
            CollectionAssert.AreEqual(orderService.list, compareList);
        }

        //����-�ն���
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeTest2()
        {
            OrderService orderService = new OrderService();
            orderService.Change(null);
        }

        //����-�����ڵĶ���
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

        //����
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

        //����xml
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

        //����xml
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
