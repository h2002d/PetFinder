using AutoMapper;
using Novir.PetFinder.Core.Dto.Common;
using Novir.PetFinder.Core.Dto.Items;
using Novir.PetFinder.Core.Services.Common;
using Novir.PetFinder.Core.Services.Dictionaries;
using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Data.Repositories.Common;
using Novir.PetFinder.Data.Repositories.Items;
using Novir.PetFinder.Data.Specifications.ItemSpecifications;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Novir.PetFinder.Core.Categories.Dto;
using Novir.PetFinder.Core.Services.Categories;
using Microsoft.AspNetCore.Identity;

namespace Novir.PetFinder.Core.Services.Items
{
    public class ItemService : CommonService<Item, ItemDto>, IItemService
    {
        private readonly IItemRepository _commonRepository;
        //private readonly ICityService _cityService;
        //private readonly IColorService _colorService;
        //private readonly IItemImageService _itemImageService;
        //private readonly ICategoryService _itemCategoryService;
        //private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        public ItemService(IItemRepository commonRepository, IMapper mapper) : base(commonRepository, mapper)
        {
            _commonRepository = commonRepository;
            //_colorService = colorService;
            //_cityService = cityService;
            //_itemImageService = itemImageService;
            //_itemCategoryService = itemCategoryService;
            //_userManager = userManager;
            _mapper = mapper;
            
            //IColorService colorService, ICityService cityService,IItemImageService itemImageService,
            //ICategoryService itemCategoryService, UserManager<IdentityUser> userManager
        }

        public async Task<List<ItemDto>> GetUserItems(string userId)
        {
            return _mapper.Map<List<ItemDto>>(await _commonRepository.List(new ItemUserIdSpecification(userId)));
        }

        public async Task<PagingResultDto<ItemDto>> Search(SearchDto searchViewModel, Dto.Common.PagingQueryDto page)
        {
            var categoryItems = _mapper.Map<PagingResultDto<ItemDto>>(
                await _commonRepository.List(
                    new ItemQuerySearchSpecification(searchViewModel.Color, searchViewModel.Category,searchViewModel.City,searchViewModel.Type, searchViewModel.Query), _mapper.Map<PagingQuery>(page)));

            return categoryItems;
        }

        public async Task<PagingResultDto<SearchResultDto>> GetLastItems(int count)
        {
            var categoryItems = _mapper.Map<PagingResultDto<SearchResultDto>>(
                (await _commonRepository.ListAll(new PagingQuery() { Page = 1, ItemsPerPage = count })));
            //var items = _mapper.Map<PagingResultDto<SearchResultDto>>(await GetLastItems(6));
            //foreach (var item in categoryItems.Items)
            //{
            //    var images = await _itemImageService.GetImageByItemId(item.Id);
            //    if (images != null && images.Count > 0)
            //        item.ImageSource = images.FirstOrDefault().Source;
            //    item.UserName = (await _userManager.FindByIdAsync(item.UserId)).UserName;
            //    item.Category = _mapper.Map<CategoryDto>(await _itemCategoryService.GetById(item.CategoryId));
            //    item.ColorName = (await _colorService.GetById(item.Color)).Name;
            //    item.CityName = (await _cityService.GetById(item.CityId)).Name;
            //}
            return categoryItems;
        }

        public async Task<ItemDetailDto> GetDetailsById(int id)
        {
            var item = await _commonRepository.GetSingleBySpec(new ItemDetailsSingleSpecification(id));
            return  _mapper.Map<ItemDetailDto>(item);
        }
    }
}
