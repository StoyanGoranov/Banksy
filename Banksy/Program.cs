using System;

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

                Console.WriteLine(account.GetAccountHistory());


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
