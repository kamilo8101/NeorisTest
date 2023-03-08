using Neoris.Accounts.DBModel.Tables;
using Neoris.Accounts.DTO;
using Neoris.Common;
using System.Linq.Expressions;

namespace Neoris.Accounts.DBModel.Interface
{
    public interface IAccountManager
    {
        public Task<EntityResult<Account>> NewAccount(Account account);
        public Task<EntityResult<AccountDTO>> EditAccount(Account account);
        public Task<EntityResult<AccountDTO>> DeleteAccount(Account account);
        public Task<EntityResult<Account>> GetAccount(Expression<Func<Account, bool>> function);
        public Task<EntityResult<Account>> GetAll();

    }
}
