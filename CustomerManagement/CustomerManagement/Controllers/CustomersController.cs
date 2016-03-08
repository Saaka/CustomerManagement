using CustomerManagement.Business.Customer;
using CustomerManagement.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CustomerManagement.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        protected readonly ICustomerManager customerManager;
        public CustomersController(ICustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCustomers()
        {
            var customerList = await customerManager.LoadCustomersAsync();
            return Ok(customerList);
        }

        [HttpPost]
        public async Task<IHttpActionResult> SaveCustomer(CustomerModel customer)
        {
            var customerModel = await customerManager.SaveCustomerAsync(customer);

            return Ok(customerModel);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> DeleteCustomer(Guid id)
        {
            await customerManager.DeleteCustomerAsync(id);

            return Ok();
        }
    }
}
