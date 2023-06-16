using AutoMapper;
using Bazar.Api.Services;
using Bazar.Core.DTOs;
using Bazar.Core.Models;

namespace Bazar.Api.Helpers;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        CreateMap<RegisterUserRequestDto, User>()
            .ForMember(des =>
                des.Password, opt =>
                opt.Ignore());

        CreateMap<User, RegisterUserResponseDto>();
        
        CreateMap<User, LoginUserResponseDto>();
    }
}