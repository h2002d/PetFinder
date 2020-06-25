using Novir.PetFinder.Core.Dto.Items;
using Novir.PetFinder.Core.Services.Common;
using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novir.PetFinder.Core.Services.Items
{
    public interface IItemImageService : ICommonService<int, ItemImageDto>
    {
        Task<IReadOnlyList<ItemImageDto>> GetImageByItemId(int itemId);
    }
}
