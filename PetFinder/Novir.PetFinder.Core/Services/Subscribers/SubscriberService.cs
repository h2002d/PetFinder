using System;
using System.Collections.Generic;
using System.Text;
using Novir.PetFinder.Core.Services.Common;
using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Core.Dto.Subsribers;
using Novir.PetFinder.Data.Repositories.Common;
using AutoMapper;
using Novir.PetFinder.Data.Repositories.Subscribers;

namespace Novir.PetFinder.Core.Services.Subscribers
{
    public class SubscriberService : CommonService<Subscriber, SubscriberDto>, ISubscriberService
    {
        public SubscriberService(ISubscriberRepository commonRepository, IMapper mapper) 
            : base(commonRepository, mapper)
        {
        }
    }
}
