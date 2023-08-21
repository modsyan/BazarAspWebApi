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
        CreateMap<User, UserResponseDto>();


        //PRODUCTS
        CreateMap<CreateEditProductRequestDto, Product>();
        CreateMap<Product, ProductDetailResponseDto>();
        CreateMap<Product, ProductResponseDto>();

        //POSTS
        CreateMap<CreateEditPostRequestDto, Post>();
        CreateMap<Post, PostResponseDto>();
        CreateMap<Post, PostDetailResponseDto>();

        //FAQS

        // Addresses
        CreateMap<IEnumerable<Address>, IEnumerable<AddressDto>>().IncludeAllDerived();
        CreateMap<IEnumerable<AddressDto>, IEnumerable<Address>>().IncludeAllDerived();
        CreateMap<Address, AddressDto>();
        CreateMap<AddressDto, Address>();
    }
}