using Neoris.Accounts.DTO;
using Neoris.Common;

namespace Neoris.Accounts.DBModel.Interface
{
    public interface IAccountLogic  
    {
        public Task<EntityResult<AccountDTO>> GetAll();
        public Task<EntityResult<AccountDTO>> Create(AccountDTO accountDTO);
        public Task<EntityResult<AccountDTO>> Edit(AccountDTO accountDTO, int id);
        public Task<EntityResult<AccountDTO>> Delete(int id);

    }
}
