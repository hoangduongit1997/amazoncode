using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Amazon.Areas.Admin.Models
{
    public class ProductTypeModel
    {
        //[Required(ErrorMessage = "Do not empty !")]
        public string product_type_code { get; set; }

        [Required(ErrorMessage = "Do not empty !")]
        public string description { get; set; }
    }
}