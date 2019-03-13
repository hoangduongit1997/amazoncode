using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DAL;

namespace Amazon.BUS
{
    public class EmployeeBUS
    {
        EmployeeDAL da = new EmployeeDAL();
        public int Login(string employeeName, string password)
        {
            return da.Login(employeeName, password);
        }
    }
}
