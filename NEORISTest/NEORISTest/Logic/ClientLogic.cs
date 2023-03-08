using AutoMapper;
using Neoris.Common;
using Neoris.User.DBModel.Interface;
using Neoris.User.DBModel.Tables;
using Neoris.User.DTO;

namespace Neoris.User.Logic
{
    public class ClientLogic : IClientLogic
    {
        private IClientManager _clientManager;

        private readonly IConfiguration _configuration;

        private readonly IMapper _mapper;
        //private readonly IRepository<Client> _client;
        public ClientLogic(IClientManager clientManager, IMapper mapper, IConfiguration configuration)
        {
            _clientManager = clientManager;
            _mapper = mapper;
            _configuration = configuration; 
            //_client = clien;
        }

        public async Task<EntityResult<ClientDTO>> Create(ClientDTO clientDTO)
        {
            Person person = _mapper.Map<ClientDTO, Person>(clientDTO);
            EntityResult<Person> result = await _clientManager.NewClient(person);
            if (result.IsCorrect)
                return new EntityResult<ClientDTO>(clientDTO);
            else
                return new EntityResult<ClientDTO>("El cliente no fue creado");
        }
        public async Task<EntityResult<ClientDTO>> Edit(ClientDTO clientDTO, int id)
        {
            EntityResult<Person> result = await _clientManager.GetPerson(x => x.Id == id);
            if(result.IsCorrect && result.SimpleObject == null)
                return new EntityResult<ClientDTO>("No se encuentra ese cliente");
            Person person = result.SimpleObject;
            person.Name = clientDTO.Name;
            person.Genre = clientDTO.Genre;
            person.Age = clientDTO.Age;
            person.Document = clientDTO.Document;
            person.Address = clientDTO.Address;
            person.Phone = clientDTO.Phone;
            person.Client.Password = clientDTO.Password;
            person.Client.State = clientDTO.State;

            return await _clientManager.EditClient(person);
        }

        public async Task<EntityResult<ClientDTO>> Delete(int id)
        {
            EntityResult<Client> result = await _clientManager.GetClient(x => x.Id == id);
            if (result.IsCorrect && result.SimpleObject != null)
                return await _clientManager.DeleteClient(result.SimpleObject);
            else
                return new EntityResult<ClientDTO>("No se encuentra ese cliente");
        }


        public async Task<EntityResult<ClientDTO>> GetAll()
        {
            EntityResult<Client> result = await _clientManager.GetAll();
            if (result.IsCorrect && result.DataList.Any())
                return new EntityResult<ClientDTO> { DataList = _mapper.Map<List<Client>, List<ClientDTO>>(result.DataList.ToList()) };
            else
                return new EntityResult<ClientDTO>("No se encontraron datos");
        }
    }
}
