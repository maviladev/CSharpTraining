using System;
using MTechSystems.Abstractions;

namespace MTechSystems.Entities
{
	public class Item : IItem
	{
		public string Name { get; set; }
		public int Amount { get; set; }
		public double Price { get; set; }
	}
}

