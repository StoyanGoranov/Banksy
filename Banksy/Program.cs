using System;
using BankLibrary;
using Humanizer;

namespace Banksy
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BankAccount account = new BankAccount("Krum", 10000);
                Console.WriteLine($"Account {account.Number} was created for {account.Owner} with ${account.Balance}.");

                account.MakeWithdrawal(59.99m, DateTime.Now, "Seeds");
                account.MakeWithdrawal(9.99m, DateTime.Now, "Tea");
                account.MakeWithdrawal(5.00m, DateTime.Now, "Ham");
                account.MakeWithdrawal(18.19m, DateTime.Now, "Cake");
                account.MakeWithdrawal(12.35m, DateTime.Now, "Hammock");
                account.MakeWithdrawal(22.99m, DateTime.Now, "Tribestan");
                account.MakeDeposit(300m, DateTime.Now, "Salary");

                Console.WriteLine(account.GetAccountHistory(true));


            } 
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught trying to deposit/withdraw negative amount");
                Console.WriteLine(e.ToString());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }    
            
        }
    }
}
