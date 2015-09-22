namespace NUnitTests
{
    using System;     
    using Adapter;
    using NUnit.Framework;
    using Proxy;

    public class Tests
    {
        [Test]
        public void TestIronCompount()
        {
            ICompound iron = new RichCompound("Iron");
            
            Assert.That(iron.ToString(), Contains.Substring(" Fe"));
            Assert.That(iron.ToString(), Contains.Substring(" 2795"));
        }

        [Test]
        public void BankAccountWithdrawalTest()
        {
            IBankAccount account = new BankAccountProxy("John", "Snow");
            account.Withdraw(400);
            account.Deposit(200);

            Assert.AreEqual(1800, account.CurrentBalance());            
        }

        [Test]
        public void BankAccountImposibleWithdrawal()
        {
            IBankAccount account = new BankAccountProxy("John", "Snow");
            account.Withdraw(2400);

            Assert.AreEqual(2000, account.CurrentBalance());
        }

        [Test]
        public void BankAccountImposibleDeposit()
        {
            IBankAccount account = new BankAccountProxy("John", "Snow");
            account.Deposit(2400);

            Assert.AreEqual(2000, account.CurrentBalance());
        }
    }
}
