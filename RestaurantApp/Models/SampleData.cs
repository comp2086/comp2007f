/*
 * App: SuchiVille
 * File: SampleData.cs
 * Developed by: Alex Andriishyn, Anthony Scinocco, Sam Parathuvayalil Sunny, Lyka Sunesara 
 * Purpose: Data for development purposes
 */

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
			new List<Product>
			{
				new Product { ProductType="appetizer", Name="Sweet and Sour Soup", ThumbNail="/Assets/Images/Thumbnails/sweetsoursoup.jpg", FullImage="/Assets/Images/Fullimages/sweetsoursoup.jpg", ShortDesc="Short descroption", FullDesc="Full description", Price=5.25M },
				new Product { ProductType="appetizer", Name="Miso Soup", ThumbNail="/Assets/Images/Thumbnails/recipe-miso-soup-photo.png", FullImage="/Assets/Images/Fullimages/recipe-miso-soup-photo.png", ShortDesc="Short descroption", FullDesc="Full description", Price=3.78M },
				new Product { ProductType="appetizer", Name="Calamari", ThumbNail="/Assets/Images/Thumbnails/calamari.jpg", FullImage="/Assets/Images/Fullimages/calamari.jpg", ShortDesc="Short descroption", FullDesc="Full description", Price=1.78M },
				new Product { ProductType="appetizer", Name="Shrimp", ThumbNail="/Assets/Images/Thumbnails/shrimp.jpg", FullImage="/Assets/Images/Fullimages/shrimp.jpg", ShortDesc="Short descroption", FullDesc="Full description", Price=4.78M },
				new Product { ProductType="drink", Name="Water", ThumbNail="/Assets/Images/Thumbnails/water.png", FullImage="/Assets/Images/Fullimages/water.png", ShortDesc="Short descroption", FullDesc="Full description", Price=1.00M },
				new Product { ProductType="drink", Name="Tea", ThumbNail="/Assets/Images/Thumbnails/tea.jpg", FullImage="/Assets/Images/Fullimages/tea.jpg", ShortDesc="Short descroption", FullDesc="Full description", Price=4.78M },
				new Product { ProductType="drink", Name="Vodka", ThumbNail="/Assets/Images/Thumbnails/vodkaT.png", FullImage="/Assets/Images/Fullimages/vodkaF.jpg", ShortDesc="Short descroption", FullDesc="Full description", Price=14.78M },
				new Product { ProductType="drink", Name="Samogonka", ThumbNail="/Assets/Images/Thumbnails/samogonT.jpg", FullImage="/Assets/Images/Fullimages/samogonF.jpg", ShortDesc="Home made Ukrainian hooch", FullDesc="Full description", Price=14.78M },
				new Product { ProductType="maincourse", Name="Green Dragon Roll", ThumbNail="/Assets/Images/Thumbnails/greendragon.jpg", FullImage="/Assets/Images/Fullimages/greendragon.jpg", ShortDesc="Short Description", FullDesc="Full description", Price=5.00M },
				new Product { ProductType="maincourse", Name="Black Dragon Roll", ThumbNail="/Assets/Images/Thumbnails/blackdragon.jpg", FullImage="/Assets/Images/Fullimages/blackdragon.jpg", ShortDesc="Short Description", FullDesc="Full description", Price=7.00M },
				new Product { ProductType="maincourse", Name="Red Dragon Roll", ThumbNail="/Assets/Images/Thumbnails/reddragon.jpg", FullImage="/Assets/Images/Fullimages/reddragon.jpg", ShortDesc="Short Description", FullDesc="Full description", Price=3.00M },
				new Product { ProductType="maincourse", Name="Tuna Roll", ThumbNail="/Assets/Images/Thumbnails/tuna.jpg", FullImage="/Assets/Images/Fullimages/tuna.jpg", ShortDesc="Short Description", FullDesc="Full description", Price=8.50M },
				new Product { ProductType="dessert", Name="Mango", ThumbNail="/Assets/Images/Thumbnails/mango.jpg", FullImage="/Assets/Images/Fullimages/mango.jpg", ShortDesc="Short Description", FullDesc="Full description", Price=1.50M },
				new Product { ProductType="dessert", Name="Banana", ThumbNail="/Assets/Images/Thumbnails/banana.jpg", FullImage="/Assets/Images/Fullimages/banana.jpg", ShortDesc="Short Description", FullDesc="Full description", Price=5.00M },
				new Product { ProductType="dessert", Name="Cheese Cake", ThumbNail="/Assets/Images/Thumbnails/cheesecake.jpg", FullImage="/Assets/Images/Fullimages/cheesecake.jpg", ShortDesc="Short Description", FullDesc="Full description", Price=3.20M },
				new Product { ProductType="dessert", Name="Green Tea", ThumbNail="/Assets/Images/Thumbnails/greentea.jpg", FullImage="/Assets/Images/Fullimages/greentea.jpg", ShortDesc="Short descroption", FullDesc="Full description", Price=4.78M },
			}.ForEach(p => context.Products.Add(p));
			
		}
	}
}