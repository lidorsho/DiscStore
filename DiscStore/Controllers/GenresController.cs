using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiscStore.Models;
using Microsoft.AspNet.Identity;

namespace DiscStore.Controllers
{
    public class GenresController : Controller
    {
        private DiscStoreContext db = new DiscStoreContext();

        // GET: Genres
        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                return View(db.Genres.ToList());
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
                return View(db.Genres.ToList());
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }

        }

        // GET: Genres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // GET: Genres/Create
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

        // POST: Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreID,GenreName,Description")] Genre genre)
        {
            if (User.IsInRole("admin"))
            {
                if (ModelState.IsValid)
                {
                    db.Genres.Add(genre);
                    db.SaveChanges();
                    return RedirectToAction("Manage");
                }
                return View(genre);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.IsInRole("admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Genre genre = db.Genres.Find(id);
                if (genre == null)
                {
                    return HttpNotFound();
                }
                return View(genre);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreID,GenreName,Description")] Genre genre)
        {
            if (User.IsInRole("admin"))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(genre).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Manage");
                }
                return View(genre);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (User.IsInRole("admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Genre genre = db.Genres.Find(id);
                if (genre == null)
                {
                    return HttpNotFound();
                }
                return View(genre);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.IsInRole("admin"))
            {
                Genre genre = db.Genres.Find(id);
                db.Genres.Remove(genre);
                db.SaveChanges();
                return RedirectToAction("Manage");
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
