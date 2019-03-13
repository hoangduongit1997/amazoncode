using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DAL;
using Amazon.EntityFramework;

namespace Amazon.BUS
{
   public class MenuBUS
    {
        MenuDAL menu = null;
        public MenuBUS()
        {
            Menu = new MenuDAL();
        }

        public MenuDAL Menu { get => menu; set => menu = value; }

        public List<Menu> ListMenu()
        {
            return Menu.ListMenu().ToList();
        }

    }
}
