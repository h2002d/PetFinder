using Novir.PetFinder.App.ViewModels.Categories;
using Novir.PetFinder.Core.Services.Categories;
using Novir.PetFinder.Core.Services.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.PetFinder.App.ViewModels.Items
{
    public class SearchResultViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public CategoryViewModel Category { get; set; }
        public string ImageSource { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string CityName { get; set; }
        public int Color { get; set; }
        public string ColorName { get; set; }
        public string TypeName
        {
            get
            {
                return Type == 1 ? "Found" : "Lost";
            }
        }
        public DateTime CreateDate { get; set; }

        public int CityId { get; set; }
        public int Type { get; set; }
    }
}
