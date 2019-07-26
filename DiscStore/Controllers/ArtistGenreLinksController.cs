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
    public class ArtistGenreLinksController : Controller
    {
        private DiscStoreContext db = new DiscStoreContext();

        // GET: ArtistGenreLinks
        public ActionResult Index()
        {
            var artistGenreLinks = db.ArtistGenreLinks.Include(a => a.Artists).Include(a => a.Genres);
            return View(artistGenreLinks.ToList());
        }

        // GET: ArtistGenreLinks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistGenreLink artistGenreLink = db.ArtistGenreLinks.Find(id);
            if (artistGenreLink == null)
            {
                return HttpNotFound();
            }
            return View(artistGenreLink);
        }

        // GET: ArtistGenreLinks/Create
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name");
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName");
            return View();
        }

        // POST: ArtistGenreLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LinkID,GenreID,ArtistID")] ArtistGenreLink artistGenreLink)
        {
            if (ModelState.IsValid)
            {
                db.ArtistGenreLinks.Add(artistGenreLink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", artistGenreLink.ArtistID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", artistGenreLink.GenreID);
            return View(artistGenreLink);
        }

        // GET: ArtistGenreLinks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistGenreLink artistGenreLink = db.ArtistGenreLinks.Find(id);
            if (artistGenreLink == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", artistGenreLink.ArtistID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", artistGenreLink.GenreID);
            return View(artistGenreLink);
        }

        // POST: ArtistGenreLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LinkID,GenreID,ArtistID")] ArtistGenreLink artistGenreLink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artistGenreLink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", artistGenreLink.ArtistID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", artistGenreLink.GenreID);
            return View(artistGenreLink);
        }

        // GET: ArtistGenreLinks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistGenreLink artistGenreLink = db.ArtistGenreLinks.Find(id);
            if (artistGenreLink == null)
            {
                return HttpNotFound();
            }
            return View(artistGenreLink);
        }

        // POST: ArtistGenreLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtistGenreLink artistGenreLink = db.ArtistGenreLinks.Find(id);
            db.ArtistGenreLinks.Remove(artistGenreLink);
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
