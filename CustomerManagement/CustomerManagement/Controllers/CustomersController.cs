using CustomerManagement.DAL.UnitOfWork;
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
        protected readonly IUnitOfWork unitOfWork;
        public CustomersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IHttpActionResult> GetCustomers()
        {
            unitOfWork.CustomerRepository.Add(new DAL.Models.Customer() {Name = "SAKA" });
            unitOfWork.Commit();
            return Ok(unitOfWork.CustomerRepository.GetAll());
        }
    }
}
