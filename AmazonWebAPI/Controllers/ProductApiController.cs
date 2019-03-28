using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Amazon.DTO;
using AmazonWebAPI.Models;
using AmazonWebAPI.Services;
namespace AmazonWebAPI.Controllers
{
    public class ProductApiController : ApiController
    {
        private ProductRepository productRepository;
        public ProductApiController()
        {
            this.productRepository = new ProductRepository();
        }
        [HttpGet]
        [Route("api/products/GetAll")]
        public List<ProductDTO> Get()
        {
            return productRepository.GetAllProduct();
           // return productRepository.GetOfType(typeID);
        }
        [HttpGet]
        [Route("api/products/ProductType={id}")]
        public List<ProductDTO> GetOfType(string id)
        {
            return productRepository.GetOfType(id);
        }
        [HttpGet]
        [Route("api/Products/ProductID={id}")]       
        public ProductDTO Detail(string id)
        {
            return productRepository.Detail(id);
        }
        [HttpPost]
        [Route("api/Products")]
        public bool PostProduct(ProductDTO item)
        {
            return productRepository.Insert(item);
        }
        [HttpPut]
        [Route("api/Products/ProductID={id}")]
        public bool PutProductType(ProductDTO item)
        {
            return productRepository.Update(item);
        }
        [HttpDelete]
        [Route("api/Products/ProductID={id}")]
        public bool DeleteProductType(ProductDTO item)
        {
            return productRepository.Delete(item);
        }
        public string autoKey()
        {
            return productRepository.autoKey();
        }
    }
}
