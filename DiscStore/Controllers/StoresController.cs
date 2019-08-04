using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiscStore.Models;

namespace DiscStore.Controllers
{
    public class StoresController : Controller
    {
        private DiscStoreContext db = new DiscStoreContext();

        // GET: Stores
        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                return View(db.Stores.ToList());
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }
        public ActionResult Manage()
        {
            if (User.IsInRole("admin"))
            {
                return View(db.Stores.ToList());
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            if (User.IsInRole("admin"))
            {
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,LocationLongitude,LocationLatitude")] Store store)
        {
            if (User.IsInRole("admin"))
            {
                if (ModelState.IsValid)
                {
                    db.Stores.Add(store);
                    db.SaveChanges();
                    return RedirectToAction("Manage");
                }

                return View(store);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.IsInRole("admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Store store = db.Stores.Find(id);
                if (store == null)
                {
                    return HttpNotFound();
                }
                return View(store);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,LocationLongitude,LocationLatitude")] Store store)
        {
            if (User.IsInRole("admin"))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(store).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(store);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (User.IsInRole("admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Store store = db.Stores.Find(id);
                if (store == null)
                {
                    return HttpNotFound();
                }
                return View(store);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
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
