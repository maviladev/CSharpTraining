using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class BankAccount
    {
        public int Balance { get; set; }
        private readonly IGeneralLogger _logger;
        public BankAccount(IGeneralLogger logger) 
        {
            Balance = 0;
            _logger = logger;
        }

        public bool Deposit(int amount) 
        {
            _logger.Message($"Deposit of {amount} pesos");

            Balance += amount;
            return true;
        }

        public bool Withdrawal(int amount)
        {
            if (amount <= Balance)
            {
                _logger.LogDatabase($"Withdrawal amount {amount}");
                Balance -= amount;
                return true;
            }
            return _logger.LogBalanceAfterWithdrawal(Balance - amount);
        }

        public int GetBalance() 
        {
            return Balance;
        }
    }

}
