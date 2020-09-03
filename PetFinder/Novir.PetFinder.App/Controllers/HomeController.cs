using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Novir.PetFinder.App.Models;
using Novir.PetFinder.App.ViewModels.Categories;
using Novir.PetFinder.App.ViewModels.Home;
using Novir.PetFinder.App.ViewModels.Items;
using Novir.PetFinder.Core.Dto.Common;
using Novir.PetFinder.Core.Dto.Subsribers;
using Novir.PetFinder.Core.Services.Categories;
using Novir.PetFinder.Core.Services.Dictionaries;
using Novir.PetFinder.Core.Services.Items;
using Novir.PetFinder.Core.Services.Subscribers;
using Novir.PetFinder.Data.Entities;

namespace Novir.PetFinder.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IItemService _itemService;
        private readonly ICityService _cityService;
        private readonly IColorService _colorService;
        private readonly IItemImageService _itemImageService;
        private readonly ICategoryService _itemCategoryService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ISubscriberService _subscriberService;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IItemService itemService, ISubscriberService subscriberService,
            IColorService colorService, ICityService cityService, IItemImageService itemImageService,
            ICategoryService itemCategoryService, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _logger = logger;
            _categoryService = categoryService;
            _colorService = colorService;
            _cityService = cityService;
            _itemImageService = itemImageService;
            _itemCategoryService = itemCategoryService;
            _userManager = userManager;
            _mapper = mapper;
            _itemService = itemService;
            _subscriberService = subscriberService;
        }

        public async Task<IActionResult> Index()
        {
            //var htmlString = System.IO.File.ReadAllLines("./Views/User/registration.html");
            var viewModel = new IndexMainViewModel();
            var categories = _mapper.Map<List<CategoryViewModel>>((await _categoryService.ListAllParents()).OrderBy(x=>x.CategoryOrder));

            await CollectChild(categories);
            viewModel.Categories = categories;
            var cities = await _cityService.ListAll();
            viewModel.Cities = cities;

            var items = _mapper.Map<PagingResultDto<SearchResultViewModel>>(await _itemService.GetLastItems(6));
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
            viewModel.LastItems = items;
            return View(viewModel);
        }

        private async Task CollectChild(List<CategoryViewModel> categories)
        {
            foreach (var category in categories)
            {
                var childItems = _mapper.Map<List<CategoryViewModel>>((await _categoryService.ListChildById(category.Id)).OrderBy(x => x.CategoryOrder));
                category.ChildCategories.AddRange(childItems);
                await CollectChild(childItems);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult ChangeLanguage(string lang,string url)
        {
            //var cultureInfo = new CultureInfo(lang);
            //cultureInfo.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy hh:mm:ss";
            //cultureInfo.DateTimeFormat.DateSeparator = "-";
            //Thread.CurrentThread.CurrentUICulture = cultureInfo;
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
            //CookieOptions option = new CookieOptions();
            //option.Expires = DateTime.Now.AddYears(10);
            //Response.Cookies.Append("culture"", lang, option);
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, $"c={lang}|uic={lang}");
           //var stringUrl = HttpContext.Request.GetDisplayUrl() + HttpContext.Request.Path;
            return Redirect(url);
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(SubscriberViewModel subscriber)
        {
            await _subscriberService.Add(_mapper.Map<SubscriberDto>(subscriber));
            return RedirectToAction("Index");
        }
    }
}
