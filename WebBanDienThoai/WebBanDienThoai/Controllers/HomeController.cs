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
    }
}
