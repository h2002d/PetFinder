using AutoMapper;
using Novir.PetFinder.Core.Categories.Dto;
using Novir.PetFinder.Core.Dto;
using Novir.PetFinder.Core.Services.Common;
using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Data.Repositories.Categories;
using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Services.Categories
{
    public class CategoryService : CommonService<Category, CategoryDto>, ICategoryService
    {
        public CategoryService(ICategoryRepository commonRepository, IMapper mapper) :
            base(commonRepository, mapper)
        {
        }
    }
}
