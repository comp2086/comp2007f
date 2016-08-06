/*
 * App: SuchiVille
 * File: Appetizer.cs
 * Developed by: Alex Andriishyn, Anthony Scinocco, Sam Parathuvayalil Sunny, Lyka Sunesara 
 * Purpose: Appetizer model
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
	public class Appetizer
	{
		public Appetizer() { }
		public virtual int AppetizerId { get; set; }
		public virtual string Name { get; set; }
		public virtual string ThumbNail { get; set; }
		public virtual string FullImage { get; set; }
		public virtual string ShortDesc { get; set; }
		public virtual string FullDesc { get; set; }
		public virtual double Price { get; set; }
	}
}