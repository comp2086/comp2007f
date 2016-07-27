using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RestaurantApp.Models
{
	public class SampleData : DropCreateDatabaseIfModelChanges<RestaurantContext>
	{
		protected override void Seed(RestaurantContext context)
		{
			// Can be initialized with all its props (fullDesc, shortDesc, etc)
			var Drinks = new List<Drink>
			{
				new Drink { Name = "VODKA", ThumbNail = "~/Content/Images/vodkaT.png" }
			};
		}
	}
}