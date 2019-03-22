using Amazon.DTO;
using AmazonWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmazonWebAPI.Controllers
{
    public class MenuController : ApiController
    {
        private MenuRepository menuRepository;
        public MenuController()
        {
            this.menuRepository = new MenuRepository();
        }
        [HttpGet]
        [Route("api/Menus/GetAll")]
        public List<MenuDTO> Get()
        {
            return menuRepository.ListMenu();
        }
        [HttpGet]
        [Route("api/Menus/MenuID={id}")]
        public MenuDTO Detail(int id)
        {
            return menuRepository.Detail(id);
        }
        [HttpPost]
        [Route("api/Menus")]
        public bool PostProduct(MenuDTO item)
        {
            return menuRepository.Insert(item);
        }
        [HttpPut]
        [Route("api/Menus/MenuID={id}")]
        public bool PutProductType(MenuDTO item)
        {
            return menuRepository.Update(item);
        }
        [HttpDelete]
        [Route("api/Menus/MenuID={id}")]
        public bool DeleteProductType(MenuDTO item)
        {
            return menuRepository.Delete(item);
        }
        public int autoKey()
        {
            return menuRepository.autoKey();
        }
    }
}
