using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DAL;
using Amazon.DTO;
using AutoMapper;
using Amazon.EntityFramework;
namespace Amazon.BUS
{
    public class ProductBUS
    {
        ProductDAL dal = new ProductDAL();
        public List<ProductDTO> GetAll()
        {
            var lst = dal.GetAll();
            if (lst != null)
            {
                var config = new MapperConfiguration(cfg => {

                    cfg.CreateMap<Product, ProductDTO>();

                });
                IMapper iMapper = config.CreateMapper();
                var productModel = iMapper.Map<List<Product>, List<ProductDTO>>(lst);
                return productModel;
            }
            return null;
        }
        public List<ProductDTO> GetByType(string id)
        {
            var lst = dal.GetByType(id);
            if (lst != null)
            {
                var config = new MapperConfiguration(cfg => {

                    cfg.CreateMap<Product, ProductDTO>();

                });
                IMapper iMapper = config.CreateMapper();
                var productModel = iMapper.Map<List<Product>, List<ProductDTO>>(lst);
                return productModel;
            }
            return null;
        }
        public ProductDTO ViewDetail(string id)
        {
            var product = dal.ViewDetail(id);
            if (product != null)
            {
                var config = new MapperConfiguration(cfg => {

                    cfg.CreateMap<Product, ProductDTO>();

                });
                IMapper iMapper = config.CreateMapper();
                var productModel = iMapper.Map<Product, ProductDTO>(product);
                return productModel;
            }
            return null;
        }

        //public List<Product> ListRelatedProducts(string productId)
        //{
        //    return da.ListRelatedProducts(productId);
        //}

        //public string Insert(Product product)
        //{
        //    return da.Insert(product);
        //}

        //public IEnumerable<Product> ListAll(int page, int pageSize)
        //{
        //    return da.ListAllPaging(page, pageSize);
        //}

        //public bool Update(Product entity)
        //{
        //    return da.Update(entity);
        //}

        //public Product GetById(string productName)
        //{
        //    return da.GetById(productName);
        //}

        //public bool Delete(string id)
        //{
        //    return da.Delete(id);
        //}

        //public void UpdateImages(string productId, string images)
        //{
        //    da.UpdateImages(productId, images);
        //}
        //public List<Product> ListNewProduct()
        //{
        //    return da.ListNewProduct();
        //}
        //public List<Product> ListProductOfType(string typeID)
        //{
        //    return da.ListProductOfType(typeID);
        //}
        //public List<Product> TopDealProduct()
        //{
        //    return da.TopDealProduct();
        //}
    }
}
