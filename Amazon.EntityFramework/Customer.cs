namespace Amazon.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [StringLength(10)]
        public string customer_id { get; set; }

        [StringLength(100)]
        public string customer_name { get; set; }

        [StringLength(100)]
        public string email_address { get; set; }

        [StringLength(10)]
        public string phone_number { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [StringLength(100)]
        public string login_name { get; set; }

        [StringLength(10)]
        public string login_password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
