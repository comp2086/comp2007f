using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Web.Security;
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
                try
                {
                    //send email confirmation to user
                    SmtpClient smtpClient = new SmtpClient("smtp.mailgun.org");
                    smtpClient.Credentials = new System.Net.NetworkCredential("postmaster@sandbox65ef3467a31b49f095da21a242685ccd.mailgun.org", "961e1cc53fff29a55bd82962b021b6c8");
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;
                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress("no-reply@sushiville.ca", "Sushi Ville");
                    //connection to db times out here sometimes, but usually works
                    mail.To.Add(new MailAddress(Membership.GetUser(User.Identity.Name).Email));
                    smtpClient.Send(mail);
                }
                catch
                {
                    Console.Write("ERROR: Email not sent");
                }
                
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
