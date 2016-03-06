using CustomerManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Business.Customer
{
    public interface ICustomerManager
    {
        Task<IEnumerable<CustomerModel>> LoadCustomersAsync();
    }
}