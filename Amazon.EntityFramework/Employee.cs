namespace Amazon.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [Key]
        [StringLength(10)]
        public string employee_id { get; set; }

        [StringLength(10)]
        public string employee_password { get; set; }

        public bool? employee_status { get; set; }

        [StringLength(50)]
        public string employee_name { get; set; }

        [StringLength(50)]
        public string email_address { get; set; }

        [StringLength(10)]
        public string phone_number { get; set; }
    }
}
