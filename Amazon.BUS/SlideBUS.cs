using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EntityFramework;
using Amazon.DAL;

namespace Amazon.BUS
{
   public class SlideBUS
    {
        SlideDAL slider = null;
        public SlideBUS()
        {
            Slider = new SlideDAL();
        }
        public SlideDAL Slider { get => this.slider; set => this.slider = value; }

        public List<Slider> Sliders()
        {
            return Slider.Slider().ToList();
        }
    }
}
