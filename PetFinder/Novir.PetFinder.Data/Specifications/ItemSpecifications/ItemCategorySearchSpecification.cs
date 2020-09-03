using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Specifications.ItemSpecifications
{
    public class ItemCategorySearchSpecification : CommonSpecification<Item>
    {
        public ItemCategorySearchSpecification(int categoryId) : base(x => x.CategoryId == categoryId)
        {
        }
    }
}
