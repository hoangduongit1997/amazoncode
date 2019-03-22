using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
   public class CustomerDTO
    {
        public string customer_id { get; set; }

        [StringLength(100)]
        public string customer_name { get; set; }

        [StringLength(50)]
        public string email_address { get; set; }

        [StringLength(10)]
        public string phone_number { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [StringLength(20)]
        public string login_name { get; set; }

        [StringLength(10)]
        public string login_password { get; set; }
    }
}
