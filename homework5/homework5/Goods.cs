using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    public class Goods
    {
        public String name{get;set;}
        public int ID { get; set; }
        public double unitValue { set; get; }
        public Goods() { }
        public Goods(String name,int ID,double unitValue)
        {
            this.name = name;
            this.ID = ID;
            this.unitValue = unitValue;
        }
        public override string ToString()
        {
            return $"商品ID：{ID} 商品名：{name} 商品单价{unitValue}";
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods!=null&&goods.unitValue==unitValue&&goods.name==name;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode()+unitValue.GetHashCode();
        }
    }
}
