using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Data.Specifications.ItemSpecifications
{
    public class ItemColorSearchSpecification : CommonSpecification<Item>
    {
        public ItemColorSearchSpecification(int colorId) : base(x => x.Color == colorId)
        {
        }
    }
}
