using Novir.PetFinder.Core.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Dto.Items
{
    public class SearchResultDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public CategoryDto Category { get; set; }
        public string ImageSource { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string CityName { get; set; }
        public int Color { get; set; }
        public string ColorName { get; set; }
        public DateTime CreateDate { get; set; }

        public int CityId { get; set; }
        public int? Type { get; set; }

    }
}
