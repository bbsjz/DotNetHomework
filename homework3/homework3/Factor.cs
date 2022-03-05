using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using problem1;

namespace problem1
{
    class Factor
    {
        //制作工厂，其中num是选择码，[begin,end)是随机生成边的范围
        public static Shape produce(int num,int begin,int end)
        {
            Random rd = new Random();
            double rd1 = rd.Next(begin, end);
            double rd2 = rd.Next(begin, end);
            double rd3 = rd.Next(begin, end);
            switch (num)
            {
                case 0://生成长方形             
                    return new Rectangle(rd1, rd2);
                case 1://生成正方形
                    return new Squre(rd3);
                case 2://生成三角形
                    return new Triangle(rd1, rd2, rd3);
                case 3://生成圆形
                    return new Round(rd1);
                default:
                    throw new Exception("没有此形状");
            }
        }
    }

    class SimpleFactor
    {
        //num为要生成的随机形状个数
        public static void Main()
        {
            ArrayList list = new ArrayList();
            Random rd = new Random();
            //生产十次，并检查产品是否合格，若有残次品则丢弃
            for(int i=0;i<10;i++)
            {
                int r = rd.Next(0, 4);
                Shape newRandomShape = Factor.produce(r, 0, 100);
                if(newRandomShape.ifReasonable())
                {
                    list.Add(newRandomShape);
                }
            }
            Console.WriteLine(Adder.sumArea(list));
        }
    }

    class Adder
    {
        public static double sumArea(ArrayList list)
        {
            double sum = 0;
            foreach(Object obj in list)
            {
                sum +=((Shape)obj).getArea();
            }
            return sum;
        }
    }
}
