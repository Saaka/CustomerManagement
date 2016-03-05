using CustomerManagement.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.UnitOfWork.Repository
{
    public class GuidRepository<T> : IGuidRepository<T>
        where T : class, IIdentifiable<Guid>
    {
        protected readonly DbContext context;
        protected readonly ObjectSet<T> objectSet;

        public GuidRepository(DbContext context)
        {
            this.context = context;
            objectSet = ((IObjectContextAdapter)this.context).ObjectContext.CreateObjectSet<T>();
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Added entity object can't be null");

            if (!IsEntitySaved(entity))
                objectSet.AddObject(entity);
        }

        private bool IsEntitySaved(T entity)
        {
            return entity.Id != Guid.Empty && GetById(entity.Id) == null;
        }

        public T Create()
        {
            T entity = objectSet.CreateObject();
            objectSet.AddObject(entity);

            return entity;
        }

        public void Delete(T entity)
        {
            if(entity == null)
                return;

            if (!IsEntitySaved(entity))
            {
                var entry = context.Entry(entity);
                if (entry != null)
                    entry.State = EntityState.Detached;

            }
            else
            {
                objectSet.DeleteObject(entity);
            }
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> query)
        {
            return objectSet.Where(query);
        }

        public IQueryable<T> GetAll()
        {
            return objectSet;
        }

        public T GetById(Guid id)
        {
            return Find(x => x.Id == id).SingleOrDefault();
        }
    }
}
