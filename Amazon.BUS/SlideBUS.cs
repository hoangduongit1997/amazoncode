using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EntityFramework;
using Amazon.DAL;
using Amazon.DTO;
using AutoMapper;

namespace Amazon.BUS
{
    public class SlideBUS
    {
        SlideDAL dal = null;
        public SlideBUS()
        {
            Dal = new SlideDAL();
        }

        public SlideDAL Dal { get => dal; set => dal = value; }
        public List<SlideDTO> ConvertListToListDTO(List<Slider> lst)
        {
            var list = new List<SlideDTO>();
            var sliders = Dal.ListSlider();
            if (sliders != null)
            {
                var config = new MapperConfiguration(cfg =>
                {

                    cfg.CreateMap<Slider, SlideDTO>();

                });
                IMapper iMapper = config.CreateMapper();
                list = iMapper.Map<List<Slider>, List<SlideDTO>>(sliders);
            }
            return list;
        }
        public List<SlideDTO> List_Sliders()
        {
            return ConvertListToListDTO(dal.ListSlider());
        }
    }
}
