using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Novir.PetFinder.Core.Services.Categories;
using Novir.PetFinder.App.ViewModels.Categories;
using Novir.PetFinder.Core.Categories.Dto;
using Novir.PetFinder.App.Controllers;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Globalization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetFinder.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var model = _mapper.Map<IReadOnlyList<CategoryViewModel>>(await _categoryService.ListAll());
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = _mapper.Map<CategoryViewModel>(await _categoryService.GetById(id));
            return View(model);
        }

        public IActionResult Create()
        {
            return View("Edit",new CategoryViewModel());
        }

       
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel category)
        {
            if (category.Id == 0)
                await _categoryService.Add(_mapper.Map<CategoryDto>(category));
            else
                await _categoryService.Update(_mapper.Map<CategoryDto>(category));
            return RedirectToAction("Index");
        }
    }
}
