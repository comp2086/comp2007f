using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers
{
    public class CheckoutController : Controller
    {
        private RestaurantContext storeDB = new RestaurantContext();

        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }else
            {
                ViewBag.orderError = "Please login to process your order.";
                return View("~/Views/Account/Login.cshtml");
            }
            
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            if (User.Identity.IsAuthenticated)
            {
                var order = new Order();
                TryUpdateModel(order);

                //update info
                order.Username = User.Identity.Name;
                order.OrderDate = DateTime.Now;
                order.FirstName = Request["FirstName"];
                order.LastName = Request["LastName"];
                order.Phone = Request["Phone"];
                order.PostalCode = Request["PostalCode"];
                order.State = Request["State"];

                //save order
                storeDB.Orders.Add(order);
                storeDB.SaveChanges();

                //process order
                var cart = ShoppingCart.GetCart(this.HttpContext);
                cart.CreateOrder(order);

                return RedirectToAction("Complete", new { id = order.OrderId });
            }else
            {
                ViewBag.orderError = "Please login to view your order.";
                return View("~/Views/Account/Login.cshtml");
            }
            
        }

        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(
                o => o.OrderId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

    }
}
