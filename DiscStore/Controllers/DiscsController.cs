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


        public ActionResult Index()
        {
            return RedirectToAction("Manage");
        }
        public ActionResult Manage()
        {
            if (User.IsInRole("admin"))
            {
                var discs = db.Discs.Include(d => d.Artists).Include(d => d.Genres);
                return View(discs.ToList());
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        public List<Disc> Filter(int artistID)
        {
            return db.Discs.Where(disc => disc.Artists.ArtistID == artistID).ToList<Disc>();
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
            if (User.IsInRole("admin"))
            {
                ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name");
                ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName");
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // POST: Discs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiscID,Name,ArtistID,GenreID,Price,IssueDate,ImgPath")] Disc disc)
        {
            if (User.IsInRole("admin"))
            {
                if (ModelState.IsValid)
                {
                    db.Discs.Add(disc);
                    db.SaveChanges();
                    return RedirectToAction("Manage");
                }

                ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", disc.ArtistID);
                ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", disc.GenreID);
                return View(disc);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        [HttpPost]
        public ActionResult AddDisc(int discID, string actionName)
        {
            Disc disc = db.Discs.Include("Artists").Include("Genres").First(a => a.DiscID == discID);
            if (Session["UserOrder"] != null)
                {
                    List<Disc> myOrders = (List<Disc>)Session["UserOrder"];
                    myOrders.Add(disc);
                    Session["UserOrder"] = myOrders;
                }
                else
                {
                    Session["UserOrder"] = new List<Disc> { disc };
                }

            return RedirectToAction(actionName);
        }

        [HttpPost]
        public ActionResult DelItem(Disc item, string actionName)
        {
            var itemToDelete = db.Discs.Where(x => x.DiscID == item.DiscID).FirstOrDefault();
            db.Discs.Remove(itemToDelete);
            db.SaveChanges();

            return RedirectToAction(actionName);
        }

        // GET: Discs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.IsInRole("admin"))
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
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // POST: Discs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiscID,Name,ArtistID,GenreID,Price,IssueDate,ImgPath")] Disc disc)
        {
            if (User.IsInRole("admin"))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(disc).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Manage");
                }
                ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", disc.ArtistID);
                ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", disc.GenreID);
                return View(disc);
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // GET: Discs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (User.IsInRole("admin"))
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
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        // POST: Discs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.IsInRole("admin"))
            {
                Disc disc = db.Discs.Find(id);
                db.Discs.Remove(disc);
                db.SaveChanges();
                return RedirectToAction("Manage");
            }
            else
            {
                return new HttpStatusCodeResult(403, "Forbidden!");
            }
        }

        public ActionResult GetPopDiscs(string artist,  int? maxPrice, string name)
        {
            return View("Index", FilterData("Pop", artist, maxPrice, name));
        }

        public ActionResult GetJazzDiscs(string artist,  int? maxPrice, string name)
        {
            return View("Index", FilterData("Jazz", artist, maxPrice, name));
        }

        public ActionResult GetHipHopDiscs(string artist,  int? maxPrice, string name)
        {
            return View("Index", FilterData("HipHop", artist, maxPrice, name));
        }

        public ActionResult GetRockDiscs(string artist,  int? maxPrice, string name)
        {
            return View("Index", FilterData("Rock", artist, maxPrice, name));
        }

        public ActionResult GetDiscs(string ganner = null, string artist = null, int? maxPrice = null, string name = null)
        {
          return View("Index", FilterData(ganner, artist, maxPrice, name));
        }

        private List<Disc> FilterData(string ganner, string artist,  int? maxPrice, string name)
        {
            var _discs = db.Discs.Where(x => true);

            if (name != null && name != "")
            {
                _discs = _discs.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            }

            if (ganner != null && ganner != "")
            {
                _discs = _discs.Where(x => x.Genres.GenreName == ganner);
            }

            if (artist != null && artist != "")
            {
                //artist = artist.ToLower();
                _discs = _discs.Where(x => x.Artists.Name.ToLower().Contains(artist.ToLower()));
            }

            if (maxPrice.HasValue)
            {
                _discs = _discs.Where(x => x.Price <= maxPrice);
            }
            

            return _discs.ToList();
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
