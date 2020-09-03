using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Categories.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_EN { get; set; }
        public string Name_RU { get; set; }
        public int? ParentId { get; set; }
        public int CategoryOrder { get; set; }
        public bool hasColor { get; set; }

    }
}
