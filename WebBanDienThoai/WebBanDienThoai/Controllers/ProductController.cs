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
            ViewBag.listNewProducts = db.Products.OrderByDescending(p => p.Name).Take(10).ToList();
            //Sản phẩm hot:
            ViewBag.listHotProducts = db.Products.OrderBy(p => p.Price).Take(10).ToList();
            return View();
        }

        public ActionResult Detail(int pId)
        {
            //Xem chi tiết sản phẩm thông qua ProductID
            ViewBag.productDetails = db.Products.Where(x => x.ID == pId).ToList();

            //Lấy danh sách sản phẩm liên quan đến danh mục
            var product = db.Products.Find(pId);
            ViewBag.productCateId = db.Products.Where(x => x.ID != pId && x.CategoryID == product.CategoryID).ToList();
            return View();
        }

        public ActionResult GetProductList(int cId)
        {
            //Lấy thông tin chi tiết của Danh mục thông qua CategoryID
            ViewBag.cate = db.Categories.Where(x => x.ID == cId).ToList();

            //Lấy danh sách sản phẩm theo danh mục
            var category = db.Categories.Find(cId);
            ViewBag.productByCateId = db.Products.Where(x => x.CategoryID == category.ID).ToList();
            return View();
        }

        public ActionResult Search (string keyword)
        {
            //Từ khoá tìm kiếm
            ViewBag.keyword = keyword;
            //Lọc thông tin sản phẩm theo tên của sản phẩm mà người dùng nhập vào trên ô Input
            ViewBag.filterByName = db.Products.Where(x => x.Name.Contains(keyword)).ToList();
            return View();
        }
    }
}