using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.DAL.Models;
using CustomerManagement.DAL.UnitOfWork.Repository;
using System.Data.Entity;
using CustomerManagement.DAL.UnitOfWork.Utils;

namespace CustomerManagement.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected bool isDisposed;
        protected readonly DbContext context;
        protected readonly IEntitySavedValidator entitySavedValidator;

        private IGuidRepository<Customer> customerRepository;

        public UnitOfWork(IEntitySavedValidator entitySavedValidator)
        {
            context = CreateContext();
            this.entitySavedValidator = entitySavedValidator;
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
                    customerRepository = new GuidRepository<Customer>(context, entitySavedValidator);
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

        public void Attach(object entity)
        {
            var entry = context.Entry(entity);
            if (entry == null)
                throw new ArgumentException("Invalid entity object");

            if (entitySavedValidator.IsEntitySaved(entity))
                entry.State = EntityState.Modified;
            else
                entry.State = EntityState.Added;
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
