using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    public class Customer
    {
        public int ID { get; set; }
        public String name { get; set; }

        public Customer() { }
        public Customer(int ID,String name)
        {
            this.ID = ID;
            this.name = name;
        }

        public override string ToString()
        {
            return $"用户ID{ID}，用户名{name}";
        }
        public override bool Equals(object obj)
        {
            var customer=obj as Customer;
            return customer != null && customer.ID == ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
