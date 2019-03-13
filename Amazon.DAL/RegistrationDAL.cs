using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EntityFramework;
namespace Amazon.DAL
{
   public class RegistrationDAL
    {
        ShopDbContext db;
      public  RegistrationDAL()
        {
            Db = new ShopDbContext();
        }

        public ShopDbContext Db { get => db; set => db = value; }
        
    }
}
