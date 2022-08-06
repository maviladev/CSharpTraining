using System;
namespace MTechSystems.Abstractions
{
	public interface IItem
	{
		string Name { get; set; }
		int Amount { get; set; }
		double Price { get; set; }
	}
}

