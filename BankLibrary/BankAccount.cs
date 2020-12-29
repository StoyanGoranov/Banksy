using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Number = accountNumberSeed.ToString();

            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");

            accountNumberSeed++;
        }

        public void MakeDeposit( decimal amount, DateTime date, string note, bool positive = true) 
        {
            if (!positive)
            {
                throw new ArgumentOutOfRangeException(nameof(positive), "Deposit must increase amount");
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(positive, amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal( decimal amount, DateTime date, string note, bool positive = false) 
        {
            if (positive)
            {
                throw new ArgumentOutOfRangeException(nameof(positive), "Withdrawal must decrease amount");
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(positive, amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory(bool toText = false)
        {
            var report = new StringBuilder();
            
            //Header
            report.AppendLine("Date\t\t\tNote\t\tAmount");
            foreach (var item in allTransactions)
            {
                string operationSign = "-";
                if (item.Positive)
                {
                    operationSign = "+";
                }
                //ROWS
                if (!toText)
                {
                    report.AppendLine($"{item.Date}\t{item.Notes}\t{operationSign} {item.Amount}");
                }
                else
                {
                    string additionalSpace = "";
                    if(item.Notes.Length < 8)
                    {
                        additionalSpace = "\t";
                    }
                    report.AppendLine($"{item.Date}\t{item.Notes}{additionalSpace}\t{operationSign} {item.AmountForHumans}");
                    //report.AppendLine($"{item.Date}\t{operationSign}{item.Amount}\t\t{item.Notes}");
                }
                

            }
            return report.ToString();
        }
    }
}
