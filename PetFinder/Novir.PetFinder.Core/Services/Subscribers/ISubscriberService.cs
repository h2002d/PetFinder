using System;
using System.Collections.Generic;
using System.Text;
using Novir.PetFinder.Core.Services.Common;
using Novir.PetFinder.Core.Dto.Items;
using Novir.PetFinder.Core.Dto.Subsribers;

namespace Novir.PetFinder.Core.Services.Subscribers
{
    public interface ISubscriberService: ICommonService<int, SubscriberDto>
    {
    }
}
