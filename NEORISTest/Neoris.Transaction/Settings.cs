using Neoris.Transactions.DBModel.Interface;
using Neoris.Transactions.DBModel.Manager;
using Neoris.Transactions.Logic;

namespace Neoris.Transactions
{
    public static class Settings
    {
        public static void AddScopes(this IServiceCollection services)
        {
            services.AddTransient<ITransactionLogic, TransactionLogic>();
            services.AddTransient<ITransactionManager, TransactionManager>();

        }
    }
}
