using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
   public class FooterDTO
    {
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
