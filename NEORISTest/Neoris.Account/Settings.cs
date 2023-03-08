using Neoris.Accounts.DBModel.Interface;
using Neoris.Accounts.DBModel.Manager;
using Neoris.Accounts.Logic;

namespace Neoris.Accounts
{
    public static class Settings
    {
        public static void AddScopes(this IServiceCollection services) 
        {
            services.AddTransient<IAccountLogic, AccountLogic>();
            services.AddTransient<IAccountManager, AccountManager>();
        
        }

    }
}
