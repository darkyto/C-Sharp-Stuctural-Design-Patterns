namespace Proxy
{
    using System;
    using System.Collections.Generic;

    public class BankAccount : IBankAccount
    {
        public BankAccount()
        {
            this.Balance = 2000;
        }

        private decimal Balance { get; set; }

        public bool Deposit(decimal amount)
        {
            // Try to deposit
            // Do some validations
            this.Balance += amount;

            return true;
        }

        public bool Withdraw(decimal amount)
        {
            // Try to withdraw
            // Do some validations
            // Do some more validations :)
            this.Balance -= amount;

            return true;
        }

        public decimal CurrentBalance()
        {
            // Se the account balance
            // Do some validations
            return this.Balance;
        }      
    }
}
