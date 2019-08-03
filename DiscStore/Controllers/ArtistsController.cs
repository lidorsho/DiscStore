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
    public class ArtistsController : Controller
    {
        private DiscStoreContext db = new DiscStoreContext();

        // GET: Artists
        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                return View(db.Artists.ToList());
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
                return View(db.Artists.ToList());
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }

        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            if (User.IsInRole("admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Artist artist = db.Artists.Find(id);
                if (artist == null)
                {
                    return HttpNotFound();
                }
                return View(artist);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // GET: Artists/Create
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

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistID,Name,Age,Location,Language,ImgPath")] Artist artist)
        {
            if (User.IsInRole("admin"))
            {
                if (ModelState.IsValid)
                {
                    db.Artists.Add(artist);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(artist);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.IsInRole("admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Artist artist = db.Artists.Find(id);
                if (artist == null)
                {
                    return HttpNotFound();
                }
                return View(artist);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistID,Name,Age,Location,Language,ImgPath")] Artist artist)
        {
            if (User.IsInRole("admin"))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(artist).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(artist);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (User.IsInRole("admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Artist artist = db.Artists.Find(id);
                if (artist == null)
                {
                    return HttpNotFound();
                }
                return View(artist);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.IsInRole("admin"))
            {
                Artist artist = db.Artists.Find(id);
                db.Artists.Remove(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
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
