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

        public ActionResult GetOrdersByGanre()
        {
            var ordersByGanredb = db.Orders.Join(db.Discs,
                o => o.DiscID,
                d => d.DiscID,
                (order, disc) => new
                {
                    ordID = order.OrderID,
                    gnrID = disc.GenreID
                })
                .Join(db.Genres,
                o => o.gnrID,
                g => g.GenreID,
                (order, ganre) => new
                {
                    ordID = order.ordID,
                    GenreName = ganre.GenreName
                })
                .GroupBy(o => new { o.GenreName })
                .Select(o => new { ganreName = o.Key, ordersCount = o.Count() });
            return Json(new { ordersByGanredb = ordersByGanredb }, JsonRequestBehavior.AllowGet); ;
        }
        public ActionResult GetDiscsByGanre()
        {
            var discsByGanre = db.Discs.Join(db.Genres,
                o => o.GenreID,
                d => d.GenreID,
                (disc, ganre) => new
                {
                    discName = disc.Name,
                    ganreName = ganre.GenreName
                })
                .GroupBy(g => new { g.ganreName })
                .Select(g => new {ganreName = g.Key,discCount = g.Count()});
            return Json(new { discsByGanre = discsByGanre }, JsonRequestBehavior.AllowGet); ;
        }
    }
}