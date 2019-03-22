using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
   public class SlideDTO
    {
        public SlideDTO(int iD, string image, int? displayOrder, string link, string description, DateTime? createdDate, string createdBy, DateTime? modifiedDate, string modifiedBy, bool? status, string priority)
        {
            ID = iD;
            Image = image;
            DisplayOrder = displayOrder;
            Link = link;
            Description = description;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
            Status = status;
            Priority = priority;
        }

        public int ID { get; set; }      
        public string Image { get; set; }
        public int? DisplayOrder { get; set; }    
        public string Link { get; set; }       
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }      
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }       
        public string ModifiedBy { get; set; }
        public bool? Status { get; set; }      
        public string Priority { get; set; }
       
    }
}
