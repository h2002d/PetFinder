using Novir.PetFinder.Data.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novir.PetFinder.Data.Repositories.Common
{
    public interface ICommonRepository<TKey, T> where T : class, new()
    {
        Task<T> GetById(TKey id);

        Task<Tuple<bool, T>> TryGetById(TKey id);

        Task<List<T>> ListAll();

        Task<PagingResult<T>> ListAll(PagingQuery query);

        Task<T> GetSingleBySpec(ISpecification<T> spec);

        Task<List<T>> List(ISpecification<T> spec);

        Task<T> Add(T entity);

        Task Update(T entity);

        Task Delete(TKey id);
    }
}
