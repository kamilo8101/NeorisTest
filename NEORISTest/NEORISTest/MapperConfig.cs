using AutoMapper;
using Neoris.User.DBModel.Tables;
using Neoris.User.DTO;

namespace Neoris.User
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ClientDTO, Client>();
            CreateMap<ClientDTO, Person>().ForPath(x => x.Client.Password, opt => opt.MapFrom(z => z.Password))
                                          .ForPath(x => x.Client.State, opt => opt.MapFrom(z => z.State));

            CreateMap<Client, ClientDTO>().ForMember(x => x.Name, opt => opt.MapFrom(z => z.Person.Name))
                                          .ForMember(x => x.Genre, opt => opt.MapFrom(z => z.Person.Genre))
                                          .ForMember(x => x.Age, opt => opt.MapFrom(z => z.Person.Age))
                                          .ForMember(x => x.Document, opt => opt.MapFrom(z => z.Person.Document))
                                          .ForMember(x => x.Address, opt => opt.MapFrom(z => z.Person.Address))
                                          .ForMember(x => x.Phone, opt => opt.MapFrom(z => z.Person.Phone));
            CreateMap<Person, ClientDTO>();
        }
    }
}
