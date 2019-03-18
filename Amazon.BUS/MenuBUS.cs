using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DAL;
using Amazon.DTO;
using AutoMapper;
using Amazon.EntityFramework;
namespace Amazon.BUS
{
    public class MenuBUS
    {
        MenuDAL dal = null;
        public MenuBUS()
        {
            dal = new MenuDAL();
        }

        public MenuDAL Dal { get => dal; set => dal = value; }

        public List<MenuDTO> ListMenu()
        {
            var menu = dal.ListMenu();
            if (menu != null)
            {
                var config = new MapperConfiguration(cfg => {

                    cfg.CreateMap<Menu,MenuDTO>();

                });
                IMapper iMapper = config.CreateMapper();
                var menuModel = iMapper.Map<List<Menu>,List<MenuDTO>>(menu);
                return menuModel;
            }
            return null;
        }

    }
}
