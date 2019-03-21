using Amazon.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DAL
{
  public  class OrderDAL
    {
        ShopDbContext db = null;

        public ShopDbContext Db { get => db; set => db = value; }
        public OrderDAL()
        {
            Db = new ShopDbContext();
        }
        public string Insert(Order order)
        {
            Db.Orders.Add(order);
            Db.SaveChanges();
            return order.order_id;
        }
        public string Update(Order order)
        {
            var result = db.Orders.SingleOrDefault(t => t.order_id == order.order_id);
            if (result != null)
            {
                result.order_note = order.order_note;
                result.order_place = order.order_place;
                result.total_price = order.total_price;
                result.order_status_code = order.order_status_code;
            }
            db.SaveChanges();
            return result.order_id;
        }
        public Order FindByID(string orderID)
        {
            return Db.Orders.Find(orderID);
        }
    }
}
