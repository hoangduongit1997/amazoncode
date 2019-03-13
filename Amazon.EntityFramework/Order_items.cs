namespace Amazon.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_items
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order_items()
        {
            Shipments = new HashSet<Shipment>();
        }

        [Key]
        [StringLength(10)]
        public string order_item_id { get; set; }

        [StringLength(10)]
        public string order_id { get; set; }

        [StringLength(10)]
        public string product_id { get; set; }

        public int? order_item_status_code { get; set; }

        public int? order_item_quantity { get; set; }

        public float? order_item_price { get; set; }

        public virtual Order Order { get; set; }

        public virtual Ref_Order_Item_Status_Codes Ref_Order_Item_Status_Codes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
