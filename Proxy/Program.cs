namespace Proxy
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            IBankAccount account = new BankAccountProxy("John", "Snow");
            DisplayBallance(account);
            Withdraw(400, account);
            Withdraw(120, account);
            Withdraw(65, account);
            DisplayBallance(account);
            Deposit(150, account);
            DisplayBallance(account);
        }

        private static void DisplayBallance(IBankAccount account)
        {
            Console.WriteLine("{0:C}", account.CurrentBalance());
        }

        private static void Withdraw(decimal amount, IBankAccount account)
        {
            if (account.Withdraw(amount))
            {
                Console.WriteLine("Withdrawal complete: {0:C}", amount);
            }
        }

        private static void Deposit(decimal amount, IBankAccount account)
        {
            if (account.Deposit(amount))
            {
                Console.WriteLine("Deposit complete: {0:C}", amount);
            }
        }
    }
}
