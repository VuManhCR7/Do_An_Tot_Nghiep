using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Controllers
{
    public class UserController : Controller
    {
        private ShopMobileDbContext db = new ShopMobileDbContext();
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                if (user.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (user.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var u = new User();
                    u.RoleID = model.Role;
                    u.Name = model.Name;
                    u.Username = model.UserName;
                    u.Password = model.Password;
                    u.Phone = model.Phone;
                    u.Email = model.Email;
                    u.Address = model.Address;
                    u.CreatedAt = DateTime.Now;
                    u.UpdateAt = DateTime.Now;
                    var result = user.Insert(u);                 
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công!";
                        db.Users.Add(u);
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công!");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["user"] != null)
            {
                System.Web.HttpContext.Current.Response.Redirect("/Home/Index");
            }
            return View();
        }

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
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}