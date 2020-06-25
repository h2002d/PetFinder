using Microsoft.AspNetCore.Mvc.Rendering;
using Novir.PetFinder.Core.Categories.Dto;
using Novir.PetFinder.Core.Dto.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.PetFinder.App.ViewModels.Items
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int Color { get; set; }
        public IReadOnlyList<ItemImageDto> ItemImages { get; set; }
        public SelectList AllCategories { get; set; }
        public SelectList AllColors { get; set; }
    }
}
