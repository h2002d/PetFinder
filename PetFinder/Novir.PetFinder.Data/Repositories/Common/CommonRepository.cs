using Microsoft.EntityFrameworkCore;
using Novir.PetFinder.Data.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novir.PetFinder.Data.Repositories.Common
{
    public abstract class CommonRepository<TKey, T> : ICommonRepository<TKey, T>
        where T : FinderDatabaseEntity, new()
    {
        protected readonly DbContext _appDbContext;

        protected CommonRepository(DbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public virtual async Task<T> GetById(TKey id)
        {
            return await _appDbContext.Set<T>().FindAsync(id);
        }

        public async Task<Tuple<bool, T>> TryGetById(TKey id)
        {
            var entity = await GetById(id);
            return new Tuple<bool, T>(entity != null, entity);
        }

        public async Task<T> GetByKeyValues(params object[] keyValues)
            => await _appDbContext.Set<T>().FindAsync(keyValues);

        public async Task<List<T>> ListAll()
        {
            var model = await _appDbContext.Set<T>().ToListAsync();
            return model;
        }

        public async Task<PagingResult<T>> ListAll(PagingQuery query)
        {
            IQueryable<T> queryable = _appDbContext.Set<T>().AsNoTracking();

            int toalItemsCount = await queryable.CountAsync();

            var items = await queryable.OrderByDescending(x=>x.Id).Skip((query.Page - 1) * query.ItemsPerPage)
                                .Take(query.ItemsPerPage)
                                .ToListAsync();

            return new PagingResult<T>() { TotalItems = toalItemsCount, Items = items };
        }

        public async Task<T> GetSingleBySpec(ISpecification<T> spec)
        {
            var result = await List(spec);
            return result.FirstOrDefault();
        }

        public async Task<List<T>> List(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_appDbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            var res = await secondaryResult.Where(spec.Criteria).ToListAsync();
            return res.OrderByDescending(x=>x.Id).ToList();
        }


        public async Task<PagingResult<T>> List(ISpecification<T> spec, PagingQuery query)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_appDbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));
            // return the result of the query using the specification's criteria expression
            var queryable = secondaryResult.Where(spec.Criteria).OrderByDescending(x=>x.Id);

            int toalItemsCount = await queryable.CountAsync();
            //int totalPages = Convert.ToInt32(Math.Round(Convert.ToDecimal(toalItemsCount / query.ItemsPerPage), 
            //    MidpointRounding.AwayFromZero));
            int totalPages = toalItemsCount / query.ItemsPerPage;
            if (toalItemsCount % query.ItemsPerPage > 0)
                totalPages++;
            var items = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                .Take(query.ItemsPerPage).ToListAsync();

            return new PagingResult<T>() { TotalItems = toalItemsCount, TotalPages = totalPages, Items = items };
        }

        public async Task<T> Add(T entity)
        {
            //var result = _appDbContext.Set<T>().Add(entity);
            //await _appDbContext.SaveChangesAsync();

            // ToDo: Vakkhtang - after checking correctness of code remove this comment
            // this code is here to handle concurrency conflicts in Entity Framework Core
            // approach called "client wins"
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T> result = null;
            try
            {
                result = _appDbContext.Set<T>().Add(entity);
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                entry.OriginalValues.SetValues(entry.GetDatabaseValuesAsync().ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.Entity;
        }

        public async Task Update(T entity)
        {
            //_appDbContext.Entry(entity).State = EntityState.Modified;
            //await _appDbContext.SaveChangesAsync();

            // ToDo: Vakkhtang - after checking correctness of code remove this comment
            // this code is here to handle concurrency conflicts in Entity Framework Core
            // approach called "client wins"
            try
            {
                _appDbContext.Entry(entity).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                entry.OriginalValues.SetValues(entry.GetDatabaseValuesAsync().ConfigureAwait(false));
            }
        }

        public async Task Delete(TKey id)
        {
            var ent = _appDbContext.Set<T>().Find(id);
            _appDbContext.Set<T>().Remove(ent);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
