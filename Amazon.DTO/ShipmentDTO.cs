using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
    public partial class ShipmentDTO
    {
        //public ShipmentDTO()
        //{
        //    Order_items = new HashSet<Order_itemsDTO>();
        //}

        public string shipment_id { get; set; }

        public string order_id { get; set; }

        public string invoice_number { get; set; }

        public DateTime? shipment_date { get; set; }

        public int? shipment_tracking_number { get; set; }

        //public virtual InvoiceDTO Invoice { get; set; }

        //public virtual OrderDTO Order { get; set; }

        //public virtual ICollection<Order_itemsDTO> Order_items { get; set; }
    }
}
