using Amazon.BUS;
using Amazon.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmazonWebAPI.Services
{
    public class OrderRepository
    {
        OrderBUS orderBUS = null;
        public OrderRepository()
        {
            OrderBUS = new OrderBUS();
        }

        public OrderBUS OrderBUS { get => orderBUS; set => orderBUS = value; }
        public List<OrderDTO> Checkorder()
        {
            return OrderBUS.CheckOrder();
        }
    }
}