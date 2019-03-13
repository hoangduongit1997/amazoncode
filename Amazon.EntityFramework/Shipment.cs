namespace Amazon.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipment()
        {
            Order_items = new HashSet<Order_items>();
        }

        [Key]
        [StringLength(10)]
        public string shipment_id { get; set; }

        [StringLength(10)]
        public string order_id { get; set; }

        [StringLength(10)]
        public string invoice_number { get; set; }

        [Column(TypeName = "date")]
        public DateTime? shipment_date { get; set; }

        public int? shipment_tracking_number { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual Order Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_items> Order_items { get; set; }
    }
}
