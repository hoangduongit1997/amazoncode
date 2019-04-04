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
    public class FooterController : ApiController
    {
        private FooterRepository footerRepository;
        public FooterController()
        {
            this.footerRepository = new FooterRepository();
        }
        //lấy tất cả footer
        [HttpGet]
        [Route("api/Footers/GetAll")]
        public List<FooterDTO> Get()
        {
            return footerRepository.GetAll();
        }
        //lấy footer theo id
        [HttpGet]
        [Route("api/Footers/FooterID={id}")]
        public FooterDTO Detail(int id)
        {
            return footerRepository.Detail(id);
        }
        //thêm footer
        [HttpPost]
        [Route("api/Footers")]
        public bool PostProduct(FooterDTO item)
        {
            return footerRepository.Insert(item);
        }
        //sửa footer
        [HttpPut]
        [Route("api/Footers/FooterID={id}")]
        public bool PutProductType(FooterDTO item)
        {
            return footerRepository.Update(item);
        }
        //xóa footer
        [HttpDelete]
        [Route("api/Footers/FooterID={id}")]
        public bool DeleteProductType(FooterDTO item)
        {
            return footerRepository.Delete(item);
        }
        public int autoKey()
        {
            return footerRepository.autoKey();
        }
    }
}
