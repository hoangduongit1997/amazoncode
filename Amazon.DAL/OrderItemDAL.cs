using Amazon.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DAL
{
   public class OrderItemDAL
    {
        ShopDbContext db = null;
        public OrderItemDAL()
        {
            Db = new ShopDbContext();
        }

        public ShopDbContext Db { get => db; set => db = value; }
        public string Insert(Order_items item)
        {
            Db.Order_items.Add(item);
            Db.SaveChanges();
            return item.order_item_id;
        }
    }
}
