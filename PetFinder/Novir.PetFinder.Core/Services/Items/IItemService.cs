using Novir.PetFinder.Core.Dto.Items;
using Novir.PetFinder.Core.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Services.Items
{
    public interface IItemService : ICommonService<int, ItemDto>
    {
    }
}
