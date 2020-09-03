using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Specifications.ItemSpecifications
{
    public class ItemQuerySearchSpecification : CommonSpecification<Item>
    {
        public ItemQuerySearchSpecification(int colorId, int categoryId, int cityId, int? typeId, string query)
            : base(x => (String.IsNullOrEmpty(query) || x.Name.ToLower().Contains(query.ToLower())
        || x.Description.ToLower().Contains(query.ToLower()))
        && (categoryId == 0 || x.CategoryId == categoryId)
        && (cityId == 0 || x.CityId == cityId)
        && (colorId == 0 || x.Color == colorId)
        && (typeId == null || x.Type == typeId))
        {
        }
    }
}
