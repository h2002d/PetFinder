using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Repositories.Common
{
    public abstract class EFDataRepository<T> : CommonRepository<int, T>, IDataRepository<T> where T : FinderDatabaseEntity, new()
    {
        protected EFDataRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
