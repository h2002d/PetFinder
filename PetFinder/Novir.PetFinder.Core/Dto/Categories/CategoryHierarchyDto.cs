using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Dto.Categories
{
    public class CategoryHierarchyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyList<CategoryHierarchyDto> ChildCategories { get; set; }
    }
}
