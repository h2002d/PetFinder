using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Repositories.Dictionaries
{
    public class CityRepository : EFDataRepository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
