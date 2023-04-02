using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoai.Models;
using PagedList;

namespace WebBanDienThoai.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        private ShopMobileDbContext db = new ShopMobileDbContext();

        // GET: Admin/Products
        [HttpGet]
        public ActionResult Index(string searchString,int ?page)
        {
            var products = db.Products.Include(x => x.Category).ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                products = db.Products.Where(p => p.Name.Contains(searchString)).OrderByDescending(x => x.CreatedAt).ToList();
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            //var product = new Product();
            //var model = product.ListProductPaging(pageIndex, pageSize);
            ViewBag.SearchString = searchString;
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product pro, HttpPostedFileBase uploadFile)
        {
            db.Products.Add(pro);
            if (String.IsNullOrEmpty(pro.CreatedAt.ToString()))
            {
                pro.CreatedAt = DateTime.Now;
            }
            db.SaveChanges();
            try
            {
                if (uploadFile != null && uploadFile.ContentLength > 0)
                {
                    int id = int.Parse(db.Products.ToList().Last().ID.ToString());
                    string fileName = "";
                    int index = uploadFile.FileName.IndexOf('.');
                    fileName = "product" + id.ToString() + "." + uploadFile.FileName.Substring(index + 1);
                    string path = Path.Combine(Server.MapPath("~/wwwroot/images/Products"), fileName);
                    uploadFile.SaveAs(path);
                    Product productAfter = db.Products.FirstOrDefault(x => x.ID == id);
                    productAfter.Image = fileName;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Products/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product pro, HttpPostedFileBase uploadFile)
        {
            Product productSelected = db.Products.FirstOrDefault(x => x.ID == pro.ID);
            

            
            try
            {
                productSelected.Name = pro.Name;
                productSelected.Price = pro.Price;
                productSelected.Quantity = pro.Quantity;
                productSelected.UpdateAt = pro.UpdateAt;
                if (String.IsNullOrEmpty(pro.CreatedAt.ToString()))
                {
                    productSelected.CreatedAt = DateTime.Now;
                }
                else
                {
                    productSelected.CreatedAt = pro.CreatedAt;
                }
                productSelected.Description = pro.Description;
                productSelected.Color = pro.Color;
                productSelected.Description = pro.Description;
                productSelected.CategoryID = pro.CategoryID;
                //Sửa ảnh:
                if (uploadFile != null && uploadFile.ContentLength > 0)
                {
                    int id = pro.ID;
                    string fileName = "";
                    int index = uploadFile.FileName.IndexOf('.');
                    fileName = "product" + id.ToString() + "." + uploadFile.FileName.Substring(index + 1);
                    string path = Path.Combine(Server.MapPath("~/wwwroot/images/Products"), fileName);
                    uploadFile.SaveAs(path);
                    productSelected.Image = fileName;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
