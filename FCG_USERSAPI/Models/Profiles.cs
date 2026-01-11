using AutoMapper;
using FCG_USERSAPI.Models.DTO;

namespace FCG_USERSAPI.Models
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            // Mapeia DTO -> Entidade
            CreateMap<ClientDto, Client>()
                    .ForMember(dest => dest.IdClient, opt => opt.Ignore());

            CreateMap<UserDto, User>()
                    .ForMember(dest => dest.IdUser, opt => opt.Ignore());

            // (opcional) Entidade -> DTO
            CreateMap<Client, ClientDto>();
            CreateMap<User, UserDto>();
        }
    }
}
