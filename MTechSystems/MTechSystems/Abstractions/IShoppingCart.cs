using System;
using System.Collections.Generic;

namespace MTechSystems.Abstractions
{
	public interface IShoppingCart
	{
		DateTime PurchaseDate { get; }
		List<IItem> ItemList { get; set; }
		double PurchaseTotal { get; set; }

		void AddItem(IItem item);
		bool DoPurchase();
		int GetItemListCount();
		double GetPurchaseTotal();
	}
}

