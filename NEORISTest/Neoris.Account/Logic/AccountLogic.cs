using AutoMapper;
using Neoris.Accounts.DBModel.Interface;
using Neoris.Accounts.DBModel.Tables;
using Neoris.Accounts.DTO;
using Neoris.Common;

namespace Neoris.Accounts.Logic
{
    public class AccountLogic : IAccountLogic
    {
        private IAccountManager _accountManager;

        private readonly IConfiguration _configuration;

        private readonly IMapper _mapper;
        public AccountLogic(IAccountManager accountManager, IMapper mapper, IConfiguration configuration)
        {
            _accountManager = accountManager;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<EntityResult<AccountDTO>> Create(AccountDTO accountDTO)
        {
            Account account = _mapper.Map<AccountDTO, Account>(accountDTO);
            EntityResult<Account> result = await _accountManager.NewAccount(account);
            if (result.IsCorrect)
                return new EntityResult<AccountDTO>();
            else
                return new EntityResult<AccountDTO>("la cuenta no fue creado");
        }

        public async Task<EntityResult<AccountDTO>> Delete(int id)
        {
            EntityResult<Account> result = await _accountManager.GetAccount(x => x.Id == id);
            if (result.IsCorrect && result.SimpleObject != null)
                return await _accountManager.DeleteAccount(result.SimpleObject);
            else
                return new EntityResult<AccountDTO>("No se encontraron datos");
        }

        public async Task<EntityResult<AccountDTO>> Edit(AccountDTO accountDTO, int id)
        {
            EntityResult<Account> result = await _accountManager.GetAccount(x => x.Id == id);
            Account account = result.SimpleObject;
            account.Account_Number = accountDTO.Account_Number;
            account.Account_Type = accountDTO.Account_Type;
            account.Initial_Amount = accountDTO.Initial_Amount;
            account.State = accountDTO.State;

            return await _accountManager.EditAccount(account);
        }

        public async Task<EntityResult<AccountDTO>> GetAll()
        {
            EntityResult<Account> result = await _accountManager.GetAll();
            if (result.IsCorrect && result.DataList.Any())
                return new EntityResult<AccountDTO> { DataList = _mapper.Map<List<Account>, List<AccountDTO>>(result.DataList.ToList()) };
            else
                return new EntityResult<AccountDTO>("No se encontraron datos");
        }
    }
}
