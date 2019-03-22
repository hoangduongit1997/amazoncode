using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DAL;
using Amazon.DTO;
using Amazon.EntityFramework;
using AutoMapper;

namespace Amazon.BUS
{
    public class FooterBUS
    {
        FooterDAL dal = new FooterDAL();
        public List<FooterDTO> GetAll()
        {
            var lst = dal.ListFooter();
            if (lst != null)
            {
                var config = new MapperConfiguration(cfg => {

                    cfg.CreateMap<Product, FooterDTO>();

                });
                IMapper iMapper = config.CreateMapper();
                var typeModel = iMapper.Map<List<Footer>, List<FooterDTO>>(lst);
                return typeModel;
            }
            return null;
        }
        public FooterDAL Da { get => dal; set => dal = value; }
        //Lấy footer
        public FooterDTO ViewDetail(int id)
        {
            var type = dal.ViewDetail(id);
            if (type != null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Footer, FooterDTO>();
                });
                IMapper iMapper = config.CreateMapper();
                var model = iMapper.Map<Footer, FooterDTO>(type);
                return model;
            }
            return null;
        }
        //thêm footer
        public bool Insert(FooterDTO footer)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<FooterDTO, Footer>();
            });
            IMapper iMapper = config.CreateMapper();
            var typeModel = iMapper.Map<FooterDTO, Footer>(footer);
            return Da.Insert(typeModel);
        }
        public int autoKey()
        {
            return Da.autoKey();
        }
        //sủa footer
        public bool Update(FooterDTO footer)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<FooterDTO, Footer>();

            });
            IMapper iMapper = config.CreateMapper();
            var typeModel = iMapper.Map<FooterDTO, Footer>(footer);
            return Da.Update(typeModel);
        }
        //xóa footer
        public bool Delete(FooterDTO footer)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<FooterDTO, Footer>();

            });
            IMapper iMapper = config.CreateMapper();
            var typeModel = iMapper.Map<FooterDTO, Footer>(footer);
            return Da.Delete(typeModel);
        }
    }
}
