using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OrderApi.Models;

public class OrderDetail
{
    //商品
    public Goods goods { get; set; }
    //购入数量
    public int number { get; set; }

    public OrderDetail() { }
    public OrderDetail(Goods goods, int number)
    {
        this.goods=goods;
        this.number = number;
    }

    public override bool Equals(object obj)
    {
        var detail = obj as OrderDetail;
        return detail!=null && detail.goods== goods && this.number == detail.number;
    }
    public override int GetHashCode()
    {
        return goods.GetHashCode()+number;
    }
    public override string ToString()
    {
        return $"{goods}，购入数量：{ number}，此类商品总价：{ number * goods.unitValue}";
    }
}
