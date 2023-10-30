using System;
using System.ComponentModel.DataAnnotations;

namespace BankData.Model
{
	public class RawBankTrans
	{
        [Key,Required]
        public int Id { get; set; } // This is the primary key

        public int AccountNumber { get; set; }

        public DateTime Date { get; set; }

        public string? Narration { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }
    }
}

