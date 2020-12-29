using System;
using System.Collections.Generic;
using System.Text;
using Humanizer;

namespace BankLibrary
{
    public class Transaction
    {
        public bool Positive { get; }
        public decimal Amount { get; }
        public string AmountForHumans { 
            get 
            {
                decimal whole;
                decimal decim;
                whole = (int)Amount;
                decim = (Amount % 1)*100;
                
                if (decim == 0)
                {
                    return $"{((int)whole).ToWords()} dollars";
                }
                else
                {
                    return  $"{((int)whole).ToWords()} dollars and {((int)decim).ToWords()} cents" ;
                }
                
                   
               // return ((double)Amount).toWords;
            } 
        }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction (bool positive,decimal amount, DateTime date, string note)
        {
            this.Positive = positive;
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }
    }
}
