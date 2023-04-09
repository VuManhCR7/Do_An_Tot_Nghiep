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
        private const string CartSession = "CartSession";
        //private const string UserSession = "user";
        ShopMobileDbContext db = new ShopMobileDbContext();
        public ActionResult Index()
        {           
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                User acc = (User)Session["User"];
                ViewBag.Name = acc.Name;
                ViewBag.ID = acc.ID;
            }        
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

        [ChildActionOnly]
        public PartialViewResult TopMenu()
        {
            if (Session["user"] != null)           
            {
                User acc = (User)Session["User"];
                ViewBag.Name = acc.Name;
                ViewBag.ID = acc.ID;
            }
            return PartialView();
        }
    }
}
