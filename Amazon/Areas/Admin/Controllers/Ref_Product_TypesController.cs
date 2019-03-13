using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Amazon.EntityFramework;

namespace Amazon.Areas.Admin.Controllers
{
    public class Ref_Product_TypesController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/Ref_Product_Types
        public ActionResult Index()
        {
            return View(db.Ref_Product_Types.ToList());
        }

        // GET: Admin/Ref_Product_Types/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Product_Types ref_Product_Types = db.Ref_Product_Types.Find(id);
            if (ref_Product_Types == null)
            {
                return HttpNotFound();
            }
            return View(ref_Product_Types);
        }

        // GET: Admin/Ref_Product_Types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Ref_Product_Types/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_type_code,product_type_description")] Ref_Product_Types ref_Product_Types)
        {
            if (ModelState.IsValid)
            {
                db.Ref_Product_Types.Add(ref_Product_Types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ref_Product_Types);
        }

        // GET: Admin/Ref_Product_Types/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Product_Types ref_Product_Types = db.Ref_Product_Types.Find(id);
            if (ref_Product_Types == null)
            {
                return HttpNotFound();
            }
            return View(ref_Product_Types);
        }

        // POST: Admin/Ref_Product_Types/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_type_code,product_type_description")] Ref_Product_Types ref_Product_Types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Product_Types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ref_Product_Types);
        }

        // GET: Admin/Ref_Product_Types/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ref_Product_Types ref_Product_Types = db.Ref_Product_Types.Find(id);
            if (ref_Product_Types == null)
            {
                return HttpNotFound();
            }
            return View(ref_Product_Types);
        }

        // POST: Admin/Ref_Product_Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ref_Product_Types ref_Product_Types = db.Ref_Product_Types.Find(id);
            db.Ref_Product_Types.Remove(ref_Product_Types);
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
