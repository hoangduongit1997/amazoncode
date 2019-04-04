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
        //lấy tất cả product
        [HttpGet]
        [Route("api/products/GetAll")]
        public List<ProductDTO> Get()
        {
            return productRepository.GetAllProduct();
        }
        //lấy product theo product type id
        [HttpGet]
        [Route("api/products/ProductTypeID={id}")]
        public List<ProductDTO> GetOfType(string id)
        {
            return productRepository.GetOfType(id);
        }
        //lấy product theo product name
        [HttpGet]
        [Route("api/products/name={name}")]
        public List<ProductDTO> Getallby(string name)
        {
            return productRepository.GetAllBy(name);
        }
        //lấy product theo id
        [HttpGet]
        [Route("api/Products/ProductID={id}")]       
        public ProductDTO Detail(string id)
        {
            return productRepository.Detail(id);
        }
        //thêm product
        [HttpPost]
        [Route("api/Products")]
        public bool PostProduct(ProductDTO item)
        {
            return productRepository.Insert(item);
        }
        //sửa product
        [HttpPut]
        [Route("api/Products/ProductID={id}")]
        public bool PutProductType(ProductDTO item)
        {
            return productRepository.Update(item);
        }
        //xóa product
        [HttpDelete]
        [Route("api/Products/ProductID={id}")]
        public bool DeleteProductType(ProductDTO item)
        {
            return productRepository.Delete(item);
        }
        //
        public string autoKey()
        {
            return productRepository.autoKey();
        }
    }
}
