using AutoMapper;
using Neoris.Transactions.DBModel.Tables;
using Neoris.Transactions.DTO;

namespace Neoris.Transactions
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {   
            CreateMap<TransactionDTO, Transaction>();
            CreateMap<Transaction, TransactionDTO>();
        }
    }
}
