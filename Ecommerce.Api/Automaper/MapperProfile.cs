using AutoMapper;
using Ecommerce.Entities.Models;
using Ecommerce.Shared;

namespace Ecommerce.Api;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserDto>().ForMember(e => e.Id, opts => opts.MapFrom(e => e.Id));
        CreateMap<User, UserForRegisterDto>().ReverseMap();
    }
}
