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

        public MenuDAL Da { get => dal; set => dal = value; }

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
        //Lấy Menu
        public MenuDTO ViewDetail(int id)
        {
            var type = dal.ViewDetail(id);
            if (type != null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Menu, MenuDTO>();
                });
                IMapper iMapper = config.CreateMapper();
                var model = iMapper.Map<Menu, MenuDTO>(type);
                return model;
            }
            return null;
        }
        //thêm Menu
        public bool Insert(MenuDTO Menu)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MenuDTO, Menu>();
            });
            IMapper iMapper = config.CreateMapper();
            var model = iMapper.Map<MenuDTO, Menu>(Menu);
            return Da.Insert(model);
        }
        public int autoKey()
        {
            return Da.autoKey();
        }
        //sủa Menu
        public bool Update(MenuDTO Menu)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<MenuDTO, Menu>();

            });
            IMapper iMapper = config.CreateMapper();
            var model = iMapper.Map<MenuDTO, Menu>(Menu);
            return Da.Update(model);
        }
        //xóa Menu
        public bool Delete(MenuDTO Menu)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<MenuDTO, Menu>();

            });
            IMapper iMapper = config.CreateMapper();
            var model = iMapper.Map<MenuDTO, Menu>(Menu);
            return Da.Delete(model);
        }

    }
}
