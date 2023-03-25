using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        private ShopMobileDbContext db = new ShopMobileDbContext();

        // GET: Admin/Default
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["admin"] != null)
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Admin/Home/Index");
            }
            return View();
        }
        //POST: Admin/Default
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var acc = db.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
            if (acc != null)
            {
                if (acc.RoleID == 2)
                {
                    // Đăng nhập admin thành công:
                    //Gán session:
                    Session["admin"] = acc;
                    //Chuyển tới trang Home quản trị
                    return RedirectToAction("Index", new { area = "Admin", controller = "Home" });
                }
                if (acc.RoleID == 1)
                {
                    //Đăng  nhập user thành công:
                    //Gán session:
                    Session["user"] = acc;
                    //Chuyển tới trang Home Client
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["admin"] = null;
            return RedirectToAction("Login");
        }
    }
}