using AutoMapper;
using Novir.PetFinder.Core.Dto.Dictionaries;
using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Novir.PetFinder.Core.Mappings
{
    public class DictionaryProfile : Profile
    {
        public DictionaryProfile()
        {
            CreateMap<ColorDto, Color>();
            CreateMap<Color, ColorDto>().ForMember(dest => dest.Name, opt => opt
    .MapFrom(src => (src.Id > 0 && CultureInfo.CurrentCulture.Name.Equals("ru-RU")) ? src.Name_RU
    : (src.Id > 0 && CultureInfo.CurrentCulture.Name.Equals("en-US") ? src.Name_EN : src.Name))); 

            CreateMap<CityDto, City>();
            CreateMap<City, CityDto>().ForMember(dest => dest.Name, opt => opt
    .MapFrom(src => (src.Id > 0 && CultureInfo.CurrentCulture.Name.Equals("ru-RU")) ? src.Name_RU
    : (src.Id > 0 && CultureInfo.CurrentCulture.Name.Equals("en-US") ? src.Name_EN : src.Name)));

        }
    }
}
