using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Areas.Admin.Controllers
{
    public class OrdersController : BaseController
    {
        private ShopMobileDbContext db = new ShopMobileDbContext();
        public ActionResult Index(string searchString, int? page)
        {         
            var orders = db.Orders.ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                orders = db.Orders.Where(x => x.ReceivedAddress.Contains(searchString)).OrderByDescending(y => y.CreatedAt).ToList();
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);     
            ViewBag.SearchString = searchString;
            return View(orders.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //OrdersDetail od = db.OrdersDetails.Find(id.Equals(db.Orders.FirstOrDefault()));
            Order od = db.Orders.Find(id);
            var order = db.OrdersDetails.Where(x => x.OrderID == id).FirstOrDefault();
            var p = db.Products.Where(x => x.ID == order.ProductID).FirstOrDefault();
            ViewBag.NameProduct = p.Name;
            ViewBag.Price = p.Price;
            ViewBag.Quantity = order.Quantity;
            if (od == null)
            {
                return HttpNotFound();
            }

            return View(od);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,Status,ReceivedAddress,CreatedAt,UpdateAt")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Xoá dữ liệu trên bảng OrderDetail trước sau đó mới thực hiện xoá dữ liệu trong bảng Order     
            var ordersDetail = db.OrdersDetails.Where(x => x.OrderID == id).ToList();          

            foreach (var item in ordersDetail)
            {
                OrdersDetail order = db.OrdersDetails.Find(item.ID);  
                db.OrdersDetails.Remove(order);
                db.SaveChanges();
            }

            Order o = db.Orders.Find(id);
            db.Orders.Remove(o);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
