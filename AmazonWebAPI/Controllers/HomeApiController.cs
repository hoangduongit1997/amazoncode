using Amazon.DTO;
using AmazonWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AmazonWebAPI.Controllers
{
    public class HomeApiController : ApiController
    {
        private MenuRepository menuRepository;
        private SlideRepository slideRepository;
        private FooterRepository footerRepository;
        public HomeApiController()
        {
            MenuRepository = new MenuRepository();
            SlideRepository = new SlideRepository();
            FooterRepository = new FooterRepository();
        }
        public MenuRepository MenuRepository { get => menuRepository; set => menuRepository = value; }
        public SlideRepository SlideRepository { get => slideRepository; set => slideRepository = value; }
        public FooterRepository FooterRepository { get => footerRepository; set => footerRepository = value; }
        //lấy dữ liệu menu
        [HttpGet]
        [Route("api/Home/Menu")]
        public List<MenuDTO> GetMenu()
        {
            return MenuRepository.ListMenu();
        }
        //lấy dữ liệu slide
        [HttpGet]
        [Route("api/Home/Slide")]
        public List<SlideDTO> GetSlide()
        {
            return SlideRepository.ListSlide();
        }
        //lấy dữ liệu footer
        [HttpGet]
        [Route("api/Home/Footer")]
        public List<FooterDTO> Footer()
        {
            return FooterRepository.GetAll();
        }
    }
}
