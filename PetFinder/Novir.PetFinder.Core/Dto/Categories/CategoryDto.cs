using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Categories.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
