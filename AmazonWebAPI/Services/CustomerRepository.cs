using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AmazonWebAPI.Models;
namespace AmazonWebAPI.Services
{
    public class CustomerRepository
    {
        SHOPEntities Db = new SHOPEntities();
        public int Login(string username, string password)
        {
            var result = Db.Customers.SingleOrDefault(t => t.login_name == username);
            if (result == null)
                return -1;
            else
            {
                if (result.login_password == password)
                    return 1;
                else return 0;
            }
        }
    }
}