using CustomerManagement.DAL.Interface;
using CustomerManagement.DAL.UnitOfWork.Utils;
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
        protected readonly IEntitySavedValidator entitySavedValidator;

        public GuidRepository(DbContext context, IEntitySavedValidator entitySavedValidator)
        {
            this.context = context;
            this.entitySavedValidator = entitySavedValidator;
            objectSet = ((IObjectContextAdapter)this.context).ObjectContext.CreateObjectSet<T>();
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Added entity object can't be null");

            if (!entitySavedValidator.IsEntitySaved(entity))
                objectSet.AddObject(entity);
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

            if (!entitySavedValidator.IsEntitySaved(entity))
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

        public IEnumerable<T> Find(Expression<Func<T, bool>> query)
        {
            return objectSet.Where(query).ToList();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> query)
        {
            return await objectSet.Where(query).ToListAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return objectSet.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await objectSet.ToListAsync();
        }

        public T GetById(Guid id)
        {
            return Find(x => x.Id == id).SingleOrDefault();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await objectSet.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
