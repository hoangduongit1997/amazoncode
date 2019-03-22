using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
    public partial class OrderDTO
    {
        //public OrderDTO()
        //{
        //    Invoices = new HashSet<InvoiceDTO>();
        //    Order_items = new HashSet<Order_itemsDTO>();
        //    Shipments = new HashSet<ShipmentDTO>();
        //}
        public string order_id { get; set; }
        public string customer_id { get; set; }
        public DateTime? date_order { get; set; }

        public string order_place { get; set; }

        public string order_note { get; set; }

        public decimal? total_price { get; set; }

        public int? order_status_code { get; set; }

        //public virtual CustomerDTO Customer { get; set; }

        //public virtual ICollection<InvoiceDTO> Invoices { get; set; }

        //public virtual ICollection<Order_itemsDTO> Order_items { get; set; }

        //public virtual Ref_Order_Status_CodesDTO Ref_Order_Status_Codes { get; set; }

        //public virtual ICollection<ShipmentDTO> Shipments { get; set; }
    }
}
