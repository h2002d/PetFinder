using AutoMapper;
using Novir.PetFinder.Core.Dto.Items;
using Novir.PetFinder.Core.Services.Common;
using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Data.Repositories.Common;
using Novir.PetFinder.Data.Repositories.Items;
using Novir.PetFinder.Data.Specifications.ItemSpecifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novir.PetFinder.Core.Services.Items
{
    public class ItemImageService : CommonService<ItemImage, ItemImageDto>, IItemImageService
    {
        IItemImageRepository _commonRepository;
        IMapper _mapper;
        public ItemImageService(IItemImageRepository commonRepository, IMapper mapper) : base(commonRepository, mapper)
        {
            _commonRepository = commonRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ItemImageDto>> GetImageByItemId(int itemId)
        {
            var list = await _commonRepository.List(new ItemImageByIdSpecification(itemId));
            return _mapper.Map<IReadOnlyList<ItemImageDto>>(list);
        }
    }
}
