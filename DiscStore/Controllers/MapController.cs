using DiscStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscStore.Controllers
{
    public class MapController : Controller
    {
        private DiscStoreContext db = new DiscStoreContext();

        // GET: Map
        public ActionResult Index()
        {
            return View();
        }

        public string GetStores()
        {
            List<Store> StoresJson = new List<Store>();

            // Run over all the stores
            foreach (Store curr in db.Stores)
            {
                // Adding the current store
                StoresJson.Add(curr);
            }

            return JsonConvert.SerializeObject(StoresJson);
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