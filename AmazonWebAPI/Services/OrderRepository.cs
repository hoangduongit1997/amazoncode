using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.BUS;
using Amazon.DTO;
namespace AmazonWebAPI.Services
{
    public class OrderRepository
    {
        OrderBUS orderBUS = null;

        public OrderBUS OrderBUS { get => orderBUS; set => orderBUS = value; }
        public OrderRepository()
        {
            OrderBUS = new OrderBUS();
        }
        public string Insert(OrderDTO orderEntity)
        {
            return orderBUS.Insert(orderEntity);
        }
        public string Update(OrderDTO orderEntity)
        {
            return orderBUS.Update(orderEntity);
        }
    }
}