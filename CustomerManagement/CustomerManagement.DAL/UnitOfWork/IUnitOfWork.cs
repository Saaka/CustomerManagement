using CustomerManagement.DAL.Models;
using CustomerManagement.DAL.UnitOfWork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Save all changes.
        /// </summary>
        /// <returns>Number of affected entities.</returns>
        int Commit();
        /// <summary>
        /// Asynchronusly save all changes.
        /// </summary>
        /// <returns>Number of affected entities.</returns>
        Task<int> CommitAsync();
        /// <summary>
        /// Repository containing customers.
        /// </summary>
        IGuidRepository<Customer> CustomerRepository { get; }
    }
}
