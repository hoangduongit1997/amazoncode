using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AmazonWebAPI.Models;
using Amazon.DTO;
using Amazon.BUS;
namespace AmazonWebAPI.Services
{
    public class CustomerRepository
    {
        CustomerBUS bus = null;

        public CustomerBUS Bus { get => bus; set => bus = value; }
        public CustomerRepository()
        {
            Bus = new CustomerBUS();
        }
       
        public int Insert(CustomerDTO cus)
        {
            return bus.insert(cus);
        }
            
    }
}