using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantApp.Models;
using RestaurantApp.ViewModels;

namespace RestaurantApp.Controllers
{
    public class ShoppingCartController : Controller
    {
		RestaurantContext storeDB = new RestaurantContext();

		//
		// GET: /ShoppingCart/
		public ActionResult Index()
		{
			var cart = ShoppingCart.GetCart(this.HttpContext);

			// Set up our ViewModel
			var viewModel = new ShoppingCartViewModel
			{
				CartItems = cart.GetCartItems(),
				CartTotal = cart.GetTotal()
			};
			// Return the view
			return View(viewModel);
		}
		//
		// POST: /ShoppingCart/AddToCart/5
        [HttpPost]
		public ActionResult AddToCart(int id)
		{
			// Retrieve the album from the database
			var addedProduct = storeDB.Products
				.Single(product => product.ProductId == id);

			// Add it to the shopping cart
			var cart = ShoppingCart.GetCart(this.HttpContext);

            //get quantity of item
            var productQuantity = Int32.Parse(Request["productQuantity"].ToString());

			cart.AddToCart(addedProduct, productQuantity);

            // Go back to the menu page the user was previously viewing
            return Redirect(Request.UrlReferrer.ToString());
		}
		//
		// AJAX: /ShoppingCart/RemoveFromCart/5
		[HttpPost]
		public ActionResult RemoveFromCart(int id)
		{
			// Remove the item from the cart
			var cart = ShoppingCart.GetCart(this.HttpContext);

			// Get the name of the album to display confirmation
			string productName = storeDB.Carts
				.Single(item => item.RecordId == id).Product.Name;

			// Remove from cart
			int itemCount = cart.RemoveFromCart(id);

			// Display the confirmation message
			var results = new ShoppingCartRemoveViewModel
			{
				Message = Server.HtmlEncode(productName) +
					" has been removed from your shopping cart.",
				CartTotal = cart.GetTotal(),
				CartCount = cart.GetCount(),
				ItemCount = itemCount,
				DeleteId = id
			};
			return Json(results);
		}
		//
		// GET: /ShoppingCart/CartSummary
		[ChildActionOnly]
		public ActionResult CartSummary()
		{
			var cart = ShoppingCart.GetCart(this.HttpContext);

			ViewData["CartCount"] = cart.GetCount();
			return PartialView("CartSummary");
		}
	}
}