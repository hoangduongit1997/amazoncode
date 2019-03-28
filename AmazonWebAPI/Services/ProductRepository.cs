using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AmazonWebAPI.Models;
using Amazon.DTO;
using Amazon.BUS;
namespace AmazonWebAPI.Services
{
    public class ProductRepository
    {
        //SHOPEntities shop =new SHOPEntities();

        //public SHOPEntities Shop { get => shop; set => shop = value; }
        ProductBUS bus = new ProductBUS();

        public List<ProductDTO> GetOfType(string ID)
        {
            return bus.GetByType(ID);
        }
        public List<ProductDTO> GetAllProduct()
        {
            return bus.GetAll();
        }
        public ProductDTO Detail(string id)
        {
            return bus.ViewDetail(id);
        }
        //thêm PRODUCT
        public bool Insert(ProductDTO product)
        {
            return bus.Insert(product);
        }
        //sửa PRODUCT
        public bool Update(ProductDTO product)
        {
            return bus.Update(product);
        }
        //xóa PRODUCT
        public bool Delete(ProductDTO product)
        {
            return bus.Delete(product);
        }
        //mã tự động
        public string autoKey()
        {
            return bus.autoKey();
        }
    }
    
}