using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
    public partial class Ref_Product_TypesDTO
    {
        //public Ref_Product_TypesDTO()
        //{
        //    Products = new HashSet<ProductDTO>();
        //}
        public string product_type_code { get; set; }
        public string product_type_description { get; set; }

        //public virtual ICollection<ProductDTO> Products { get; set; }
    }
}
