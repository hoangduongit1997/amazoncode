using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
   public class EmployeesDTO
    {
        public string employee_id { get; set; }

        
        public string employee_password { get; set; }

        public bool? employee_status { get; set; }

       
        public string employee_name { get; set; }

       
        public string email_address { get; set; }

       
        public string phone_number { get; set; }
    }
}
