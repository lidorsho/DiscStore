using DiscStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscStore.Controllers
{
    public class SuggestionsController : Controller
    {
        private DiscStoreContext db = new DiscStoreContext();
        // GET: Suggestions
        public ActionResult Index()
        {
            int userId = (int)Session["UserID"];
            var lastOrderDisc = db.Orders.Where(x => x.UserID == userId)
                .OrderBy(x => x.OrderDate)
                .Select(o => new { DiscID = o.DiscID }).ToList().Last();

            var lastDiscGenre = db.Discs.Where(x => x.DiscID == lastOrderDisc.DiscID)
                .Select(x => new { genreId = x.GenreID }).ToList().Last();

            var lastDiscArtist = db.Discs.Where(x => x.DiscID == lastOrderDisc.DiscID)
                .Select(x => new { artistID = x.ArtistID }).ToList().Last();

            var recommendedDiscs = db.Discs.Where(x => x.GenreID == lastDiscGenre.genreId || x.ArtistID == lastDiscArtist.artistID).ToList();


            return View(recommendedDiscs);
        }
    }
}