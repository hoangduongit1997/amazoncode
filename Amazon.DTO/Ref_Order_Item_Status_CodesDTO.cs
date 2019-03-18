using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
    public partial class Ref_Order_Item_Status_CodesDTO
    {
        //public Ref_Order_Item_Status_CodesDTO()
        //{
        //    Order_items = new HashSet<Order_itemsDTO>();
        //}

        public int order_item_status_code { get; set; }

        public string order_item_status_description { get; set; }

        //public virtual ICollection<Order_itemsDTO> Order_items { get; set; }
    }
}
