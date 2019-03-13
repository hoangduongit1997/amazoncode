namespace Amazon.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [Key]
        [StringLength(10)]
        public string product_id { get; set; }

        [StringLength(10)]
        public string product_type_code { get; set; }

        public string product_name { get; set; }

        public float? product_price { get; set; }

        public string product_description { get; set; }

        public string product_size { get; set; }

        public string product_color { get; set; }

        public string product_imge { get; set; }

        [Column(TypeName = "xml")]
        public string more_image { get; set; }

        public DateTime? createddate { get; set; }

        public float? promotionprice { get; set; }

        public virtual Ref_Product_Types Ref_Product_Types { get; set; }
    }
}
