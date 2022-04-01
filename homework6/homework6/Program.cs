using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace homework5
{
    //查询结构体
    public struct InfoStruct
    {
        public int ID { get; set; }
        public String name { get; set; }
        public int unitValue { get; set; }
        public int number { get; set; }
        public Customer customer { get; set; }
        public int sum { get; set; }

        ///<summary>
        ///生成查询语句
        ///</summary>
        public InfoStruct(int ID=-1,String name=null,int unitValue =-1,int number=-1, Customer customer=null,int sum=-1)
        {
            this.ID = ID;
            this.name = name;
            this.unitValue = unitValue;
            this.number = number;
            this.customer = customer;
            this.sum = sum;
        }
    }
}
