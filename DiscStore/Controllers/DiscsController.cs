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
    public class DiscsController : Controller
    {
        private DiscStoreContext db = new DiscStoreContext();

        // GET: Discs
        public ActionResult Index()
        {
            var discs = db.Discs.Include(d => d.Artists).Include(d => d.Genres);
            return View(discs.ToList());
        }

        // GET: Discs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disc disc = db.Discs.Find(id);
            if (disc == null)
            {
                return HttpNotFound();
            }
            return View(disc);
        }

        // GET: Discs/Create
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name");
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName");
            return View();
        }

        // POST: Discs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiscID,Name,ArtistID,GenreID,Price,IssueDate,ImgPath")] Disc disc)
        {
            if (ModelState.IsValid)
            {
                db.Discs.Add(disc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", disc.ArtistID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", disc.GenreID);
            return View(disc);
        }

        // GET: Discs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disc disc = db.Discs.Find(id);
            if (disc == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", disc.ArtistID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", disc.GenreID);
            return View(disc);
        }

        // POST: Discs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiscID,Name,ArtistID,GenreID,Price,IssueDate,ImgPath")] Disc disc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", disc.ArtistID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", disc.GenreID);
            return View(disc);
        }

        // GET: Discs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disc disc = db.Discs.Find(id);
            if (disc == null)
            {
                return HttpNotFound();
            }
            return View(disc);
        }

        // POST: Discs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disc disc = db.Discs.Find(id);
            db.Discs.Remove(disc);
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
