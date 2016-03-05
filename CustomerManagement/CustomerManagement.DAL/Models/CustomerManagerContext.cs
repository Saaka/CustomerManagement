using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.Models
{
    public class CustomerManagerContext : DbContext
    {
        public CustomerManagerContext() : 
            base("CustomerDBContext")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 10;
        }
        
        public DbSet<Customer> Customers { get; set; }
    }
}
