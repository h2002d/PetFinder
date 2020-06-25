using AutoMapper;
using Novir.PetFinder.Core.Dto.Items;
using Novir.PetFinder.Core.Services.Common;
using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Data.Repositories.Items;

namespace Novir.PetFinder.Core.Services.Items
{
    public class ItemService : CommonService<Item, ItemDto>, IItemService
    {
        public ItemService(IItemRepository commonRepository, IMapper mapper) : base(commonRepository, mapper)
        {
        }
    }
}
