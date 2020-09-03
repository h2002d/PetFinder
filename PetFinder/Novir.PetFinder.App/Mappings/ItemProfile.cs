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
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemDto, ItemViewModel>();
            CreateMap<ItemViewModel, ItemDto>();

            CreateMap<ItemDetailDto, ItemDetailViewModel>();
            CreateMap<ItemDetailViewModel, ItemDetailDto>();
            CreateMap<ItemDto, SearchResultViewModel>();
            CreateMap<SearchResultViewModel, ItemDto>();
            CreateMap<PagingResultDto<ItemDto>, PagingResultDto<SearchResultViewModel>>();
            CreateMap<PagingResultDto<SearchResultViewModel>, PagingResultDto<ItemDto>>();


        }
    }
}
