//using Amazon.DAL;
//using Amazon.EntityFramework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Amazon.BUS
//{
//   public class OrderBUS
//    {
//        OrderDAL dal = null;

//        public OrderDAL Dal { get => dal; set => dal = value; }
//        public OrderBUS()
//        {
//            Dal = new OrderDAL();
//        }
//        public string Insert(Order order)
//        {
//            return dal.Insert(order);
//        }
//        public string Update(Order order)
//        {
//            return dal.Update(order);
//        }
//    }
//}
