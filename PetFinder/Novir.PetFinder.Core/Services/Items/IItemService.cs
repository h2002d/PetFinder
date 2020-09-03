using Novir.PetFinder.Core.Dto.Common;
using Novir.PetFinder.Core.Dto.Items;
using Novir.PetFinder.Core.Services.Common;
using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novir.PetFinder.Core.Services.Items
{
    public interface IItemService : ICommonService<int, ItemDto>
    {
        Task<List<ItemDto>> GetUserItems(string userId);
        Task<PagingResultDto<ItemDto>> Search(SearchDto searchViewModel, PagingQueryDto paging);
        Task<PagingResultDto<SearchResultDto>> GetLastItems(int count);
        Task<ItemDetailDto> GetDetailsById(int id);
    }
}
