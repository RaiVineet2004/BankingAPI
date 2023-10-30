using System;
using BankData.EFCore;

namespace BankData.Model
{
	public class DbHelper
	{
		private EF_DataContext _context;

		public DbHelper(EF_DataContext context)
		{
			_context = context;
		}

        // servers the purpose of Get

        public List<RawBankTrans> GetRawBankTrans()
		{
			List<RawBankTrans> response = new List<RawBankTrans>();
			var dataList = _context.RawBankTransactions.ToList();
			dataList.ForEach(row => response.Add(new RawBankTrans()
			{
				Id = row.Id,
                AccountNumber = row.AccountNumber,
				Balance= row.Balance,
				Date = row.Date,
				Amount = row.Amount,
				Narration = row.Narration
			})); 
			return response;
		}
        // servers the purpose of get Request
        public List<BankTrans> GetBankTrans()
        {
            List<BankTrans> response = new List<BankTrans>();
            var dataList = _context.BankTransactions.ToList();
            dataList.ForEach(row => response.Add(new BankTrans()
            {
                TransactionID = row.TransactionID,
                AccountNumber = row.AccountNumber,
                Balance = row.Balance,
                TransactionDate = row.TransactionDate,
                Amount = row.Amount,
                TransactionType = row.TransactionType
            }));
            return response;
        }
        // This method is intended to handle both update (PUT) and insert (POST) operations.

        public void SaveBankTran(RawBankTrans rawBankTrans)
        {
            if (rawBankTrans == null)
            {
                throw new ArgumentNullException(nameof(rawBankTrans), "rawBankTrans is null.");
            }

            if (rawBankTrans.Id > 0)
            {
                // Update (PUT)
                var dbTable = _context.RawBankTransactions.Find(rawBankTrans.Id);

                if (dbTable != null)
                {
                    // Update properties
                    dbTable.AccountNumber = rawBankTrans.AccountNumber;
                    dbTable.Amount = rawBankTrans.Amount;
                    dbTable.Balance = rawBankTrans.Balance;
                    dbTable.Date = rawBankTrans.Date;
                    dbTable.Narration = rawBankTrans.Narration;

                    // Call SaveChanges after updates
                    _context.SaveChanges();
                }
                else
                {
                    // Handle the case when dbTable is not found, such as by throwing an exception.
                   
                }
            }
            else
            {
                // Insert (POST)
                var dbTable = new RawBankTrans
                {
                    AccountNumber = rawBankTrans.AccountNumber,
                    Amount = rawBankTrans.Amount,
                    Balance = rawBankTrans.Balance,
                    Date = rawBankTrans.Date,
                    Narration = rawBankTrans.Narration
                };

                // Add the new entity to the context.
                _context.RawBankTransactions.Add(dbTable);

                // Call SaveChanges to insert the new entity.
                _context.SaveChanges();
            }
        }


        // Servers the purpose of Delete
        public void DeleteBankTran(int id)
        {
            var rawBankTrans = _context.RawBankTransactions.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (rawBankTrans != null)
            {
                _context.RawBankTransactions.Remove(rawBankTrans);
                _context.SaveChanges();
            }
        }


    }
}

