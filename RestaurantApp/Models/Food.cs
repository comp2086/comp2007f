﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
	public class Food
	{
		public Food() { }
		public virtual int FoodId { get; set; }
		public virtual string FoodType { get; set; }
		public virtual string Name { get; set; }
		public virtual string ThumbNail { get; set; }
		public virtual string FullImage { get; set; }
		public virtual string ShortDesc { get; set; }
		public virtual string FullDesc { get; set; }
		public virtual double Price { get; set; }
	}
}