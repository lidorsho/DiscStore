using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscStore.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            /*TODO
             * 
             */
            return new HttpStatusCodeResult(501, "err");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            /*TODO
             * 
             */
            return new HttpStatusCodeResult(501, "err");
        }
    }
}