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
    public class SlideController : ApiController
    {
        private SlideRepository slideRepository;
        public SlideController()
        {
            this.slideRepository = new SlideRepository();
        }
        [HttpGet]
        [Route("api/Slides/GetAll")]
        public List<SlideDTO> Get()
        {
            return slideRepository.ListSlide();
        }
        [HttpGet]
        [Route("api/Slides/SlideID={id}")]
        public SlideDTO Detail(int id)
        {
            return slideRepository.Detail(id);
        }
        [HttpPost]
        [Route("api/Slides")]
        public bool PostProduct(SlideDTO item)
        {
            return slideRepository.Insert(item);
        }
        [HttpPut]
        [Route("api/Slides/SlideID={id}")]
        public bool PutProductType(SlideDTO item)
        {
            return slideRepository.Update(item);
        }
        [HttpDelete]
        [Route("api/Slides/SlideID={id}")]
        public bool DeleteProductType(SlideDTO item)
        {
            return slideRepository.Delete(item);
        }
        public int autoKey()
        {
            return slideRepository.autoKey();
        }
    }
}
