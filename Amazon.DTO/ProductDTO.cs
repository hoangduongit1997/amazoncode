using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
    public class ProductDTO
    {
      
        public string product_id { get; set; }

       
        public string product_type_code { get; set; }

        public string product_name { get; set; }

        public float? product_price { get; set; }

        public string product_description { get; set; }

        public string product_size { get; set; }

        public string product_color { get; set; }

        public string product_imge { get; set; }

      
        public string more_image { get; set; }

        public DateTime? createddate { get; set; }

        public float? promotionprice { get; set; }

        //public List<Ref_Product_TypesDTO> Ref_Product_Types { get; set; }

        // public virtual Ref_Product_Types Ref_Product_Types { get; set; }
    }
}
