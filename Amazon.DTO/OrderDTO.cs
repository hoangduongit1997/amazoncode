using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
  public  class OrderDTO
    {
        [StringLength(10)]
        public string order_id { get; set; }

        [StringLength(10)]
        public string customer_id { get; set; }

       
        public DateTime? date_order { get; set; }

        [StringLength(100)]
        public string order_place { get; set; }

        [StringLength(100)]
        public string order_note { get; set; }

       
        public decimal? total_price { get; set; }

        public int? order_status_code { get; set; }        
    }
}
