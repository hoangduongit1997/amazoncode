using Amazon.DTO;
using AmazonWebAPI.Models;
using AmazonWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmazonWebAPI.Controllers
{
    public class ProductTypesController : ApiController
    {
        private ProductTypeRepository producttypeRepository;
        public ProductTypesController()
        {
            this.producttypeRepository = new ProductTypeRepository();
        }
        //lấy tất cả product type
        [HttpGet]
        [Route("api/productTypes/GetAll")]
        public List<Ref_Product_TypesDTO> Get()
        {
            return producttypeRepository.GetAllProductType();
        }
        //lấy product type theo id
        [HttpGet]
        [Route("api/ProductTypes/ProductTypeID={id}")]
        public Ref_Product_TypesDTO Detail(string id)
        {
            return producttypeRepository.Detail(id);
        }
        //thêm product type
        [HttpPost]
        [Route("api/ProductTypes")]
        public bool PostProduct(Ref_Product_TypesDTO item)
        {
            return producttypeRepository.Insert(item);
        }
        //sửa product type
        [HttpPut]
        [Route("api/ProductTypes/ProductTypeID={id}")]
        public bool PutProductType(Ref_Product_TypesDTO item)
        {
            return producttypeRepository.Update(item);
        }
        //xóa product type
        [HttpDelete]
        [Route("api/ProductTypes/ProductTypeID={id}")]
        public bool DeleteProductType(Ref_Product_TypesDTO item)
        {
            return producttypeRepository.Delete(item);
        }

        public string autoKey()
        {
            return producttypeRepository.autoKey();
        }
    }
}
