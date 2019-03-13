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
        public List<Slider> Slider()
        {
            return db.Sliders.Where(t => t.Status == true).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}
