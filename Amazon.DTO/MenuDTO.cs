using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
   public class MenuDTO
    {
        //private int? displayOrder;
        //private bool? status;
        //private int? menuTypeID;
        //private int? menuParentID;

        public int MenuID { get; set; }        
        public string Text { get; set; }
        public string Link { get; set; }
        public int? DisplayOrder { get; set; }       
        public string Target { get; set; }
        public bool? Status { get; set; }
        public int? MenuTypeID { get; set; }
        public int? MenuParentID { get; set; }
        public string Icon { get; set; }
        public string Properti { get; set; }

        public MenuDTO(int menuID, string text, string link, int? displayOrder, string target, bool? status, int? menuTypeID, int? menuParentID, string icon, string properti)
        {
            MenuID = menuID;
            Text = text;
            Link = link;
            this.DisplayOrder = displayOrder;
            Target = target;
            this.Status = status;
            this.MenuTypeID = menuTypeID;
            this.MenuParentID = menuParentID;
            Icon = icon;
            Properti = properti;
        }
    }
}
