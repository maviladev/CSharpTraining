﻿using System;
namespace BudgetManagement.Models
{
	public class AccountType
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int Order { get; set; }

        public AccountType()
		{
		}
	}
}

