using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Controllers
{
    public class ProductController : Controller
    {
        private ShopMobileDbContext db = new ShopMobileDbContext();
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.Title = "Product Page";
            //Sản phẩm mới:
            ViewBag.listNewProducts = db.Products.OrderByDescending(p => p.Name).Take(6).ToList();
            //Sản phẩm hot:
            ViewBag.listHotProducts = db.Products.OrderBy(p => p.Price).Take(6).ToList();
            return View();
        }
    }
}