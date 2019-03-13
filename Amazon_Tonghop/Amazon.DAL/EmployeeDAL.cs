using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EntityFramework;

namespace Amazon.DAL
{
    public class EmployeeDAL
    {
        ShopDbContext db;
        public EmployeeDAL() => Db = new ShopDbContext();

        public ShopDbContext Db { get => db; set => db = value; }


        public int Login(string employeeName, string password)
        {
            var result = Db.Employees.SingleOrDefault(t => t.employee_name == employeeName);
            
            if (result == null)
                return -1;
            else
            {
                if (result.employee_password == password)
                    return 1;
                else return 0;
            }
        }
    }
}
