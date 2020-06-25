using AutoMapper;
using Novir.PetFinder.App.ViewModels.Items;
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
            CreateMap<ItemDto,ItemViewModel>();
            CreateMap<ItemViewModel, ItemDto>();
        }
    }
}
