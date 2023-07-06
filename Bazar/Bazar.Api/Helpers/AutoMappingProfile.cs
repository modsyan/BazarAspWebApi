using AutoMapper;
using Bazar.Api.Services;
using Bazar.Core.DTOs;
using Bazar.Core.Models;

namespace Bazar.Api.Helpers;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        CreateMap<RegisterUserRequestDto, User>();
            // .ForMember(user =>
            //     user.PasswordHash, opt =>
            //     opt.Ignore());

        CreateMap<User, RegisterUserResponseDto>();
        
        CreateMap<User, LoginUserResponseDto>();

        CreateMap<CreateProductRequestDto, Product>();
        CreateMap<Product, CreateProductResponseDto>();
    }
}