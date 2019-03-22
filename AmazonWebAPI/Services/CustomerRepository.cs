using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AmazonWebAPI.Models;
using Amazon.BUS;
using Amazon.DTO;

namespace AmazonWebAPI.Services
{
    public class CustomerRepository
    {
        //SHOPEntities Db = new SHOPEntities();
        //public int Login(string username, string password)
        //{
        //    var result = Db.Customers.SingleOrDefault(t => t.login_name == username);
        //    if (result == null)
        //        return -1;
        //    else
        //    {
        //        if (result.login_password == password)
        //            return 1;
        //        else return 0;
        //    }
        //}
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