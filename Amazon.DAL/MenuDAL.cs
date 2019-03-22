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
        //Tạo id tự động
        public int autoKey()
        {
            int key = 0;
            List<Menu> lst = Db.Menus.Select(t => t).ToList<Menu>();
            if (Db.Menus.Count() != 0)
            {
                Menu hv = lst[Db.Menus.Count() - 1];
                key = (hv.MenuID + 1);
            }
            return key;
        }
        //lấy menu
        public Menu ViewDetail(int id)
        {
            return Db.Menus.Find(id);
        }
        //Tạo menu
        public bool Insert(Menu menu)
        {
            Db.Menus.Add(menu);
            Db.SaveChanges();
            return true;
        }
        //sửa menu
        public bool Update(Menu menu)
        {
            bool status;
            try
            {
                var foot = Db.Menus.Find(menu.MenuID);
                foot.Text = menu.Text;
                foot.Link = menu.Link;
                foot.DisplayOrder = menu.DisplayOrder;
                foot.Target = menu.Target;
                foot.Status = menu.Status;
                foot.MenuTypeID = menu.MenuTypeID;
                foot.MenuParentID = menu.MenuParentID;
                foot.Icon = menu.Icon;
                foot.Properti = menu.Properti;
                Db.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //Xóa menu
        public bool Delete(Menu menu)
        {
            bool status;
            try
            {
                var model = Db.Menus.Find(menu.MenuID);
                Db.Menus.Remove(model);
                Db.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
