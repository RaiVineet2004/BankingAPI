using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankData.EFCore
{
    [Table("Bank_Transaction")]
    public class BankTransaction
    {

        [Key,Required]
        public int TransactionID { get; set; }

        public int AccountNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        public string? TransactionType { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }
    }
}
