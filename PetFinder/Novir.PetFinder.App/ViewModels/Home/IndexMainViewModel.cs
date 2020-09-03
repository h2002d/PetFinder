using Novir.PetFinder.App.ViewModels.Categories;
using Novir.PetFinder.App.ViewModels.Items;
using Novir.PetFinder.Core.Dto.Common;
using Novir.PetFinder.Core.Dto.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.PetFinder.App.ViewModels.Home
{
    public class IndexMainViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public List<CityDto> Cities { get; set; }
        public PagingResultDto<SearchResultViewModel> LastItems { get; set; }
    }
}
