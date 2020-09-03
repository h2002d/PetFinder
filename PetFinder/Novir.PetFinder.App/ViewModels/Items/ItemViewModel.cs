using Microsoft.AspNetCore.Mvc.Rendering;
using Novir.PetFinder.App.ViewModels.Categories;
using Novir.PetFinder.Core.Categories.Dto;
using Novir.PetFinder.Core.Dto.Dictionaries;
using Novir.PetFinder.Core.Dto.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.PetFinder.App.ViewModels.Items
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        [Required]
        public int Color { get; set; }
        [Required]
        public int Type { get; set; }
        public string TypeName
        {
            get
            {
                return Type == 1 ? "Found" : "Lost";
            }
        }
        public IReadOnlyList<ItemImageDto> ItemImages { get; set; }
        public List<CategoryViewModel> AllCategories { get; set; }
        public List<CityDto> AllCities { get; set; }
        public SelectList AllColors { get; set; }

        [Required]
        public int CityId { get; set; }

    }
}
