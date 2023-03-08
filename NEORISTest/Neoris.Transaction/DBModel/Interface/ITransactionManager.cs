using Neoris.Common;
using Neoris.Transactions.DBModel.Tables;
using Neoris.Transactions.DTO;
using System.Linq.Expressions;

namespace Neoris.Transactions.DBModel.Interface
{
    public interface ITransactionManager
    {
        public Task<EntityResult<Transaction>> NewTransaction(Transaction transaction);
        public Task<EntityResult<TransactionDTO>> EditTransaction(Transaction transaction);
        public Task<EntityResult<TransactionDTO>> DeleteTransaction(Transaction transaction);
        public Task<EntityResult<Transaction>> GetTransaction(Expression<Func<Transaction, bool>> function);
        public Task<EntityResult<Transaction>> GetAll();
    }
}
