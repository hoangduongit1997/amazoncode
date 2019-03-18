using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EntityFramework;
namespace Amazon.DAL
{
   public class MenuDAL
    {
        ShopDbContext db = null;
        public MenuDAL()
        {
            Db = new ShopDbContext();
        }
        public ShopDbContext Db { get => db; set => db = value; }

        public List<Menu> ListMenu()
        {
            var menu = db.Menus.Where(item => item.Status == true).ToList();

            return menu;
        }
        
    }
}
