﻿using Amazon.DTO;
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
        public HomeApiController()
        {
            MenuRepository = new MenuRepository();
            SlideRepository = new SlideRepository();
        }
        public MenuRepository MenuRepository { get => menuRepository; set => menuRepository = value; }
        public SlideRepository SlideRepository { get => slideRepository; set => slideRepository = value; }

      
        [HttpGet]
        [Route("api/Home/Menu")]
        public List<MenuDTO> GetMenu()
        {
            return MenuRepository.ListMenu();
        }
        [HttpGet]
        [Route("api/Home/Slide")]
        public List<SlideDTO> GetSlide()
        {
            return SlideRepository.ListSlide();
        }
    }
}