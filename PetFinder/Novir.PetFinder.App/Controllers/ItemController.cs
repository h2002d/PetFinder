using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Novir.PetFinder.App.Helpers;
using Novir.PetFinder.App.ViewModels.Items;
using Novir.PetFinder.Core.Dto.Items;
using Novir.PetFinder.Core.Services.Categories;
using Novir.PetFinder.Core.Services.Dictionaries;
using Novir.PetFinder.Core.Services.Items;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Identity;
using Novir.PetFinder.App.ViewModels.Categories;
using Novir.PetFinder.Core.Dto.Common;
using Microsoft.AspNetCore.Authorization;

namespace Novir.PetFinder.App.Controllers
{
    public class ItemController : BaseController
    {
        #region Services
        private readonly IItemService _itemService;
        private readonly IItemImageService _itemImageService;
        private readonly ICityService _cityService;
        private readonly ICategoryService _itemCategoryService;
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        IViewLocalizer _localizer;
        private IHostingEnvironment _hostingEnvironment;
        #endregion

        public ItemController(UserManager<IdentityUser> userManager, IItemService itemService, ICategoryService itemCategoryService, IItemImageService itemImageService,
            IColorService colorService, IMapper mapper, IHostingEnvironment hostingEnvironment, IViewLocalizer localizer,
            ICityService cityService)
        {
            _itemService = itemService;
            _colorService = colorService;
            _itemImageService = itemImageService;
            _itemCategoryService = itemCategoryService;
            _mapper = mapper;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
            _localizer = localizer;
            _cityService = cityService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var item = _mapper.Map<ItemDetailViewModel>(await _itemService.GetDetailsById(id));
            item.ItemImages = await _itemImageService.GetImageByItemId(id);
            var user = _userManager.FindByIdAsync(item.UserId).Result;
            ViewBag.UserName = user.UserName;
            return View(item);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var item = _mapper.Map<ItemViewModel>(await _itemService.GetById(id));
            if (await CheckUserId(item.UserId))
                return RedirectToAction("Index", "Home");
            item.ItemImages = await _itemImageService.GetImageByItemId(id);
            var categories = _mapper.Map<List<CategoryViewModel>>((await _itemCategoryService.ListAllParents()).OrderBy(x => x.CategoryOrder));
            foreach (var category in categories)
            {
                var childItems = _mapper.Map<List<CategoryViewModel>>((await _itemCategoryService.ListChildById(category.Id)).OrderBy(x => x.CategoryOrder));
                category.ChildCategories.AddRange(childItems);
            }
            item.AllCategories = categories;
            item.AllCities = await _cityService.ListAll();
            item.AllColors = new SelectList(await _colorService.ListAll(), "Id", "Name");
            return View(item);
        }


        [Authorize]
        public async Task<IActionResult> Create()
        {
            var item = new ItemViewModel();
            var categories = _mapper.Map<List<CategoryViewModel>>((await _itemCategoryService.ListAllParents()).OrderBy(x => x.CategoryOrder));
            await CollectChild(categories);

            item.AllCategories = categories;
            item.AllCities = await _cityService.ListAll();
            item.AllColors = new SelectList(await _colorService.ListAll(), "Id", "Name");
            return View("Edit", item);
        }

        private async Task CollectChild(List<CategoryViewModel> categories)
        {
            foreach (var category in categories)
            {
                var childItems = _mapper.Map<List<CategoryViewModel>>(await _itemCategoryService.ListChildById(category.Id));
                category.ChildCategories.AddRange(childItems);
                await CollectChild(childItems);
            }
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(ItemViewModel item, [FromForm] List<IFormFile> formFiles)
        {
            var user = _userManager.GetUserAsync(User).Result;
            item.UserId = user.Id;
            item.CreateDate = DateTime.Now;
            if (item.Id == 0)
            {
                var addedItem = await _itemService.Add(_mapper.Map<ItemDto>(item));
                ItemImageHelper helper = new ItemImageHelper(_itemImageService, _hostingEnvironment);
                if (formFiles != null && formFiles.Count > 0)
                    await helper.SaveProductImage(formFiles, addedItem.Id);
                return RedirectToAction("Index", new { id = addedItem.Id });
            }
            else
            {
                if (await CheckUserId(item.UserId))
                    return RedirectToAction("Index", "Home");
                await _itemService.Update(_mapper.Map<ItemDto>(item));
                ItemImageHelper helper = new ItemImageHelper(_itemImageService, _hostingEnvironment);
                if (formFiles != null && formFiles.Count > 0)
                    await helper.SaveProductImage(formFiles, item.Id);
                return RedirectToAction("Index", new { id = item.Id });
            }
        }

        [Authorize]
        public async Task<IActionResult> DeleteImage(int Id)
        {
            var image = await _itemImageService.GetById(Id);

            var item = await _itemService.GetById(image.ItemId);
            if (await CheckUserId(item.UserId))
                return RedirectToAction("Index", "Home");
            await _itemImageService.Delete(Id);
            return RedirectToAction("Edit", new { id = image.ItemId });
        }

        public async Task<IActionResult> Search(SearchViewModel searchViewModel, int page = 1)
        {
            var items = _mapper.Map<PagingResultDto<SearchResultViewModel>>(await _itemService.Search(_mapper.Map<SearchDto>(searchViewModel), new PagingQueryDto() { Page = page, ItemsPerPage = 10 }));
            foreach (var item in items.Items)
            {
                var images = await _itemImageService.GetImageByItemId(item.Id);
                if (images != null && images.Count > 0)
                    item.ImageSource = images.FirstOrDefault().Source;
                item.UserName = (await _userManager.FindByIdAsync(item.UserId)).UserName;
                item.Category = _mapper.Map<CategoryViewModel>(await _itemCategoryService.GetById(item.CategoryId));
                item.ColorName = (await _colorService.GetById(item.Color)).Name;
                item.CityName = (await _cityService.GetById(item.CityId)).Name;
            }
            ViewBag.SelectedPage = page;
            return View(items);// RedirectToAction("Edit", new { id = image.ItemId });https://localhost:44372/item/Search?color=2&category=1&query=
        }

        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            var item = await _itemService.GetById(Id);
            if (await CheckUserId(item.UserId))
                return RedirectToAction("Index", "Home");
            await _itemService.Delete(Id);
            return RedirectToAction("Items", "User");
        }

        private async Task<bool> CheckUserId(string userId)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return !userId.Equals(user.Id);
        }

    }
}