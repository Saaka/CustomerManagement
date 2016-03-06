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
        private bool isDisposed;

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
                    customerRepository = new GuidRepository<Customer>(context);
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if(!isDisposed)
            {
                if(disposing)
                {
                    if (context != null)
                        context.Dispose();
                }
                isDisposed = true;
            }
        }
    }
}
