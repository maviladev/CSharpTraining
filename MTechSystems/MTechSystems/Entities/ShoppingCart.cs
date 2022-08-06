using System;
using System.Collections.Generic;
using MTechSystems.Abstractions;

namespace MTechSystems.Entities
{
	public class ShoppingCart : IShoppingCart
	{
		public DateTime PurchaseDate { get; private set; }
		public List<IItem> ItemList { get; set; }
		public double PurchaseTotal { get; set; }

		public ShoppingCart()
		{
			PurchaseDate = DateTime.Now;
			ItemList = new List<IItem>();
		}

		public void AddItem(IItem item)
		{
			ItemList.Add(item);
		}

		public bool DoPurchase()
		{
			return true;
		}

		public int GetItemListCount()
		{
			return 0;
		}

		public double GetPurchaseTotal()
		{
			return 0;
		}
	}
}

