using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebBanDienThoai.Models;
using System.Web.Script.Serialization;
using System.Web.Http;

namespace WebBanDienThoai.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        private ShopMobileDbContext db = new ShopMobileDbContext();

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

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            //Gán lại session cho sessionCart
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new List<CartItem>();
            if (!string.IsNullOrEmpty(cartModel))
            {
                jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            }
            var sessionCart = (List<CartItem>)Session[CartSession];

            if(sessionCart != null)
            {
                foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                    ViewBag.New = item.Quantity;
                }
            }
            }
            //Gán lại session cho sessionCart
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddToCart(int productId, int quantity)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                //ShopMobileDbContext db = new ShopMobileDbContext();
                //ViewBag.product = db.Products.Where(x => x.ID == productId).ToList();          
                var cart = Session[CartSession];
                var product = db.Products.Find(productId);

                if (cart != null)
                {
                    var list = (List<CartItem>)cart;
                    if (list.Exists(x => x.Product.ID == productId))
                    {
                        foreach (var item in list)
                        {
                            if (item.Product.ID == productId)
                            {
                                item.Quantity += quantity;
                            }
                        }
                    }
                    else
                    {
                        //Tạo mới đối tượng cart item
                        var item = new CartItem();
                        item.Product.ID = productId;
                        item.Product.Name = product.Name;
                        item.Product.Image = product.Image;
                        item.Quantity = quantity;
                        item.Product.Price = product.Price;
                        list.Add(item);
                    }
                    //Gán vào Session
                    Session[CartSession] = list;
                }
                else
                {
                    //Tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product.ID = productId;
                    item.Product.Name = product.Name;
                    item.Product.Image = product.Image;
                    item.Quantity = quantity;
                    item.Product.Price = product.Price;
                    var list = new List<CartItem>();
                    list.Add(item);

                    //Gán vào Session
                    Session[CartSession] = list;
                }
                return RedirectToAction("Index");
            }                        
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Payment()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                var cart = Session[CartSession];
                var list = new List<CartItem>();
                if (cart != null)
                {
                    list = (List<CartItem>)cart;
                }
                return View(list);
            }
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Payment(string address)
        {
            User acc = (User)Session["User"];
            var order = new Order();
            order.CreatedAt = DateTime.Now;
            order.Status = 1;         
            order.ReceivedAddress = address;
            order.UserID = acc.ID;

            try
            {
                var id = new Order().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detail = new OrdersDetail();
                foreach (var item in cart)
                {
                    var orderDetail = new OrdersDetail();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.CreatedAt = DateTime.Now;
                    detail.Insert(orderDetail);
                }
            }
            catch (Exception ex)
            {
                
            }
            
            return Redirect("/hoan-thanh");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}