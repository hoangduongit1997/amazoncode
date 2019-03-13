namespace Amazon.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Invoices = new HashSet<Invoice>();
            Order_items = new HashSet<Order_items>();
            Shipments = new HashSet<Shipment>();
        }

        [Key]
        [StringLength(10)]
        public string order_id { get; set; }

        [StringLength(10)]
        public string customer_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_order { get; set; }

        [StringLength(100)]
        public string order_place { get; set; }

        [StringLength(100)]
        public string order_note { get; set; }

        [Column(TypeName = "money")]
        public decimal? total_price { get; set; }

        public int? order_status_code { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_items> Order_items { get; set; }

        public virtual Ref_Order_Status_Codes Ref_Order_Status_Codes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
