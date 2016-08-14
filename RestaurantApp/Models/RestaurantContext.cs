/*
 * App: SuchiVille
 * File: RestaurantContext.cs
 * Developed by: Alex Andriishyn, Anthony Scinocco, Sam Parathuvayalil Sunny, Lyka Sunesara 
 * Purpose: DbContext file
 */

namespace RestaurantApp.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class RestaurantContext : DbContext
	{
		public RestaurantContext()
			: base("name=DevelopmentConn")
		{

		}
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Cart> Carts { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<OrderDetail> OrderDetails { get; set; }
	}
}
