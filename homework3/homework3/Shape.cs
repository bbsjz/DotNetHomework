using System;

namespace problem1
{
    abstract class Shape
    {
        public abstract double getArea();
        public abstract bool ifReasonable();
    }

    //方形
    class Rectangle : Shape
    {
        //属性
        public double length{ get; }
        public double width{ get; }
        
        //构造函数
        public Rectangle(double l,double w)
        {
            length = l;
            width = w;
        }
        
        //方法
        public override double getArea()
        {
            if (ifReasonable())
                return length * width;
            else
                throw new Exception("长宽小于或等于0，此方形不合法");
        }
        public override bool ifReasonable()
        {
            return length > 0 && width > 0;
        }
    }

    //正方形
    class Squre : Rectangle
    {
        //构造函数
        public Squre(double l) : base(l, l)
        {

        }
    }

    //三角形
    class Triangle : Shape
    {
        //属性
        public double side1 { get;  }
        public double side2 { get; }
        public double side3 { get; }
        
        //构造函数
        public Triangle(double l1,double l2,double l3)
        {
            side1 = l1;
            side2 = l2;
            side3 = l3;
        }
        
        //方法
        public override double getArea()
        {
            if (ifReasonable())
            {
                double p = (side1 + side2 + side3) / 2;
                return (Math.Pow(p * (p - side1) * (p - side2) * (p - side3), 0.5));
            }
            else
                throw new Exception("输入边长小于或等于0，或三边无法构成三角形，此三角形不合法");
            
        }

        public override bool ifReasonable()
        {
            return (side1 > 0 && side2 > 0 && side3 > 0)&&(side1+side2>side3)&&(side3+side1>side2)&&(side2+side3>side1);
        }
    }

    //圆形
    class Round : Shape
    {
        //属性
        public double r { get; }
        
        //构造函数
        public Round(double r)
        {
            this.r = r;
        }

        //方法
        public override double getArea()
        {
            if (ifReasonable())
                return Math.PI * r * r;
            else
                throw new Exception("半径小于或等于0，此圆形不合法");
        }

        public override bool ifReasonable()
        {
            return r > 0;
        }
    }
}
