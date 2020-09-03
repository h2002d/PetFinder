using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.PetFinder.App.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int CategoryOrder { get; set; }
        public bool hasColor { get; set; }

        public List<CategoryViewModel> ChildCategories { get; set; } = new List<CategoryViewModel>();
    }
}
