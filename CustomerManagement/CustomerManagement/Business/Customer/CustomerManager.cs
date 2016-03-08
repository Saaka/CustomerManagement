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

        public async Task<CustomerModel> SaveCustomerAsync(CustomerModel customerModel)
        {
            DAL.Models.Customer customer = mapper.Map<DAL.Models.Customer>(customerModel);
            unitOfWork.Attach(customer);
            await unitOfWork.CommitAsync();
            return mapper.Map<CustomerModel>(customer);
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            DAL.Models.Customer customer = await unitOfWork.CustomerRepository.GetByIdAsync(id);
            unitOfWork.CustomerRepository.Delete(customer);
            await unitOfWork.CommitAsync();
            return;
        }
    }
}