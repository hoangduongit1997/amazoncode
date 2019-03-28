using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EntityFramework;

namespace Amazon.DAL
{
   public class SlideDAL
    {
        ShopDbContext db = null;
        public SlideDAL()
        {
            Db = new ShopDbContext();
        }

        public ShopDbContext Db { get => db; set => db = value; }
      
        public List<Slider> ListSlider()
        {
            return Db.Sliders.Select(t => t).ToList();
        }
        public Slider ViewDetail(int id)
        {
            return Db.Sliders.Find(id);
        }

        //thêm slide
        public bool Insert(Slider slide)
        {
            bool status;
            try
            {
                Db.Sliders.Add(slide);
                Db.SaveChanges();
                status = true;
            }
            catch(Exception)
            {
                status = false;
            }
            return status;
        }
        //mã tự động
        public int autoKey()
        {
            int key = 0;
            List<Slider> lst = Db.Sliders.Select(t => t).ToList<Slider>();
            if (Db.Sliders.Count() != 0)
            {
                Slider hv = lst[Db.Sliders.Count() - 1];
                key = (hv.ID + 1);
            }
            return key;
        }
        //sửa slide
        public bool Update(Slider slide)
        {
            bool status;
            try
            {
                var sld = Db.Sliders.Find(slide.ID);
                sld.Image = slide.Image;
                sld.DisplayOrder = slide.DisplayOrder;
                sld.Link = slide.Link;
                sld.Description = slide.Description;
                sld.CreatedDate = DateTime.Now;
                sld.CreatedBy = slide.CreatedBy;
                sld.ModifiedDate = DateTime.Now;
                sld.ModifiedBy = slide.ModifiedBy;
                sld.Status = slide.Status;
                sld.Priority = slide.Priority;
                Db.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //xóa slide
        public bool Delete(Slider slide)
        {
            bool status;
            try
            {
                var type = Db.Sliders.Find(slide.ID);
                Db.Sliders.Remove(type);
                Db.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
