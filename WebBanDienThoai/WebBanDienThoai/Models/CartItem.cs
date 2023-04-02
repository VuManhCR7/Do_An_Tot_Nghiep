using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanDienThoai.Models
{
    [Serializable]
    public class CartItem
    {
        public CartItem()
        {
            Product = new Product();
        }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}