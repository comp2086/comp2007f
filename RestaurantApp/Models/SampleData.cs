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
				new Product { ProductType="appetizer", Name="Sweet and Sour Soup", ThumbNail="/Assets/Images/Thumbnails/sweetsoursoup.jpg", FullImage="/Assets/Images/Fullimages/sweetsoursoup.jpg", ShortDesc="Short descroption", FullDesc="Full description", Price=5.25 },
			}.ForEach(p => context.Products.Add(p));
			
		}
	}
}