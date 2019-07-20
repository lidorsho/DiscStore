using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DiscStore.Controllers
{
    public class LoginController : ApiController
    {
        public ActionResult Login()
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