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
        FooterDAL dal = null;


        public FooterBUS()
        {
            Dal = new FooterDAL();
        }

        public FooterDAL Dal { get => dal; set => dal = value; }

        public List<FooterDTO> convertListToListDTO(List<Footer> Change)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Footer, FooterDTO>();

            });
            IMapper iMapper = config.CreateMapper();
            var res = iMapper.Map<List<Footer>, List<FooterDTO>>(Change);
            return res;
        }
        public List<FooterDTO> ListFooter()
        {

            return convertListToListDTO(Dal.ListFooter());
        }
    }
}
