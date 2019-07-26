using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiscStore.Models;
using System.Security.Claims;


namespace DiscStore.Controllers
{
    public class LoginController : Controller
    {
        private DiscStoreContext db = new DiscStoreContext();

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            var user = db.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();

            if (user != null)
            {
                SignIn(userName, user.isAdmin);
                Session["UserID"] = user.UserID;
                return Json(new { Success = true });
            }
            else
            {
                return new HttpStatusCodeResult(410, "Unable to find user.");
            }
        }

        private void SignIn(string userName, bool isAdmin)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userName));

            claims.Add(new Claim(ClaimTypes.Role, isAdmin ? "admin" : "user"));
            var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(id);
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