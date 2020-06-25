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

namespace Novir.PetFinder.App.Controllers
{
    public class ItemController : BaseController
    {
        private readonly IItemService _itemService;
        private readonly IItemImageService _itemImageService;
        private readonly ICategoryService _itemCategoryService;
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;
        IViewLocalizer _localizer;

        private IHostingEnvironment _hostingEnvironment;
        public ItemController(IItemService itemService, ICategoryService itemCategoryService, IItemImageService itemImageService,
            IColorService colorService, IMapper mapper, IHostingEnvironment hostingEnvironment, IViewLocalizer localizer)
        {
            _itemService = itemService;
            _colorService = colorService;
            _itemImageService = itemImageService;
            _itemCategoryService = itemCategoryService;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index(int id)
        {
            var item = _mapper.Map<ItemViewModel>(await _itemService.GetById(id));
            item.ItemImages = await _itemImageService.GetImageByItemId(id);
            return View(null);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = _mapper.Map<ItemViewModel>(await _itemService.GetById(id));
            item.ItemImages = await _itemImageService.GetImageByItemId(id);
            item.AllCategories = new SelectList(await _itemCategoryService.ListAll(), "Id", "Name");
            item.AllColors = new SelectList(await _colorService.ListAll(), "Id", "Name");
            return View(item);
        }

        public async Task<IActionResult> Create()
        {
            var item = new ItemViewModel();
            item.AllCategories = new SelectList(await _itemCategoryService.ListAll(), "Id", "Name");
            item.AllColors = new SelectList(await _colorService.ListAll(), "Id", "Name");
            return View("Edit", item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ItemViewModel item, [FromForm] List<IFormFile> formFiles)
        {
            item.UserId = "1sda";
            if (item.Id == 0)
            {
                var addedItem = await _itemService.Add(_mapper.Map<ItemDto>(item));
                ItemImageHelper helper = new ItemImageHelper(_itemImageService, _hostingEnvironment);
                await helper.SaveProductImage(formFiles, addedItem.Id);
                return RedirectToAction("Index", new { id = addedItem.Id });
            }
            else
            {
                await _itemService.Update(_mapper.Map<ItemDto>(item));
                ItemImageHelper helper = new ItemImageHelper(_itemImageService, _hostingEnvironment);
                await helper.SaveProductImage(formFiles, item.Id);
                return RedirectToAction("Index", new { id = item.Id });
            }
        }

        public async Task<IActionResult> DeleteImage(int Id)
        {
            var image = await _itemImageService.GetById(Id);
            await _itemImageService.Delete(Id);
            return RedirectToAction("Edit", new { id = image.ItemId });
        }
    }
}