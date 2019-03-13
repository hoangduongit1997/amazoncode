namespace Amazon.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment
    {
        [Key]
        [StringLength(10)]
        public string payment_id { get; set; }

        [StringLength(10)]
        public string invoice_number { get; set; }

        [Column(TypeName = "date")]
        public DateTime? payment_date { get; set; }

        public float? payment_amount { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
