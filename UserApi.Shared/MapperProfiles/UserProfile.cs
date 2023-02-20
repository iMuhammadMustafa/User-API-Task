﻿using AutoMapper;
using User_API.Domain;
using User_API.UserApi.Domain.DTOs;

namespace User_API.UserApi.Shared.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, PostUserDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
