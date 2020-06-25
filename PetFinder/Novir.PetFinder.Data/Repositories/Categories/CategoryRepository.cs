using Microsoft.EntityFrameworkCore;
using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Repositories.Categories
{
    public class CategoryRepository : EFDataRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
