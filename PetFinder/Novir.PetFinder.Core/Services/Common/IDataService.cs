using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Services.Common
{
    public interface IDataService<TDto> : ICommonService<int, TDto>
      where TDto : class, new()
    {
    }
}
