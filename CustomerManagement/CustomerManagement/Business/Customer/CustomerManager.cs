using AutoMapper;
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
        protected readonly IMapper mapper;

        public CustomerManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CustomerModel>> LoadCustomersAsync()
        {
            var list = await unitOfWork.CustomerRepository.GetAllAsync();

            return mapper.Map<IEnumerable<CustomerModel>>(list);
        }
    }
}