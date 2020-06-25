using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novir.PetFinder.Core.Services.Common
{
    public interface ICommonService<TKey, TDto>
        where TDto : class, new()
    {
        Task<TDto> GetById(TKey id);

        Task<List<TDto>> ListAll();

        Task<TDto> Add(TDto dto);

        Task Update(TDto dto);
        Task Delete(int id);
    }
}
