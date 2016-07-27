﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
	public class Drink
	{
		public Drink() { }
		public virtual int DrinkId { get; set; }
		public virtual string Name { get; set; }
		public virtual string ShortDesc { get; set; }
		public virtual string FullDesc { get; set; }
		public virtual double Price { get; set; }
	}
}