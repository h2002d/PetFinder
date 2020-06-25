using AutoMapper;
using Novir.PetFinder.App.ViewModels.Users;
using Novir.PetFinder.Core.Dto.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.PetFinder.App.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, UserViewModel>();
            CreateMap<UserViewModel, UserDto>();
        }
    }
}
