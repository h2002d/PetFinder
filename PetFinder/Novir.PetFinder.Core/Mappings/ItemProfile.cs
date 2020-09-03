using AutoMapper;
using Novir.PetFinder.Core.Dto.Items;
using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Mappings
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item,ItemDto>();
            CreateMap<ItemDto,Item>();

            CreateMap<ItemDetailDto, Item>();
            CreateMap<Item, ItemDetailDto>();

            CreateMap<ItemImageDto, ItemImage>();
            CreateMap<ItemImage, ItemImageDto>();


            CreateMap<SearchResultDto, Item>();
            CreateMap<Item, SearchResultDto>();
        }
    }
}
