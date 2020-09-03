using AutoMapper;
using Novir.PetFinder.Core.Dto.Subsribers;
using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Mappings
{
    class SuscriberProfile : Profile
    {
        public SuscriberProfile()
        {
            CreateMap<Subscriber, SubscriberDto>();
            CreateMap<SubscriberDto, Subscriber>();
        }
    }
}