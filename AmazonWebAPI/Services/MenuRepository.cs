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
        public List<MenuDTO> ListMenu()
        {
            return bus.ListMenu();
        }
    }
}