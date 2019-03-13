﻿using Amazon.DAL;
using Amazon.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.BUS
{
  public  class OrderItemBUS
    {
        OrderItemDAL dal = null;
        public OrderItemBUS()
        {
            dal = new OrderItemDAL();
        }
        public string Insert(Order_items item)
        {
            return dal.Insert(item);
        }
    }
}
