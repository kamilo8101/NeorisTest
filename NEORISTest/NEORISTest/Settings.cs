using Neoris.User.DBModel.Interface;
using Neoris.User.DBModel.Manager;
using Neoris.User.Logic;

namespace Neoris.User
{
    public static class Settings
    {
        public static void AddScopes(this IServiceCollection services) 
        {
            services.AddTransient<IClientLogic, ClientLogic>();
            services.AddTransient<IClientManager, ClientManager>();
        
        }

    }
}
