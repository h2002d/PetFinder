using Novir.PetFinder.Core.Categories.Dto;
using Novir.PetFinder.Core.Dto.Dictionaries;
using Novir.PetFinder.Core.Dto.Items;
using Novir.PetFinder.Core.Dto.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.PetFinder.App.ViewModels.Items
{
    public class ItemDetailViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public UserDto User { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int Color { get; set; }
        public int CityId { get; set; }
        public int Type { get; set; }
        public string TypeName
        {
            get
            {
                return Type == 1 ? "Found" : "Lost";
            }
        }
        public CityDto City { get; set; }

        public IReadOnlyList<ItemImageDto> ItemImages { get; set; }
    }
}
