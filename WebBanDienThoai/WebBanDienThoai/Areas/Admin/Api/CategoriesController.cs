﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Areas.Admin.Api
{
    [EnableCors(origins: "https://localhost:44305/", headers: "*", methods: "*")]

    public class CategoriesController : ApiController
    {
        ShopMobileDbContext db = new ShopMobileDbContext();

        // GET: api/Categories
        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        [HttpGet]
        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.ID)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [HttpPost]
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (String.IsNullOrEmpty(category.CreatedAt.ToString()))
            {
                category.CreatedAt = DateTime.Now;
            }
            db.Categories.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.ID }, category);
        }

        
        // DELETE: api/Categories/5
        [HttpDelete]
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.ID == id) > 0;
        }
    }
}