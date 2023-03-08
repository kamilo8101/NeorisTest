using Microsoft.EntityFrameworkCore;
using Neoris.Common;
using Neoris.Transactions.DBModel.Interface;
using Neoris.Transactions.DBModel.Tables;
using Neoris.Transactions.DTO;
using System.Linq.Expressions;

namespace Neoris.Transactions.DBModel.Manager
{
    public class TransactionManager : ITransactionManager
    {
        private Neoris_Context _context;

        public TransactionManager(Neoris_Context context)
        {
            _context = context;
        }

        public async Task<EntityResult<Transaction>> NewTransaction(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            await _context.SaveChangesAsync();
            return new EntityResult<Transaction>();
        }
        public async Task<EntityResult<TransactionDTO>> EditTransaction(Transaction transaction)
        {
            _context.Attach(transaction);
            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new EntityResult<TransactionDTO>();
        }
        public async Task<EntityResult<TransactionDTO>> DeleteTransaction(Transaction transaction)
        {
            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();
            return new EntityResult<TransactionDTO>();
        }


        public async Task<EntityResult<Transaction>> GetTransaction(Expression<Func<Transaction, bool>> function)
        {
            return new EntityResult<Transaction> { SimpleObject = await _context.Transaction.Where(function).FirstOrDefaultAsync() };
        }

        public async Task<EntityResult<Transaction>> GetAll()
        {
            return new EntityResult<Transaction> { DataList = await _context.Transaction.ToListAsync() };
        }
    }
}
