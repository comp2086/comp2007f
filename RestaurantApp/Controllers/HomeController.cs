using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu(string item = "Main-Course")
        {
            ViewBag.Message = "Our Refreshments";

            if(item == "Appetizer")
            {
                return View("~/Views/MenuItems/Appetizer.cshtml");
            }
            else if(item == "Main-Course")
            {
                return View("~/Views/MenuItems/MainCourse.cshtml");
            }
            else if(item == "Desert")
            {
                return View("~/Views/MenuItems/Desert.cshtml");
            }
            else if(item == "Drink")
            {
                return View("~/Views/MenuItems/Drink.cshtml");
            }

            return View("~/Views/MenuItems/MainCourse.cshtml");
        }

        public ActionResult Contact()
        { 
            return View();
        }
    }
}