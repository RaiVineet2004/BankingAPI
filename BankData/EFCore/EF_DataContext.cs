using System;
using BankData.Model;
using Microsoft.EntityFrameworkCore;

namespace BankData.EFCore
{
	public class EF_DataContext : DbContext
	{
		public EF_DataContext(DbContextOptions<EF_DataContext> options ) : base(options) { }

		

        public DbSet<RawBankTrans> RawBankTransactions { get; set; }
        public DbSet<BankTrans> BankTransactions { get; set; }

    }
}

