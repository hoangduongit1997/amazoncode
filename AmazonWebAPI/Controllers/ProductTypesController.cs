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
        [HttpGet]
        [Route("api/productTypes/GetAll")]
        public List<Ref_Product_TypesDTO> Get()
        {
            return producttypeRepository.GetAllProductType();
            // return productRepository.GetOfType(typeID);
        }
        //[HttpGet]
        //[Route("api/product/Category={id:int}")]
        //public List<Ref_Product_Types> GetOfType(string id)
        //{
        //    return producttypeRepository.GetOfType(id);
        //}
        [HttpGet]
        [Route("api/ProductTypes/ProductTypeID={id:int}")]
        public Ref_Product_TypesDTO Detail(string id)
        {
            return producttypeRepository.Detail(id);
        }
        [HttpPost]
        [Route("api/ProductTypes")]
        // Not the final implementation!
        public bool PostProduct(Ref_Product_TypesDTO item)
        {
            return producttypeRepository.Insert(item);
        }
        [HttpPut]
        [Route("api/ProductTypes/ProductTypeID={id}")]
        // Not the final implementation!
        public bool PutProductType(string id, Ref_Product_TypesDTO item)
        {
            item.product_type_code = id;
            if (!producttypeRepository.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return true;
        }
    }
}
