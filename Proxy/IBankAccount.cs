namespace Proxy
{
    using System;

    public interface IBankAccount
    {
        bool Deposit(decimal amount);

        bool Withdraw(decimal amount);

        decimal CurrentBalance();
    }
}
