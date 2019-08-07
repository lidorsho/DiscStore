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
            return View(db.Discs.ToList());
        }
    }
}