using Novir.PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Novir.PetFinder.Data.Specifications.ItemSpecifications
{
    public class ItemImageByIdSpecification : CommonSpecification<ItemImage>
    {
        public ItemImageByIdSpecification(int Id) : base(x => x.ItemId == Id)
        {
        }
    }
}
