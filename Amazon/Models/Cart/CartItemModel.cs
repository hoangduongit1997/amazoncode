using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.DTO;
namespace Amazon.Models.Cart
{
    public class CartItemModel
    {
        ProductDTO product;
        int quantity;

        public int Quantity { get => quantity; set => quantity = value; }
        public ProductDTO Product { get => product; set => product = value; }
    }
}