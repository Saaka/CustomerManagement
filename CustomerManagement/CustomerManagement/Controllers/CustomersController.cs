using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CustomerManagement.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {

        public async Task<IHttpActionResult> GetCustomers()
        {

            return Ok();
        }
    }
}
