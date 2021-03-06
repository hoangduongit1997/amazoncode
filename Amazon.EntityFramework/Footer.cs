namespace Amazon.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Footer")]
    public partial class Footer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FooterID { get; set; }

        [StringLength(50)]
        public string Contain { get; set; }

        public bool? Status { get; set; }

        public int? FooterIDType { get; set; }

        public int? FooterParentID { get; set; }

        public string Link { get; set; }

        [StringLength(50)]
        public string Target { get; set; }
    }
}
