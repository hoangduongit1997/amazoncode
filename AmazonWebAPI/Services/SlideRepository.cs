using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.BUS;
using Amazon.DTO;
namespace AmazonWebAPI.Services
{
    public class SlideRepository
    {

        SlideBUS bus = null;
        public SlideRepository()
        {
            Bus = new SlideBUS();
        }

        public SlideBUS Bus { get => bus; set => bus = value; }
        //danh sách slide
        public List<SlideDTO> ListSlide()
        {
            return Bus.List_Sliders();
        }
        //lấy slide
        public SlideDTO Detail(int id)
        {
            return bus.ViewDetail(id);
        }
        //thêm slide
        public bool Insert(SlideDTO item)
        {
            return bus.Insert(item);
        }
        //sửa slide
        public bool Update(SlideDTO slide)
        {
            return bus.Update(slide);
        }
        //xóa slide
        public bool Delete(SlideDTO slide)
        {
            return bus.Delete(slide);
        }
        //mã tự động
        public int autoKey()
        {
            return bus.autoKey();
        }
    }
}