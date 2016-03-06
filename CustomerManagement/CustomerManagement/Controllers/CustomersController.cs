using CustomerManagement.Business.Customer;
using System.Threading.Tasks;
using System.Web.Http;

namespace CustomerManagement.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        protected readonly CustomerManager customerManager;
        public CustomersController(CustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCustomers()
        {
            var customerList = await customerManager.LoadCustomersAsync();
            return Ok(customerList);
        }
    }
}
