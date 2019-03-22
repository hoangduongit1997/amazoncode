using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
    public partial class Order_itemsDTO
    {
        //public Order_itemsDTO()
        //{
        //    Shipments = new HashSet<ShipmentDTO>();
        //}

        public string order_item_id { get; set; }

        public string order_id { get; set; }

        public string product_id { get; set; }

        public int? order_item_status_code { get; set; }

        public int? order_item_quantity { get; set; }

        public float? order_item_price { get; set; }

        //public virtual OrderDTO Order { get; set; }

        //public virtual Ref_Order_Item_Status_CodesDTO Ref_Order_Item_Status_Codes { get; set; }

        //public virtual ICollection<ShipmentDTO> Shipments { get; set; }
    }
}
