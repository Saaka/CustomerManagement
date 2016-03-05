using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.DAL.Models;
using CustomerManagement.DAL.UnitOfWork.Repository;
using System.Data.Entity;

namespace CustomerManagement.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext context;

        private IGuidRepository<Customer> customerRepository;

        public UnitOfWork()
        {
            context = CreateContext();
        }

        protected virtual DbContext CreateContext()
        {
            return new CustomerManagerContext();
        }

        public IGuidRepository<Customer> CustomerRepository
        {
            get
            {
                if(customerRepository == null)
                {
                    customerRepository = new GuidRepository<Customer>(context);
                }
                return customerRepository;
            }
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
