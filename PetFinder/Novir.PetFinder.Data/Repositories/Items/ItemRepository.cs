using Microsoft.EntityFrameworkCore;
using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Repositories.Items
{
    public class ItemRepository : EFDataRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
