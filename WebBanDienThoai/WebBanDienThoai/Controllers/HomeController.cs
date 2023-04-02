using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Controllers
{
    public class HomeController : Controller
    {
        private const String CartSession = "CartSession";
        ShopMobileDbContext db = new ShopMobileDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //Sản phẩm mới:
            ViewBag.listNewProducts = db.Products.OrderByDescending(p => p.CreatedAt).Take(4).ToList();
            //Sản phẩm hot:
            ViewBag.listHotProducts = db.Products.OrderBy(p => p.Price).Take(4).ToList();
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
    }
}
