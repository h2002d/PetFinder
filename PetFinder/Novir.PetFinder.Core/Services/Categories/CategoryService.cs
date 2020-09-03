using AutoMapper;
using Novir.PetFinder.Core.Categories.Dto;
using Novir.PetFinder.Core.Dto;
using Novir.PetFinder.Core.Services.Common;
using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Data.Repositories.Categories;
using Novir.PetFinder.Data.Repositories.Common;
using Novir.PetFinder.Data.Specifications.CategorySpecifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novir.PetFinder.Core.Services.Categories
{
    public class CategoryService : CommonService<Category, CategoryDto>, ICategoryService
    {
        private readonly ICategoryRepository _commonRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository commonRepository, IMapper mapper) :
            base(commonRepository, mapper)
        {
            _commonRepository = commonRepository;
            _mapper = mapper;
        }


        public async Task<List<CategoryDto>> ListAllParents()
        {
            var parents = await _commonRepository.List(new ParentCategorySpecification());
            return _mapper.Map<List<CategoryDto>>(parents);
        }

        public async Task<List<CategoryDto>> ListChildById(int Id)
        {
            var parents = await _commonRepository.List(new ChildCategorySpecification(Id));            
            return _mapper.Map<List<CategoryDto>>(parents);
        }
    }
}
