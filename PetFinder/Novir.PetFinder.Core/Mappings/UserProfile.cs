using AutoMapper;
using Novir.PetFinder.Core.Dto.Users;
using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, UserEntity>();
            CreateMap<UserEntity, UserDto>();
        }
    }
}
