using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using baith17be2024.Models;

namespace baith17be2024.Controllers
{
    public class ProductVariantsController : Controller
    {
        private Model1 db = new Model1();

        // GET: ProductVariants
        public ActionResult Index()
        {
            var productVariants = db.ProductVariants.Include(p => p.Product);
            return View(productVariants.ToList());
        }

        // GET: ProductVariants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVariant productVariant = db.ProductVariants.Find(id);
            if (productVariant == null)
            {
                return HttpNotFound();
            }
            return View(productVariant);
        }

        // GET: ProductVariants/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "SanPhamId", "ProductName");
            return View();
        }

        // POST: ProductVariants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVariant emp)
        {
            try
            {
                db.ProductVariants.Add(emp);
                db.SaveChanges();
                return Json(new { result = true, JsonRequestBehavior.AllowGet });

            }
            catch (Exception er)
            {
                return Json(new { result = false, error = er.Message });

            }
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "VariantId,ProductId,ScreenSize,RAM,Storage,CPU,Color,Price")] ProductVariant productVariant)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ProductVariants.Add(productVariant);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ProductId = new SelectList(db.Products, "SanPhamId", "ProductName", productVariant.ProductId);
        //    return View(productVariant);
        //}

        // GET: ProductVariants/Edit/5


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVariant productVariant = db.ProductVariants.Find(id);
            if (productVariant == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "SanPhamId", "ProductName", productVariant.ProductId);
            return View(productVariant);
        }

        // POST: ProductVariants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VariantId,ProductId,ScreenSize,RAM,Storage,CPU,Color,Price")] ProductVariant productVariant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productVariant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "SanPhamId", "ProductName", productVariant.ProductId);
            return View(productVariant);
        }

        // GET: ProductVariants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVariant productVariant = db.ProductVariants.Find(id);
            if (productVariant == null)
            {
                return HttpNotFound();
            }
            return View(productVariant);
        }

        // POST: ProductVariants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductVariant productVariant = db.ProductVariants.Find(id);
            db.ProductVariants.Remove(productVariant);
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
