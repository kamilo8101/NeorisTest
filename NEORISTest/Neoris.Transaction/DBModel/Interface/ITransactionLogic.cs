using Neoris.Common;
using Neoris.Transactions.DTO;

namespace Neoris.Transactions.DBModel.Interface
{
    public interface ITransactionLogic
    {
        public Task<EntityResult<TransactionDTO>> GetAll();
        public Task<EntityResult<TransactionDTO>> Create(TransactionDTO transactionDTO);
        public Task<EntityResult<TransactionDTO>> Edit(TransactionDTO transactionDTO, int id);
        public Task<EntityResult<TransactionDTO>> Delete(int id);
    }
}
