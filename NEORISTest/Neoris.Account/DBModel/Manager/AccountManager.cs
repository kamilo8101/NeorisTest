using Microsoft.EntityFrameworkCore;
using Neoris.Accounts.DBModel.Interface;
using Neoris.Accounts.DBModel.Tables;
using Neoris.Accounts.DTO;
using Neoris.Common;
using System.Linq.Expressions;

namespace Neoris.Accounts.DBModel.Manager
{
    public class AccountManager : IAccountManager
    {
        private Neoris_Context _context;

        public AccountManager(Neoris_Context context)
        {
            _context = context;
        }

        public async Task<EntityResult<Account>> NewAccount(Account account)
        {
            _context.Account.Add(account);
            await _context.SaveChangesAsync();
            return new EntityResult<Account>();
        }
        public async Task<EntityResult<AccountDTO>> EditAccount(Account account)
        {
            _context.Attach(account);
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new EntityResult<AccountDTO>();
        }
        public async Task<EntityResult<AccountDTO>> DeleteAccount(Account account)
        {
            _context.Account.Remove(account);
            await _context.SaveChangesAsync();
            return new EntityResult<AccountDTO>();
        }


        public async Task<EntityResult<Account>> GetAccount(Expression<Func<Account, bool>> function)
        {
            return new EntityResult<Account> { SimpleObject = await _context.Account.Where(function).FirstOrDefaultAsync() };
        }

        public async Task<EntityResult<Account>> GetAll()
        {
            return new EntityResult<Account> { DataList = await _context.Account.ToListAsync() };
        }
    }
}
