using Amazon.BUS;
using Amazon.DTO;
using AmazonWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AmazonWebAPI.Services
{
    public class ProductTypeRepository
    {
        ProductTypeBUS bus = new ProductTypeBUS();
        public List<Ref_Product_TypesDTO> GetAllProductType()
        {
            return bus.GetAll();
        }
        public Ref_Product_TypesDTO Detail(string id)
        {
            return bus.ViewDetail(id);
        }
        public bool Insert(Ref_Product_TypesDTO item)
        {
            return bus.Insert(item);
        }
        public bool Update(Ref_Product_TypesDTO product_TypesDTO)
        {
            return bus.Update(product_TypesDTO);
        }
        public bool Delete(Ref_Product_TypesDTO product_TypesDTO)
        {
            return bus.Delete(product_TypesDTO);
        }
        public string autoKey()
        {
            return bus.autoKey();
        }
    }
}