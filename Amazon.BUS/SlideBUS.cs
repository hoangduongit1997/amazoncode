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
            dal = new SlideDAL();
        }

        public SlideDAL Da { get => dal; set => dal = value; }
        //danh sách slide
        public List<SlideDTO> List_Sliders()
        {
            var sliders = Da.ListSlider();
            if (sliders != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Slider, SlideDTO>();
                });
                IMapper iMapper = config.CreateMapper();
                var slidersModel = iMapper.Map<List<Slider>, List<SlideDTO>>(sliders);
                return slidersModel;
            }
            return null;
        }
        //Lấy slide
        public SlideDTO ViewDetail(int id)
        {
            var type = dal.ViewDetail(id);
            if (type != null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Slider, SlideDTO>();
                });
                IMapper iMapper = config.CreateMapper();
                var model = iMapper.Map<Slider, SlideDTO>(type);
                return model;
            }
            return null;
        }
        //thêm slide
        public bool Insert(SlideDTO Slider)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SlideDTO, Slider>();
            });
            IMapper iMapper = config.CreateMapper();
            var model = iMapper.Map<SlideDTO, Slider>(Slider);
            return Da.Insert(model);
        }
        //Mã tự động
        public int autoKey()
        {
            return Da.autoKey();
        }
        //sủa slide
        public bool Update(SlideDTO Slider)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<SlideDTO, Slider>();

            });
            IMapper iMapper = config.CreateMapper();
            var model = iMapper.Map<SlideDTO, Slider>(Slider);
            return Da.Update(model);
        }
        //xóa slide
        public bool Delete(SlideDTO Slider)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<SlideDTO, Slider>();

            });
            IMapper iMapper = config.CreateMapper();
            var model = iMapper.Map<SlideDTO, Slider>(Slider);
            return Da.Delete(model);
        }
    }
}
