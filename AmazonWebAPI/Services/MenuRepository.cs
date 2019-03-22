using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.BUS;
using Amazon.DTO;

namespace AmazonWebAPI.Services
{
    public class MenuRepository
    {
        MenuBUS bus = null;
        public MenuRepository()
        {
            bus = new MenuBUS();
        }
        //danh sách menu
        public List<MenuDTO> ListMenu()
        {
            return bus.ListMenu();
        }
        //lấy footer
        public MenuDTO Detail(int id)
        {
            return bus.ViewDetail(id);
        }
        //thêm footer
        public bool Insert(MenuDTO item)
        {
            return bus.Insert(item);
        }
        //sửa footer
        public bool Update(MenuDTO menu)
        {
            return bus.Update(menu);
        }
        //xóa footer
        public bool Delete(MenuDTO menu)
        {
            return bus.Delete(menu);
        }
        //mã tự động
        public int autoKey()
        {
            return bus.autoKey();
        }
    }
}