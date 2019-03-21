using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Amazon.BUS;
using AmazonWebAPI.Services;
using Amazon.DTO;
namespace AmazonWebAPI.Controllers
{
    public class OrderController : ApiController
    {
        OrderRepository orderRepository = null;

        public OrderRepository OrderRepository { get => orderRepository; set => orderRepository = value; }
       public OrderController()
        {
            OrderRepository = new OrderRepository();
        }
        public string Insert(OrderDTO orderEntity)
        {
            return OrderRepository.Insert(orderEntity);
        }
        public string Update(OrderDTO orderEntity)
        {
            return OrderRepository.Update(orderEntity);
        }
    }
}
