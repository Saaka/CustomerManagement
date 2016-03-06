using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.UnitOfWork.Repository
{
    /// <summary>
    /// Repository containing collection of elements.
    /// </summary>
    /// <typeparam name="T">Type of entity.</typeparam>
    /// <typeparam name="U">Identifier type</typeparam>
    public interface IBaseRepository<T, U> 
        where T : class
        where U : struct
    {
        /// <summary>
        /// Gets all rows from repository.
        /// </summary>
        /// <returns>Returns all rows from repository.</returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Gets all rows from repository asynchronusly.
        /// </summary>
        /// <returns>Returns all rows from repository.</returns>
        Task<IEnumerable<T>> GetAllAsync();
        /// <summary>
        /// Finds all rows for given query.
        /// </summary>
        /// <param name="query">Expression with query.</param>
        /// <returns>Rows matching the query</returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> query);
        /// <summary>
        /// Finds all rows for given query asynchronusly.
        /// </summary>
        /// <param name="query">Expression with query.</param>
        /// <returns>Rows matching the query</returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> query);
        /// <summary>
        /// Adds entity to repository.
        /// </summary>
        /// <param name="entity">Repository to add.</param>
        void Add(T entity);
        /// <summary>
        /// Creates new entity and ads it to repository.
        /// </summary>
        /// <returns>Created entity.</returns>
        T Create();
        /// <summary>
        /// Deletes entity from repository.
        /// </summary>
        /// <param name="entity">Entity to delete.</param>
        void Delete(T entity);
        /// <summary>
        /// Gets entity based on id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Entity for given id. Null if entity does not exists.</returns>
        T GetById(U id);
        /// <summary>
        /// Gets entity based on id asynchronusly.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Entity for given id. Null if entity does not exists.</returns>
        Task<T> GetByIdAsync(U id);
    }
}
