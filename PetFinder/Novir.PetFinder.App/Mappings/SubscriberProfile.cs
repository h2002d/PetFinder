using AutoMapper;
using Novir.PetFinder.App.ViewModels.Home;
using Novir.PetFinder.Core.Dto.Subsribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.PetFinder.App.Mappings
{
    public class SubscriberProfile : Profile
    {
        public SubscriberProfile() 
        { 
        CreateMap<SubscriberDto, SubscriberViewModel>();
        CreateMap<SubscriberViewModel, SubscriberDto>();
        }
    }
}
