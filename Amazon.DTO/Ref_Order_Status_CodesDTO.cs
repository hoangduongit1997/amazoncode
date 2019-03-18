using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
    public partial class Ref_Order_Status_CodesDTO
    {
        //public Ref_Order_Status_CodesDTO()
        //{
        //    Orders = new HashSet<OrderDTO>();
        //}

        public int order_status_code { get; set; }

        public string order_status_decription { get; set; }

        //public virtual ICollection<OrderDTO> Orders { get; set; }
    }
}
