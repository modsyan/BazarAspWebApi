using AutoMapper;
using Bazar.Api.Services;
using Bazar.Core.DTOs;
using Bazar.Core.Entities;
using Bazar.Core.Models;

namespace Bazar.Api.Helpers;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        //USER
        CreateMap<RegisterUserRequestDto, User>();
        CreateMap<User, RegisterUserResponseDto>();
        CreateMap<User, LoginUserResponseDto>();
        CreateMap<User, GetUserMinimalResponseDto>();


        //PRODUCTS
        CreateMap<CreateProductRequestDto, Product>();
        CreateMap<Product, CreateProductResponseDto>();

        //POSTS
        CreateMap<CreateEditPostRequestDto, Post>();
        CreateMap<Post, CreateEditPostResponseDto>();
        CreateMap<Post, GetPostResponseDto>();

        //FAQS

        // Addresses
        CreateMap<IEnumerable<Address>, IEnumerable<AddressDto>>().IncludeAllDerived();
        CreateMap<IEnumerable<AddressDto>, IEnumerable<Address>>().IncludeAllDerived();
        CreateMap<Address, AddressDto>();
        CreateMap<AddressDto, Address>();
    }
}