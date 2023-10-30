using System;
using System.ComponentModel.DataAnnotations;

namespace BankData.Model
{
	public class BankTrans
	{
        [Key]
        public int TransactionID { get; set; }

        public int AccountNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        public string? TransactionType { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }
    }
}

