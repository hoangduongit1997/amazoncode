using Amazon.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amazon.Models.Cart
{
    public class CartItemModel
    {
        Product product;
        int quantity;

        public int Quantity { get => quantity; set => quantity = value; }
        public Product Product { get => product; set => product = value; }
    }
}