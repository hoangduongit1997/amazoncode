﻿using Amazon.DAL;
using Amazon.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DTO;
using AutoMapper;

namespace Amazon.BUS
{
    public class OrderBUS
    {
        OrderDAL dal = null;

        public OrderDAL Dal { get => dal; set => dal = value; }
        public OrderBUS()
        {
            Dal = new OrderDAL();
        }
        public Order changeDTO(OrderDTO orderChange)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<OrderDTO, Order>();

            });
            IMapper iMapper = config.CreateMapper();
            var orderModel = iMapper.Map<OrderDTO, Order>(orderChange);
            return orderModel;
        }
        public string Insert(OrderDTO order)
        {
           
            return dal.Insert(changeDTO(order));
        }

     
        
        public List<OrderDTO> CheckOrder()
        {
            var order = dal.CheckOrder();
            if (order != null)
            {
                var config = new MapperConfiguration(cfg => {

                    cfg.CreateMap<Menu, MenuDTO>();

                });
                IMapper iMapper = config.CreateMapper();
                var orderModel = iMapper.Map<List<Order>, List<OrderDTO>>(order);
                return orderModel;
            }
            return null;
        }
    }
}
