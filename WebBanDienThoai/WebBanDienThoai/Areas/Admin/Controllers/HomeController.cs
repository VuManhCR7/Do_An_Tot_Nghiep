using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Default");
            }
            else
            {
                User acc = (User)Session["Admin"];
                ViewBag.Name = acc.Name;
                ViewBag.ID = acc.ID;
            }
            return View();
        }
    }
}