using DiscStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private DiscStoreContext db = new DiscStoreContext();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View("Index", (List<Disc>)Session["UserOrder"]);
        }

        public ActionResult Checkout()
        {
            return View("Checkout", db.Stores.ToList());
        }

        [HttpPost]
        public ActionResult DeleteDisc(int discID, string actionName)
        {
            List<Disc> myOrders = (List<Disc>)Session["UserOrder"];

            if (discID != null)
            {
                var itemToRemove = myOrders.FirstOrDefault(r => r.DiscID == discID);
                myOrders.Remove(itemToRemove);
            }

            Session["UserOrder"] = myOrders;

            return RedirectToAction(actionName);
        }

        [HttpPost]
        public ActionResult GetTotalPrice()
        {
            double totalPrice = 0;
            ((List<Disc>)Session["UserOrder"]).ForEach(x => totalPrice += x.Price);
            return Json(totalPrice);
        }

        [HttpPost]
        public ActionResult GetUserName()
        {
            int userId = (int)Session["UserID"];
            string name = db.Users.Where(x => x.UserID == userId).Select(x => x.UserName).ToList()[0];
            return Json(name);
        }

        public ActionResult SaveOrder(int store)
        {
            Dictionary<int, Order> newOrderItems = new Dictionary<int, Order>();
            int userId = (int)Session["UserID"];

            List<Disc> orderDiscs = (List<Disc>)Session["UserOrder"];
            Session["UserOrder"] = null;

            // Get the next ID
            int nextId = db.Orders.ToList().Count + 1;

            foreach (Disc item in orderDiscs)
            {
                Order newOrderRow = new Order()
                {
                    ID = nextId,
                    OrderID = nextId,
                    UserID = userId,
                    OrderDate = DateTime.Now,
                    DiscID = item.DiscID,
                    StoreID = store
                };

                newOrderItems.Add(item.DiscID, newOrderRow);
                nextId++;
            }


            newOrderItems.Values.ToList().ForEach(orderRow =>
            {
                db.Orders.Add(orderRow);
                db.SaveChanges();
            });

            return View("Completed");
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