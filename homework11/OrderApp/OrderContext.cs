using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class OrdingDBContext : DbContext
    {
        public OrdingDBContext()
            : base("name=default")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrdingDBContext>());
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
    }
}