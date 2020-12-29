using System;
using Xunit;
using BankLibrary;

namespace BanksyTests
{
    public class BasicTests
    {
        [Fact]
        public void NeedMoneyToStart()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new BankAccount("invalid", -50)
                );
        }
        [Fact]
        public void CantTakeMoreThanYouHave()
        {
            BankAccount account = new BankAccount("Krum", 10000);
            Assert.Throws<InvalidOperationException>(

                ()=> account.MakeWithdrawal(100000, DateTime.Now, "Attempt to overdraw")
                );
        }
    }
}
