using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EntityFramework;

namespace Amazon.DAL
{
   public class FooterDAL
    {
        ShopDbContext db = null;

        public ShopDbContext Db { get => db; set => db = value; }
        public FooterDAL()
        {
            Db = new ShopDbContext();
        }
        public List<Footer> ListFooter()
        {
            return Db.Footers.Where(t=>t.Status==true).ToList();
        }
    }
}
