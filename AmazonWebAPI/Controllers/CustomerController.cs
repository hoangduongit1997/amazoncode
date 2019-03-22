using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AmazonWebAPI.Services;
using Amazon.DTO;
namespace AmazonWebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        CustomerRepository customerRepository = null;
       public CustomerController()
        {
            customerRepository = new CustomerRepository();
        }
        [HttpPost]
        [Route( "api/customer")]
        public int Insert(CustomerDTO cusEntity)
        {
            return customerRepository.Insert(cusEntity);
        }
    }
}
