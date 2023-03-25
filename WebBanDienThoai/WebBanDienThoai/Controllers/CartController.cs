using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Controllers
{
    public class CartController : Controller
    {
        private const String CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddToCart(int productId, int quantity)
        {
            var cart = Session["CartSession"];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.product.ID == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //Tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.product.ID = productId;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào Session
                Session[CartSession] = list;
            }
            else
            {
                //Tạo mới đối tượng cart item
                var item = new Cart();
                item.Product.ID = productId;
                item.Quantity = quantity;
                var list = new List<Cart>();
                list.Add(item);

                //Gán vào Session
                Session[CartSession] = list;
            }

            return RedirectToAction("Index");
        }
    }
}