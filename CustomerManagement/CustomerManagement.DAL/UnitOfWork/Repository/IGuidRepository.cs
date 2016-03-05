using CustomerManagement.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.UnitOfWork.Repository
{
    public interface IGuidRepository<T> : IBaseRepository<T, Guid>
        where T : class, IIdentifiable<Guid>
    {
    }
}
