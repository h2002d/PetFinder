using Novir.PetFinder.Core.Categories.Dto;
using Novir.PetFinder.Core.Dto;
using Novir.PetFinder.Core.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Services.Categories
{
    public interface ICategoryService : ICommonService<int, CategoryDto>
    {
    }
}
