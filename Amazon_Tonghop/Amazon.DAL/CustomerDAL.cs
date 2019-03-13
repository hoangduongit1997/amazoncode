using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EntityFramework;
using PagedList;

namespace Amazon.DAL
{
  public class CustomerDAL
    {
        ShopDbContext db;
        public CustomerDAL() => Db = new ShopDbContext();

        public ShopDbContext Db { get => db; set => db = value; }

        public Customer Find(string id)
        {
            return Db.Customers.SingleOrDefault(t => t.login_name == id);

        }
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
        public bool checkEmail(string email)
        {
            if (email == null)
                return false;
            var result = Db.Customers.SingleOrDefault(t => t.email_address == email);
            return result == null;
        }
        public int insert(Customer cus)
        {
            if (checkEmail(cus.email_address))
            {
                var result = Db.Customers.Add(cus);

                if (result != null)
                {
                    Db.SaveChanges();
                    return 1;
                }

                return 0;
            }

            return -1;
        }

        public bool Update(Customer customer)
        {
            try
            {
                var cus = db.Customers.Find(customer.customer_id);
                cus.customer_name = customer.customer_name;
                cus.address = customer.address;
                cus.email_address = customer.email_address;
                cus.phone_number = customer.phone_number;
                cus.login_name = customer.login_name;
                cus.login_password = customer.login_password;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var cus = db.Customers.Find(id);
                db.Customers.Remove(cus);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Customer ViewDetail(string id)
        {
            return db.Customers.Find(id);
        }

        public IEnumerable<Customer> ListAllPaging(int page, int pageSize)
        {
            return db.Customers.OrderByDescending(x => x.customer_name).ToPagedList(page, pageSize);
        }
    }
}
