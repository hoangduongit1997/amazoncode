using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DAL;
using Amazon.DTO;
using Amazon.EntityFramework;
using AutoMapper;
using PagedList;

namespace Amazon.BUS
{
    public class ProductTypeBUS
    {
        ProductTypeDAL dal = new ProductTypeDAL();
        public List<Ref_Product_TypesDTO> GetAll()
        {
            var lst = dal.GetAll();
            if (lst != null)
            {
                var config = new MapperConfiguration(cfg => {

                    cfg.CreateMap<Product, Ref_Product_TypesDTO>();

                });
                IMapper iMapper = config.CreateMapper();
                var typeModel = iMapper.Map<List<Ref_Product_Types>, List<Ref_Product_TypesDTO>>(lst);
                return typeModel;
            }
            return null;
        }
        public Ref_Product_TypesDTO ViewDetail(string id)
        {
            var type = dal.ViewDetail(id);
            if (type != null)
            {
                var config = new MapperConfiguration(cfg => {

                    cfg.CreateMap<Product, Ref_Product_TypesDTO>();

                });
                IMapper iMapper = config.CreateMapper();
                var productModel = iMapper.Map<Ref_Product_Types, Ref_Product_TypesDTO>(type);
                return productModel;
            }
            return null;
        }
        public ProductTypeDAL Da { get => dal; set => dal = value; }

        public bool Insert(Ref_Product_TypesDTO productType)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Ref_Product_TypesDTO, Ref_Product_Types>();

            });
            IMapper iMapper = config.CreateMapper();
            var typeModel = iMapper.Map<Ref_Product_TypesDTO, Ref_Product_Types>(productType);
            return Da.Insert(typeModel);
        }
        public bool Update(Ref_Product_TypesDTO productType)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Ref_Product_TypesDTO, Ref_Product_Types>();

            });
            IMapper iMapper = config.CreateMapper();
            var typeModel = iMapper.Map<Ref_Product_TypesDTO, Ref_Product_Types>(productType);
            return Da.Update(typeModel);
        }

        //public bool Delete(string id)
        //{
        //    return Da.Delete(id);
        //}

        //public IEnumerable<Ref_Product_Types> ListAll(int page, int pageSize)
        //{
        //    return Da.ListAllPaging(page, pageSize);
        //}
        //public List<Ref_Product_Types> ListAllProductType()
        //{
        //    return Da.ListAllProductType();
        //}
    }
}
