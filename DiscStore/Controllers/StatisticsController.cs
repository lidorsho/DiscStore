using DiscStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscStore.Controllers
{
    public class StatisticsController : Controller
    {
        private DiscStoreContext db = new DiscStoreContext();

        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrdersByGenre()
        {
            var ordersByGenre = db.Orders.Join(db.Discs,
                o => o.DiscID,
                d => d.DiscID,
                (order, disc) => new
                {
                    ordID = order.ID,
                    gnrID = disc.GenreID
                })
                .Join(db.Genres,
                o => o.gnrID,
                g => g.GenreID,
                (order, genre) => new
                {
                    ordID = order.ordID,
                    GenreName = genre.GenreName
                })
                .GroupBy(o => new { o.GenreName })
                .Select(o => new
                {
                    name = o.Key.GenreName,
                    value = o.Count()
                })
                .OrderBy(o => o.value);
            var ordersCount = new List<int>();
            var genres = new List<string>();

            ordersByGenre.ToList().ForEach((item) =>
            {
                ordersCount.Add(item.value);
                genres.Add(item.name);
            });
            return Json(new { ordersCount = ordersCount, genres = genres, data = ordersByGenre}, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDiscsBygenre()
        {
            var discsBygenre = db.Discs.Join(db.Genres,
                o => o.GenreID,
                d => d.GenreID,
                (disc, genre) => new
                {
                    discName = disc.Name,
                    genreName = genre.GenreName
                })
                .GroupBy(g => new { g.genreName })
                .Select(g => new
                {
                    name = g.Key.genreName,
                    value = g.Count()
                })
                .OrderBy(d => d.value);
            var discsCount = new List<int>();
            var genres = new List<string>();
            discsBygenre.ToList().ForEach((item) =>
            {
                discsCount.Add(item.value);
                genres.Add(item.name);
            });
            return Json(new { discsCount = discsCount, genres = genres, data = discsBygenre}, JsonRequestBehavior.AllowGet);
        }
    }
} 