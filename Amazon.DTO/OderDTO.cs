using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Amazon.DTO
{
   public class OderDTO
    {
        public string order_id { get; set; }

      
        public string customer_id { get; set; }

       
        public DateTime? date_order { get; set; }

        
        public string order_place { get; set; }

      
        public string order_note { get; set; }

       
        public decimal? total_price { get; set; }

        public int? order_status_code { get; set; }

     
    }
}
