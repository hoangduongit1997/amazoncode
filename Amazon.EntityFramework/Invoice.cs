namespace Amazon.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            Payments = new HashSet<Payment>();
            Shipments = new HashSet<Shipment>();
        }

        [Key]
        [StringLength(10)]
        public string invoice_number { get; set; }

        [StringLength(10)]
        public string order_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? invoice_date { get; set; }

        public int? invoice_status_code { get; set; }

        public float? invoice_total_money { get; set; }

        public virtual Order Order { get; set; }

        public virtual Ref_Invoice_Status_Codes Ref_Invoice_Status_Codes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
