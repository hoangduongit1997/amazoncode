using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
    public partial class CustomerDTO
    {
        //public CustomerDTO()
        //{
        //    Orders = new HashSet<OrderDTO>();
        //}
        public string customer_id { get; set; }
        public string customer_name { get; set; }
        public string email_address { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public string login_name { get; set; }
        public string login_password { get; set; }

        //public virtual ICollection<OrderDTO> Orders { get; set; }
    }
}
