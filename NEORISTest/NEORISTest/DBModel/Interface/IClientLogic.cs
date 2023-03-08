using Neoris.Common;
using Neoris.User.DTO;

namespace Neoris.User.DBModel.Interface
{
    public interface IClientLogic  
    {
        public Task<EntityResult<ClientDTO>> GetAll();
        public Task<EntityResult<ClientDTO>> Create(ClientDTO clientDTO);
        public Task<EntityResult<ClientDTO>> Edit(ClientDTO clientDTO, int id);
        public Task<EntityResult<ClientDTO>> Delete(int id);

    }
}
