using AutoMapper;
using Novir.PetFinder.Core.Categories.Dto;
using Novir.PetFinder.App.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.PetFinder.App.Mappings
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, CategoryViewModel>();
            CreateMap<CategoryViewModel, CategoryDto>();
        }
    }
}
