using CustomerManagement.DAL.UnitOfWork;
using CustomerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CustomerManagement.Business.Customer
{
    public class CustomerManager : ICustomerManager
    {
        protected readonly IUnitOfWork unitOfWork;

        public CustomerManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomerModel>> LoadCustomersAsync()
        {
            var vrlList = await unitOfWork.CustomerRepository.GetAllAsync();

            return Enumerable.Empty<CustomerModel>();
        }
    }
}