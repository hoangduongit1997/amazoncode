using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml;
namespace Amazon.Models
{
    public class Product
    {
        public string product_id;
        public string product_type_code;
        public string product_name;
        public float product_price;
        public string product_color;
        public string product_description;
        public string product_size;
        public string product_imge;
        public float promotionprice;
        public DateTime createddate;
        public string more_image;

    }
}
