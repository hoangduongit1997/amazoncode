using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Amazon.DTO;
using Amazon.BUS;

namespace AmazonWebAPI.Services
{
    public class OrderController : ApiController
    {
        OrderBUS orderBUS = null;
        public OrderController()
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
