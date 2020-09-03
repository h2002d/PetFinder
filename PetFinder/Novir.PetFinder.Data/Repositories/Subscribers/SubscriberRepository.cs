using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Repositories.Subscribers
{
    public class SubscriberRepository : EFDataRepository<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
