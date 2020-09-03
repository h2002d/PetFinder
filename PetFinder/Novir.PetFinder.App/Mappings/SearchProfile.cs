using AutoMapper;
using Novir.PetFinder.App.ViewModels.Items;
using Novir.PetFinder.Core.Dto.Common;
using Novir.PetFinder.Core.Dto.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.PetFinder.App.Mappings
{
    public class SearchProfile : Profile
    {
        public SearchProfile()
        {
            CreateMap<SearchDto, SearchViewModel>();
            CreateMap<SearchViewModel, SearchDto>();
            CreateMap<SearchResultDto, SearchResultViewModel>();
            CreateMap<SearchResultViewModel, SearchResultDto>();
            CreateMap(typeof(PagingResultDto<>), typeof(PagingResultDto<>));
        }
    }
}
