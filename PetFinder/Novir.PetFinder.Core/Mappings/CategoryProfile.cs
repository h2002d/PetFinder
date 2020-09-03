using AutoMapper;
using Novir.PetFinder.Core.Categories.Dto;
using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Novir.PetFinder.Core.Mappings
{
    class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            var info = CultureInfo.CurrentCulture;
            CreateMap<CategoryDto, Category>();
            //CreateMap<Category, CategoryDto>().ForMember(dest => dest.Name, opt =>
            //{
            //    opt.PreCondition(src => src.Id > 0 && (info.Name == "en-US"));
            //    opt.MapFrom(s => s.Name_EN);
            //});



            CreateMap<Category, CategoryDto>().ForMember(dest => dest.Name, opt => opt
    .MapFrom(src => (src.Id > 0 && CultureInfo.CurrentCulture.Name.Equals("ru-RU")) ? src.Name_RU
    : (src.Id > 0 && CultureInfo.CurrentCulture.Name.Equals("en-US") ? src.Name_EN : src.Name)));
            //CreateMap<Category, CategoryDto>().ForMember(dest => dest.Name, opt =>
            //{
            //    opt.PreCondition(src => src.Id > 0 && (info.Name == "ru-RU"));
            //    opt.MapFrom(s => s.Name_RU);
            //});

        }
    }
}
