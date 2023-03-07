using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanDienThoai.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Admin"] == null) //nếu chưa đăng nhập Admin
            {
                //trả về trang đăng nhập admin
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Default", action = "Login", Area = "Admin" }));

            }
            base.OnActionExecuting(filterContext);
        }
    }
}