using AutoMapper;
using Novir.PetFinder.Core.Categories.Dto;
using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Mappings
{
    class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
