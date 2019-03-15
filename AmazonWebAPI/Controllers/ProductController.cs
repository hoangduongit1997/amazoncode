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
    public class ProductController : ApiController
    {
        private ProductRepository productRepository;
        public ProductController()
        {
            this.productRepository = new ProductRepository();
        }
        [HttpGet]
        [Route("api/product/GetAll")]
        public List<ProductDTO> Get()
        {
            return productRepository.GetAllProduct();
           // return productRepository.GetOfType(typeID);
        }
        [HttpGet]
        [Route("api/product/Category={id:int}")]
        public List<Product> GetOfType(string id)
        {
            return productRepository.GetOfType(id);
        }
        [HttpGet]
        [Route("api/Product/ProductID={id:int}")]       
        public ProductDTO Detail(string id)
        {
            return productRepository.Detail(id);
        }
    }
}
