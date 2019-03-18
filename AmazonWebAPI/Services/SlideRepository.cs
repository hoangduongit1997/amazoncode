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

        public List<SlideDTO> ListSlide()
        {
            return Bus.List_Sliders();
        }
    }
}