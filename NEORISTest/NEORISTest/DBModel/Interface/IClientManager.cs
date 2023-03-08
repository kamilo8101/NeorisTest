using Neoris.Common;
using Neoris.User.DBModel.Tables;
using Neoris.User.DTO;
using System.Linq.Expressions;

namespace Neoris.User.DBModel.Interface
{
    public interface IClientManager
    {
        public Task<EntityResult<Person>> NewClient(Person person);
        public Task<EntityResult<ClientDTO>> EditClient(Person person);
        public Task<EntityResult<ClientDTO>> DeleteClient(Client client);
        public Task<EntityResult<Client>> GetClient(Expression<Func<Client, bool>> function);
        public Task<EntityResult<Person>> GetPerson(Expression<Func<Person, bool>> function);
        public Task<EntityResult<Client>> GetAll();

    }
}
