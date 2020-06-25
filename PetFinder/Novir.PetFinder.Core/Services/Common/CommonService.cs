using AutoMapper;
using Novir.PetFinder.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novir.PetFinder.Core.Services.Common
{
    public abstract class CommonService<TEntity, TDto> : IDataService<TDto>
        where TEntity : FinderDatabaseEntity, new()
        where TDto : class, new()
    {
        #region
        private readonly IDataRepository<TEntity> _commonRepository;
        private readonly IMapper _mapper;

        public CommonService(IDataRepository<TEntity> commonRepository, IMapper mapper)
        {
            _commonRepository = commonRepository;
            _mapper = mapper;
        }
        #endregion

        public async Task<TDto> Add(TDto dto)
        {
            if (dto == null) return null;

            var recordToAdd = _mapper.Map<TEntity>(dto);
            return _mapper.Map<TDto>(await _commonRepository.Add(recordToAdd));
        }

        public async Task Update(TDto dto)
        {
            await _commonRepository.Update(_mapper.Map<TEntity>(dto));
        }

        public async Task<TDto> GetById(int id)
            => _mapper.Map<TDto>(await _commonRepository.GetById(id));

        public async Task<List<TDto>> ListAll()
            => _mapper.Map<List<TDto>>(await _commonRepository.ListAll());

        public async Task Delete(int id)
        {
            await _commonRepository.Delete(id);
        }
    }
}
