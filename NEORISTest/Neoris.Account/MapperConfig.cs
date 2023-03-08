using AutoMapper;
using Neoris.Accounts.DBModel.Tables;
using Neoris.Accounts.DTO;

namespace Neoris.Accounts
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AccountDTO, Account>();
            CreateMap<Account, AccountDTO>();

        }
    }
}
