using AutoMapper;
using Novir.PetFinder.Core.Dto.Dictionaries;
using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Mappings
{
    public class DictionaryProfile : Profile
    {
        public DictionaryProfile()
        {
            CreateMap<ColorDto, Color>();
            CreateMap<Color, ColorDto>();
        }
    }
}
